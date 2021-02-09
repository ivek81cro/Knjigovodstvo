using Knjigovodstvo.Books.BookJournal;
using Knjigovodstvo.Books.PrepareForBalanceSheet;
using Knjigovodstvo.Database;
using Knjigovodstvo.FinancialReports;
using Knjigovodstvo.GeneralData.WaitForm;
using Knjigovodstvo.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Knjigovodstvo.Books.BalanceSheetJournal
{
    public partial class TemeljnicePregledForm : Form
    {
        public TemeljnicePregledForm()
        {
            InitializeComponent();
            _labelList = new List<Label>() { labelDuguje, labelPotrazuje };
            FillVrstaTemeljniceCombo();
        }

        private void FillVrstaTemeljniceCombo()
        {
            _dt = new DbDataCustomQuery().ExecuteQuery($"SELECT DISTINCT Dokument FROM TemeljnicaStavka;");
            if(_dt.Rows.Count != 0)
            {
                foreach(DataRow row in _dt.Rows)
                {
                    comboBoxVrstaTemeljnice.Items.Add(row["Dokument"].ToString());
                }
            }
            comboBoxVrstaTemeljnice.Items.Add(BookNames.Slobodna);
        }

        private void ComboBoxVrstaTemeljnice_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string selected = comboBoxVrstaTemeljnice.SelectedItem.ToString();
            string condition = $"Dokument = '{selected}' AND Broj_temeljnice = 0 ORDER BY Broj ASC, Id ASC";
            if (selected == "Place")
            {
                condition = $"(Dokument = '{selected}' OR Dokument='Dodaci') AND Broj_temeljnice = 0";
            }
            
            LoadDataView(condition);
        }

        private void LoadDataView(string condition = null)
        {
            _dt = new DbDataGet().GetTable(new TemeljnicaStavka(), condition);
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    dbDataGridView1.DataSource = _dt;
                }));
            }
            else
            {
                dbDataGridView1.DataSource = _dt;
            }

            dbDataGridView1.Columns["Id"].Visible = false;
            _checkBalance.CheckEndBalance(_dt, _labelList);
        }

        private void TemeljnicePregledForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                ButtonBrisiRed_Click(sender, e);
            }
        }

        private void DbDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dbDataGridView1.SelectedCells[0].ColumnIndex;

            if (dbDataGridView1.Columns[index].HeaderText == "Konto")
                using (var form = new KontniPlanPregledForm())
                {
                    form.ShowDialog();
                    _dt.Rows[dbDataGridView1.SelectedCells[0]
                        .RowIndex]["Konto"] = form.KontoBroj;
                    _dt.Rows[dbDataGridView1.SelectedCells[0]
                        .RowIndex]["Opis"] = form.Opis;
                }

            if (dbDataGridView1.Columns[index].HeaderText == "Datum")                
                    _dt.Rows[dbDataGridView1.SelectedCells[0]
                        .RowIndex]["Datum"] = DateTime.Today;
        }
       
        private void ButtonDodajRed_Click(object sender, EventArgs e)
        {
            if (comboBoxVrstaTemeljnice.Text != "")
            {
                _dt.Rows.Add();
                _checkBalance.CheckEndBalance(_dt, _labelList);
            }
        }

        private void ButtonBrisiRed_Click(object sender, EventArgs e)
        {
            using (WaitDialog waitDialog = new WaitDialog(DeleteSelectedRows, SplashMessages.Brisanje))
            {
                waitDialog.ShowDialog(this);
            }
            LoadDataView();
        }

        private void DeleteSelectedRows()
        {
            if (dbDataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewSelectedRowCollection rows = dbDataGridView1.SelectedRows;
                string condition = "OR ";
                foreach(DataGridViewRow row in rows)
                {
                    if (row.Cells["Id"].Value == null)
                        continue;
                    _stavka.Id = int.Parse(row.Cells["Id"].Value.ToString());
                    condition += $"Id={_stavka.Id} OR ";
                }
                condition = condition[0..^4] + ';';
                _stavka.DeleteStavka(condition);
            }
        }
        private void ProcesItemsToMainBook()
        {
            DnevnikKnjizenja dk = new DnevnikKnjizenja(); ;
            int latestNumber = dk.GetLatestBrojTemeljnice();

            _temeljnica = new Temeljnica()
            {
                Broj_temeljnice = latestNumber,

                Datum_knjizenja = DateTime.ParseExact(
                    dateTimePickerDatumKnjizenja.Value.ToString().Split(' ')[0]
                    , "dd.MM.yyyy."
                    , CultureInfo.InvariantCulture)
                .ToString("yyyy-MM-dd"),

                Vrsta_temeljnice = _currentBookType
            };

            string condition = "OR ";
            _dnevnikKnjizenja = new List<DnevnikKnjizenja>();
            foreach (DataGridViewRow row in dbDataGridView1.Rows)
            {
                dk = new DnevnikKnjizenja().ConvertDataGridViewRow(row, _temeljnica);
                dk.Broj_temeljnice = latestNumber;
                _dnevnikKnjizenja.Add(dk);
                _stavka.Id = int.Parse(row.Cells["Id"].Value.ToString());
                condition += $"Id={_stavka.Id} OR ";
            }
            condition = condition[0..^4] + ';';
            _stavka.DeleteStavka(condition);//Bulk delete condition

            _temeljnica.Dugovna = _dnevnikKnjizenja.Sum(x => x.Dugovna);
            _temeljnica.Potražna = _dnevnikKnjizenja.Sum(x => x.Potrazna);   
            
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate
                {
                    dbDataGridView1.DataSource = _dnevnikKnjizenja;
                }));
            }
            else
            {
                dbDataGridView1.DataSource = _dnevnikKnjizenja;
            }            
            dk.InsertNewBulk(dbDataGridView1);
            _temeljnica.InsertNew();
        }
        private void ButtonKnjiziTemeljnicu_Click(object sender, EventArgs e)
        {
            _currentBookType = comboBoxVrstaTemeljnice.Text;
            if(dbDataGridView1.Rows.Count > 0)
            {
                using WaitDialog waitDialog = new WaitDialog(ProcesItemsToMainBook, SplashMessages.Učitavanje);
                waitDialog.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("Nije otvorena niti jedna temeljnica trenutno", "Informacija");
            }
        }

        private void ButtonKnjizeneTemeljnice_Click(object sender, EventArgs e)
        {
            using (KnjizeneTemeljniceDialog dialog = new KnjizeneTemeljniceDialog())
            {
                dialog.ShowDialog();
                _temeljnica = dialog.OpenTemeljnica(ref _dt, dbDataGridView1);
                comboBoxVrstaTemeljnice.Text = _temeljnica.Vrsta_temeljnice;
            }
            _checkBalance.CheckEndBalance(_dt, _labelList);
        }

        private string _currentBookType;
        private Temeljnica _temeljnica = new Temeljnica();
        private DataTable _dt = new DataTable();
        private readonly List<Label> _labelList;
        private readonly CheckBalance _checkBalance = new CheckBalance();
        private readonly TemeljnicaStavka _stavka = new TemeljnicaStavka();
        private List<DnevnikKnjizenja> _dnevnikKnjizenja = new List<DnevnikKnjizenja>();
    }
}
