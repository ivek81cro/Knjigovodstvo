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
            Postavke postavka = new Postavke().GetPostavkaById(id);
            PostavkePromjenaForm pn = new PostavkePromjenaForm();
            pn.FormClosing += new FormClosingEventHandler(this.PostavkePromjena_FormClosing);
            pn.EditPostavka(postavka);
        }

        private void PostavkePromjena_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoadDatagrid();
        }
    }
}
