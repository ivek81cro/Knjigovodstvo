using Knjigovodstvo.Books.PrepareForBalanceSheet;
using Knjigovodstvo.Database;
using Knjigovodstvo.FinancialReports;
using Knjigovodstvo.Settings.SettingsBookkeeping;
using System;
using System.Collections.Generic;
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
            _checkBalance.CheckEndBalance(_dt, _labelList);
        }

        private void LoadDataView()
        {
            CustomiseDataGridView();
            _dt.Columns["Duguje"].ColumnName = "Dugovna";
            _dt.Columns["Potrazuje"].ColumnName = "Potražna";
            _dt.Columns.Remove("Id");
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
            _checkBalance.CheckEndBalance(_dt, _labelList);
        }

        private DataTable _dt = new DataTable();
        private List<Label> _labelList;
        private readonly CheckBalance _checkBalance = new CheckBalance();
    }
}
