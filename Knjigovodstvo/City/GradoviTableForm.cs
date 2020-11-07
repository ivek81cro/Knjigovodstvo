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

        private void TextBoxFilterGrad_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                $"Mjesto LIKE '{textBoxFilterGrad.Text}%' OR Mjesto LIKE '% {textBoxFilterGrad.Text}%'";
        }

        internal Grad OdabirGrada()
        {
            _odabir = true;
            ShowDialog();

            return _grad;
        }

        private void ButtonNewGrad_Click(object sender, EventArgs e)
        {
            GradEditForm form = new GradEditForm();
            form.FormClosing += new FormClosingEventHandler(GradNew_FormClosing);
            form.ShowDialog();
        }

        private void GradNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoadDatagrid();
        }

        private void BtnEditGrad_Click(object sender, EventArgs e)
        {

            int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            _grad.GetGradById(id);

            if (_odabir)
            {
                Close();
            }
            else
            {
                GradEditForm pn = new GradEditForm(_grad);
                pn.FormClosing += new FormClosingEventHandler(this.GradNew_FormClosing);
            }

        }
        
        private void BtnDeleteGrad_Click(object sender, EventArgs e)
        {
            _grad.Id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            DialogResult result = MessageBox.Show("Da li ste sigurni da želite obrisati odabrani red?",
                "Brisanje reda", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (new DbDataDelete().DeleteItem(_grad))
                    MessageBox.Show("Podatak obrisan", "Brisanje podatka", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDatagrid();
            }
        }

        private Grad _grad = new Grad();
        private bool _odabir = false;
    }
}
