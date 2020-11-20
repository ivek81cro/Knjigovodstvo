using Knjigovodstvo.Database;
using Knjigovodstvo.Helpers;
using System.Data;
using System.Windows.Forms;

namespace Knjigovodstvo.URA
{
    public partial class UraTrosakForm : Form
    {
        public UraTrosakForm()
        {
            InitializeComponent();
            LoadDatagrid();
        }

        private void LoadDatagrid()
        {
            dataGridView1.DataSource = new DbDataExecProcedure().GetTable(ProcedureNames.Izdvoji_Troskove);
            FixColumnHeaders();
        }

        private void FixColumnHeaders()
        {
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].HeaderText =
                    new TableHeaderFormat().FormatHeader(dataGridView1.Columns[i].HeaderText);
            }
        }

        private void textBoxFilterNaziv_KeyUp(object sender, KeyEventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Naziv_dobavljaca] LIKE '%{0}%'", textBoxFilterNaziv.Text);
        }
    }
}
