using Knjigovodstvo.Database;
using System;
using System.Windows.Forms;

namespace Knjigovodstvo.Settings
{
    public partial class PostavkePlaceTablicaForm : Form
    {
        public PostavkePlaceTablicaForm()
        {
            InitializeComponent();
            LoadDatagrid();
        }
        private void LoadDatagrid()
        {
            dataGridView1.DataSource = new DbDataGet().GetTable(new PostavkePlace());
        }

        private void ButtonEditPostavke_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            _postavke.GetPostavkaById(id);
            PostavkePlacePromjenaForm pn = new PostavkePlacePromjenaForm(_postavke);
            pn.FormClosing += new FormClosingEventHandler(PostavkePromjena_FormClosing);
        }

        private void PostavkePromjena_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoadDatagrid();
        }

        private readonly PostavkePlace _postavke = new PostavkePlace();
    }
}
