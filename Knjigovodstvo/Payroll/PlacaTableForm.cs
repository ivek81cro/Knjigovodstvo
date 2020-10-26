using Knjigovodstvo.Database;
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
            dataGridView1.DataSource = new DbDataExecProcedure().GetTable(ProcedureNames.PlacaPregled);
            for(int i = 3; i< dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].DefaultCellStyle.Format = "0.00";
                dataGridView1.Columns[i].HeaderText =
                    new TableHeaderFormat().FormatHeader(dataGridView1.Columns[i].HeaderText);
            }
        }

        private void BtnEditPlaca_Click(object sender, EventArgs e)
        {
            string oib = dataGridView1.SelectedRows[0].Cells["Oib"].Value.ToString();
            Placa placa = new Placa().GetPlacaByOib(oib);
            PlacaIzracunForm pn = new PlacaIzracunForm(oib);
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
                $"Prezime LIKE '{textBoxFilterPlaca.Text}%' OR Prezime LIKE '% {textBoxFilterPlaca.Text}%'";
        }
    }    
}
