using Knjigovodstvo.Books.BalanceSheetJournal;
using System;
using System.Data;
using System.Windows.Forms;

namespace Knjigovodstvo.Books.BookJournal
{
    public partial class KnjizeneTemeljniceDialog : Form
    {
        public KnjizeneTemeljniceDialog()
        {
            InitializeComponent();
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            DataTable dt = new Temeljnica().GetTemeljnicaDataTable();
            dbDataGridView1.DataSource = dt;
            dbDataGridView1.Columns["Id"].Visible = false;
        }

        private void ButtonOtvori_Click(object sender, EventArgs e)
        {
            BrojTemeljnice = int.Parse(
                dbDataGridView1.SelectedRows[0]
                .Cells["Broj_temeljnice"]
                .Value
                .ToString());

            _temeljnica.GetTemeljnicaByNumber(BrojTemeljnice);

            Close();
        }

        internal Temeljnica OpenTemeljnica(ref DataTable dt, DBDataGridView dbDataGridView1)
        {
            dt = _dnevnikKnjizenja.GetDnevnikByTemeljnica(BrojTemeljnice);
            dbDataGridView1.DataSource = dt;
            dbDataGridView1.Columns["Id"].Visible = false;
            return _temeljnica;
        }

        private DnevnikKnjizenja _dnevnikKnjizenja = new DnevnikKnjizenja();
        private Temeljnica _temeljnica = new Temeljnica();
        public int BrojTemeljnice { get; private set; } = 0;
    }
}
