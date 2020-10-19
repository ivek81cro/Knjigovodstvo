using Knjigovodstvo.Helpers;
using System;
using System.Data;
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
            string oib = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            Placa placa = new Placa().GetPlacaByOib(oib);
            PlacaIzracunForm pn = new PlacaIzracunForm();
            pn.FormClosing += new FormClosingEventHandler(this.PlacaNew_FormClosing);
            pn.EditPlaca(placa);
        }

        private void PlacaNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoadDatagrid();
        }

        private void BtnNewPlaca_Click(object sender, EventArgs e)
        {
            PlacaIzracunForm pn = new PlacaIzracunForm();
            pn.FormClosing += new FormClosingEventHandler(this.PlacaNew_FormClosing);
            pn.ShowDialog();
        }

        private void TextBoxFilterPlaca_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                $"Oib LIKE '{textBoxFilterPlaca.Text}%' OR Oib LIKE '% {textBoxFilterPlaca.Text}%'";
        }
    }    
}
