using Knjigovodstvo.Helpers;
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
            throw new NotImplementedException();
        }
    }
}
