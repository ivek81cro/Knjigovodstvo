using Knjigovodstvo.Helpers;
using System;
using System.Data;
using System.Windows.Forms;

namespace Knjigovodstvo.Employee
{
    public partial class ZaposleniciTableForm : Form
    {
        public ZaposleniciTableForm()
        {
            InitializeComponent();
            LoadDatagrid();
        }

        private void LoadDatagrid()
        {
            dataGridView1.DataSource = new DbDataGet().GetTable(new Zaposlenik());
        }

        private void BtnNewZaposlenik_Click(object sender, EventArgs e)
        {
            ZaposlenikUnosForm form = new ZaposlenikUnosForm();
            form.FormClosing += new FormClosingEventHandler(this.ZaposlenikNew_FormClosing);
            form.ShowDialog();
        }

        private void ZaposlenikNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoadDatagrid();
        }

        private void BtnEditZaposlenik_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            Zaposlenik zaposlenik = new Zaposlenik().GetZaposlenikById(id);
            ZaposlenikUnosForm pn = new ZaposlenikUnosForm();
            pn.FormClosing += new FormClosingEventHandler(this.ZaposlenikNew_FormClosing);
            pn.EditZaposlenik(zaposlenik);
        }

        private void BtnDeleteZaposlenik_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            DialogResult result = MessageBox.Show("Da li ste sigurni da želite obrisati odabrani red?",
                "Brisanje reda", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (new DbDataDelete().DeleteItem(id, "Zaposlenik"))
                    MessageBox.Show("Podatak obrisan", "Brisanje podatka", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDatagrid();
            }
        }

        private void TextBoxFilterZaposlenik_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                $"Prezime LIKE '{textBoxFilterZaposlenik.Text}%' OR Prezime LIKE '% {textBoxFilterZaposlenik.Text}%'";
        }
    }
}
