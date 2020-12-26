using Knjigovodstvo.Books.PrepareForBalanceSheet;
using Knjigovodstvo.Database;
using Knjigovodstvo.FinancialReports;
using Knjigovodstvo.Settings.SettingsBookkeeping;
using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Knjigovodstvo.Books.BalanceSheetJournal
{
    public partial class TemeljnicePregledForm : Form
    {
        public TemeljnicePregledForm()
        {
            InitializeComponent();
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
            _dt = new DbDataGet().GetTable(new TemeljnicaStavka(), condition);
            LoadDataView();
            CheckEndBalance();
        }

        private void LoadDataView()
        {
            dbDataGridView1.DataSource = _dt;
            dbDataGridView1.Columns.RemoveAt(0);
            dbDataGridView1.Columns.RemoveAt(dbDataGridView1.Columns.Count - 1);
            dbDataGridView1.Columns[0].ReadOnly = true;

            foreach (DataGridViewColumn col in dbDataGridView1.Columns)
            {
                col.HeaderText = Regex.Replace(col.HeaderText, @"[\d-_]", " ");
            }
        }

        private void CheckEndBalance()
        {
            decimal duguje = 0;
            decimal potrazuje = 0;
            foreach (DataRow row in _dt.Rows)
            {
                if (decimal.TryParse(row["Duguje2"].ToString(), out decimal temp))
                {
                    duguje += temp;
                    temp = 0;
                }
                if (decimal.TryParse(row["Potrazuje2"].ToString(), out temp))
                {
                    potrazuje += temp;
                    temp = 0;
                }
            }
            labelPotrazuje.Text = "Potrazuje: " + potrazuje.ToString();
            labelDuguje.Text = "Duguje: " + duguje.ToString();

            if(potrazuje != duguje) 
            {
                labelPotrazuje.ForeColor = Color.Red;
                labelDuguje.ForeColor = Color.Red;
            }
            else
            {
                labelPotrazuje.ForeColor = Color.Green;
                labelDuguje.ForeColor = Color.Green;
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
            _dt.Rows.Add();
            CheckEndBalance();
        }

        private DataTable _dt = new DataTable();
    }
}
