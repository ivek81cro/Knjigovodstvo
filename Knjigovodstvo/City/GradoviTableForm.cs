using Knjigovodstvo.Database;
using System;
using System.Data;
using System.Windows.Forms;

namespace Knjigovodstvo.City
{
    public partial class GradoviTableForm : Form
    {
        public GradoviTableForm()
        {
            InitializeComponent();
            LoadDatagrid();
        }

        private void LoadDatagrid()
        {
            dataGridView1.DataSource = new DbDataGet().GetTable(new Grad());
        }

        private void BtnNewGrad_Click(object sender, EventArgs e)
        {
            GradUnosForm form = new GradUnosForm();
            form.FormClosing += new FormClosingEventHandler(this.GradNew_FormClosing);
            form.ShowDialog();
        }

        private void GradNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoadDatagrid();
        }

        private void BtnEditGrad_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            _grad = new Grad().GetGradById(id);

            if (_odabir == 1)
            {
                Close();
            }
            else
            {
                GradUnosForm pn = new GradUnosForm(_grad);
                pn.FormClosing += new FormClosingEventHandler(this.GradNew_FormClosing);
                pn.EditGrad(_grad);
            }
        }

        private void BtnDeleteGrad_Click(object sender, EventArgs e)
        {
            _grad.Id = int.Parse(dataGridView1.SelectedRows[0].ToString());
            DialogResult result = MessageBox.Show("Da li ste sigurni da želite obrisati odabrani red?",
                "Brisanje reda", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (new DbDataDelete().DeleteItem(_grad))
                    MessageBox.Show("Podatak obrisan", "Brisanje podatka", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDatagrid();
            }
        }

        private void TextBoxFilterGrad_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                $"Naziv LIKE '{textBoxFilterGrad.Text}%' OR Naziv LIKE '% {textBoxFilterGrad.Text}%'";
        }

        internal Grad ShowDialogValue(int odabir)
        {
            _odabir = odabir;
            ShowDialog();

            return _grad;
        }

        private Grad _grad;
        private int _odabir = 0;
    }
}
