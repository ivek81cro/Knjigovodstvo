using Knjigovodstvo.Database;
using Knjigovodstvo.Helpers;
using System;
using System.Data;
using System.Windows.Forms;

namespace Knjigovodstvo.Wages
{
    public partial class PlacaPregledForm : Form
    {
        public PlacaPregledForm()
        {
            InitializeComponent();
            LoadDatagrid();
        }

        private void LoadDatagrid()
        {
            dataGridView1.DataSource = new DbDataExecProcedure().GetTable(ProcedureNames.PlacaPregled);
            for(int i = 0; i< dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].HeaderText =
                    new TableHeaderFormat().FormatHeader(dataGridView1.Columns[i].HeaderText);
            }
        }

        private void ButtonIzracun_Click(object sender, EventArgs e)
        {
            PlacaIzracunForm pn;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string oib = dataGridView1.SelectedRows[0].Cells["Oib"].Value.ToString();
                _placa.GetPlacaByOib(oib);
                pn = new PlacaIzracunForm(_placa);
            }
            else
            {
                pn = new PlacaIzracunForm();
            }
            pn.ShowDialog();
            LoadDatagrid();
        }

        private void TextBoxFilterPlaca_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                $"Prezime LIKE '{textBoxFilterPlaca.Text}%' OR Prezime LIKE '% {textBoxFilterPlaca.Text}%'";
        }

        private readonly Placa _placa = new Placa();
    }    
}
