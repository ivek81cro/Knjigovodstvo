using System.Data;
using System.Windows.Forms;

namespace Knjigovodstvo.Books.BookJournal
{
    public partial class DnevnkiKnjizenjaForm : Form
    {
        public DnevnkiKnjizenjaForm()
        {
            InitializeComponent();
            LoadDataGrid();
        }

        private void FilterOpisColumn(object sender, KeyEventArgs e)
        {
            string filterCondition = $"[Opis] LIKE '%{textBoxFilterOpis.Text}%'";
            (dbDataGridView1.DataSource as DataTable).DefaultView.RowFilter = filterCondition;
        }

        private void FilterBrojTemeljnica(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;                
            }            
        }

        private void FilterVrstaTemeljnice(object sender, KeyEventArgs e)
        {
            string filterCondition = $"[Vrsta_temeljnice] LIKE '%{textBoxVrstaTemeljnice.Text}%'";
            (dbDataGridView1.DataSource as DataTable).DefaultView.RowFilter = filterCondition;
        }

        private void TextBoxFilterBrojTemeljnice_TextChanged(object sender, System.EventArgs e)
        {
            if (textBoxFilterBrojTemeljnice.Text.Length != 0)
            {
                string filterCondition = $"[Broj_temeljnice] = {textBoxFilterBrojTemeljnice.Text}";
                (dbDataGridView1.DataSource as DataTable).DefaultView.RowFilter = filterCondition;
            }
        }

        private void LoadDataGrid()
        {
            dbDataGridView1.DataSource = _dnevnikKnjizenja.GetDnevnikKnjizenjaDataTable();
        }

        private DnevnikKnjizenja _dnevnikKnjizenja = new DnevnikKnjizenja();
    }
}
