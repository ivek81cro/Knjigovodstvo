using Knjigovodstvo.Books.PrepareForBalanceSheet;
using Knjigovodstvo.Database;
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
        }

        private void ComboBoxVrstaTemeljnice_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            _dt = new DbDataGet().GetTable(new TemeljnicaStavka(), 
                $"Dokument = '{comboBoxVrstaTemeljnice.SelectedItem}' AND Broj_temeljnice = 0");
            LoadDataView();
            CheckBalance();
        }

        private void LoadDataView()
        {
            dbDataGridView1.DataSource = _dt;
            dbDataGridView1.Columns.RemoveAt(0);
            dbDataGridView1.Columns.RemoveAt(dbDataGridView1.Columns.Count - 1);

            foreach (DataGridViewColumn col in dbDataGridView1.Columns)
            {
                col.HeaderText = Regex.Replace(col.HeaderText, @"[\d-_]", " ");
            }
        }

        private void CheckBalance()
        {
            decimal duguje = 0;
            decimal potrazuje = 0;
            decimal temp;
            foreach (DataRow row in _dt.Rows) 
            {
                if(decimal.TryParse(row["Duguje2"].ToString(), out temp))
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

        private DataTable _dt = new DataTable();
    }
}
