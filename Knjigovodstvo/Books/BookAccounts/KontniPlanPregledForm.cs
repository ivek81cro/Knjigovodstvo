using Knjigovodstvo.Database;
using System;
using System.Data;
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

        private void TextBoxFilterKonto_KeyUp(object sender, KeyEventArgs e)
        {
            FilterClass("Konto");
        }

        private void TextBoxFilterOpis_KeyUp(object sender, KeyEventArgs e)
        {
            FilterClass("Opis");
        }

        private void ButtonDodajKonto_Click(object sender, EventArgs e)
        {
            KontniPlanNoviForm form = new KontniPlanNoviForm();
            form.ShowDialog();
        }

        private void DbDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dbDataGridView1.SelectedRows[0];
            KontoBroj = selectedRow.Cells["Konto"].Value.ToString(); 
            Opis = selectedRow.Cells["Opis"].Value.ToString();
            _kontniPlan.Konto = KontoBroj;
            Id_Konto = _kontniPlan.GetIdByKontoNumber();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            DbDataGridView1_CellClick(null, null);
            Close();
        }

        private readonly KontniPlan _kontniPlan = new KontniPlan();
        public int Id_Konto { get; private set; }
        public string KontoBroj { get; private set; }
        public string Opis { get; set; }
    }
}
