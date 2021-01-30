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
            dbDataGridView1.DataSource = Grad.GetGradDataTable();
            dbDataGridView1.Columns["Id"].Visible = false;
        }

        private void TextBoxFilterGrad_TextChanged(object sender, EventArgs e)
        {
            (dbDataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                $"Mjesto LIKE '{textBoxFilterGrad.Text}%' OR Mjesto LIKE '% {textBoxFilterGrad.Text}%'";
        }

        private void ButtonNewGrad_Click(object sender, EventArgs e)
        {
            GradEditForm form = new GradEditForm();
            form.ShowDialog();
            LoadDatagrid();
        }

        private void ButtonEditGrad_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dbDataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            Grad.GetGradById(id);

            if (Odabir)
            {
                Close();
            }
            else
            {
                GradEditForm pn = new GradEditForm(Grad);
                pn.ShowDialog();
                LoadDatagrid();
            }

        }
        
        private void ButtonDeleteGrad_Click(object sender, EventArgs e)
        {
            Grad.Id = int.Parse(dbDataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            DialogResult result = MessageBox.Show("Da li ste sigurni da želite obrisati odabrani red?",
                "Brisanje reda", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (Grad.DeleteGrad())
                    MessageBox.Show("Podatak obrisan", "Brisanje podatka", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDatagrid();
            }
        }

        public Grad Grad { get; private set; } = new Grad();
        public bool Odabir { get; set; } = false;
    }
}
