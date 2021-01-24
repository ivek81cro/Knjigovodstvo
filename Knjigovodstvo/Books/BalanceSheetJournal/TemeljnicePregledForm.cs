using Knjigovodstvo.Books.PrepareForBalanceSheet;
using Knjigovodstvo.Database;
using Knjigovodstvo.FinancialReports;
using Knjigovodstvo.GeneralData.WaitForm;
using Knjigovodstvo.Settings.SettingsBookkeeping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void DataTableToList()
        {
            foreach(DataRow row in _dt.Rows)
            {
                _stavkaList.Add(new TemeljnicaStavka()
                {
                    Id = int.Parse(row["Id"].ToString()),
                    Broj = int.Parse(row["Broj"].ToString()),
                    Datum = row["Datum"].ToString(),
                    Dokument = row["Dokument"].ToString(),
                    Duguje = decimal.Parse(row["Duguje"].ToString()),
                    Potrazuje = decimal.Parse(row["Potrazuje"].ToString()),
                    Konto = row["Konto"].ToString(),
                    Opis = row["Opis"].ToString(),
                    Valuta = row["Valuta"].ToString()
                });
            }
        }

        private void ComboBoxVrstaTemeljnice_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string selected = comboBoxVrstaTemeljnice.SelectedItem.ToString();
            _condition = $"Dokument = '{selected}' AND Broj_temeljnice = 0 ORDER BY Broj ASC, Id ASC";
            if (selected == "Place")
            {
                _condition = $"(Dokument = '{selected}' OR Dokument='Dodaci') AND Broj_temeljnice = 0";
            }
            
            LoadDataView();
        }

        private void LoadDataView()
        {
            _dt = new DbDataGet().GetTable(new TemeljnicaStavka(), _condition);
            CustomiseDataGridView();
            _dt.Columns["Duguje"].ColumnName = "Dugovna";
            _dt.Columns["Potrazuje"].ColumnName = "Potražna";
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
                foreach(DataGridViewRow row in rows)
                {
                    if (row.Cells["Id"].Value == null)
                        continue;
                    _stavka.Id = int.Parse(row.Cells["Id"].Value.ToString());
                    _stavka.DeleteStavka();
                }
            }
        }

        private DataTable _dt = new DataTable();
        private readonly List<Label> _labelList;
        private readonly CheckBalance _checkBalance = new CheckBalance();
        private string _condition = "";
        private TemeljnicaStavka _stavka = new TemeljnicaStavka();
        private BindingList<TemeljnicaStavka> _stavkaList = new BindingList<TemeljnicaStavka>();
    }
}
