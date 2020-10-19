using Knjigovodstvo.Helpers;
using System;
using System.Windows.Forms;

namespace Knjigovodstvo.Payroll
{
    public partial class PlacaTableForm : Form
    {
        public PlacaTableForm()
        {
            InitializeComponent();
            LoadDatagrid();
        }

        private void LoadDatagrid()
        {
            dataGridView1.DataSource = new DbDataGet().GetTable(new Placa());
        }

        private void BtnEditPlaca_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnNewPlaca_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TextBoxFilterPlaca_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}
