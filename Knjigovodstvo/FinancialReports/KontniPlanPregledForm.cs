using Knjigovodstvo.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Knjigovodstvo.FinancialReports
{
    public partial class KontniPlanPregledForm : Form
    {
        public KontniPlanPregledForm()
        {
            InitializeComponent();
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            dbDataGridView1.DataSource = 
                new DataView(
                    new DbDataGet()
                    .GetTable(_kontniPlan))
                .ToTable(false, "Konto", "Opis");

            dbDataGridView1.Columns[0].Width = (int)(dbDataGridView1.Width * 0.1);
            dbDataGridView1.Columns[1].Width = (int)(dbDataGridView1.Width);
        }

        private void FilterClass(string col)
        {
            string filterCondition = $"[{col}] " + (col == "Konto" ? $"LIKE '{textBoxFilterKonto.Text}%'" : $"LIKE '%{textBoxFilterOpis.Text}%'");
                        
            (dbDataGridView1.DataSource as DataTable).DefaultView.RowFilter = filterCondition;
        }

        private KontniPlan _kontniPlan = new KontniPlan();

        private void TextBoxFilterKonto_KeyUp(object sender, KeyEventArgs e)
        {
            FilterClass("Konto");
        }

        private void TextBoxFilterOpis_KeyUp(object sender, KeyEventArgs e)
        {
            FilterClass("Opis");
        }
    }
}
