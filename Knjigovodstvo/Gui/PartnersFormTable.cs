using Knjigovodstvo.Gui;
using Knjigovodstvo.Helpers;
using System;
using System.Data;
using System.Windows.Forms;

namespace Knjigovodstvo
{
    public partial class PartnersFormTable : Form
    {
        public PartnersFormTable()
        {
            InitializeComponent();
            LoadDatagrid();
        }

        private void BtnNewPartner_Click(object sender, EventArgs e)
        {
            PartnerForm form = new PartnerForm();
            form.FormClosing += new FormClosingEventHandler(this.PartnersNew_FormClosing);
            form.ShowDialog();
        }

        private void LoadDatagrid()
        {
            dataGridView1.DataSource = new DbDataGet().GetTable(new Partneri());
        }

        private void TextBoxFilterPartner_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                String.Format("Naziv LIKE '{0}%' OR Naziv LIKE '% {0}%'", textBoxFilterPartner.Text);
        }

        private void BtnEditPartner_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            Partneri partner = new Partneri().GetPartnerById(id);
            PartnerForm pn = new PartnerForm();
            pn.FormClosing += new FormClosingEventHandler(this.PartnersNew_FormClosing);
            pn.EditPartner(partner);
        }

        private void PartnersNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoadDatagrid();
        }

        private void BtnDeletePartner_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            DialogResult result = MessageBox.Show("Da li ste sigurni da želite obrisati odabrani red?", 
                "Brisanje partnera", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (new DbDataDelete().DeleteItem(id, "Partneri"))
                    MessageBox.Show("Podatak obrisan", "Brisanje podatka", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                LoadDatagrid();
            }
        }
    }
}
