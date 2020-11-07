using Knjigovodstvo.Database;
using System;
using System.Windows.Forms;

namespace Knjigovodstvo.Settings
{
    public partial class PostavkeTablicaForm : Form
    {
        public PostavkeTablicaForm()
        {
            InitializeComponent();
            LoadDatagrid();
        }
        private void LoadDatagrid()
        {
            dataGridView1.DataSource = new DbDataGet().GetTable(new Postavke());
        }

        private void ButtonEditPostavke_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            _postavke.GetPostavkaById(id);
            PostavkePromjenaForm pn = new PostavkePromjenaForm(_postavke);
            pn.FormClosing += new FormClosingEventHandler(PostavkePromjena_FormClosing);
        }

        private void PostavkePromjena_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoadDatagrid();
        }

        private Postavke _postavke = new Postavke();
    }
}
