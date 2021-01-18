using Knjigovodstvo.Database;
using Knjigovodstvo.Helpers;
using System;
using System.Data;
using System.Windows.Forms;

namespace Knjigovodstvo.Books.Inventory
{
    public partial class OsnovnoSredstvoForm : Form
    {
        public OsnovnoSredstvoForm()
        {
            InitializeComponent();
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            _dt = new DbDataGet().GetTable(_osnovnoSredstvo);
            dbDataGridView1.DataSource = _dt;

            foreach (DataGridViewColumn col in dbDataGridView1.Columns)
            {
                col.HeaderText =
                    new TableHeaderFormat().FormatHeader(col.HeaderText);
            }
        }

        private void ButtonDodajNovo_Click(object sender, EventArgs e)
        {
            using OsnovnoSredstvoDodajForm form = new OsnovnoSredstvoDodajForm();
            form.ShowDialog();
        }

        private void ButtonObracunAmortizacije_Click(object sender, EventArgs e)
        {

        }

        private DataTable _dt = new DataTable();
        private OsnovnoSredstvo _osnovnoSredstvo= new OsnovnoSredstvo();
    }
}
