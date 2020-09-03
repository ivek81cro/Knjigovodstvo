using Knjigovodstvo.Code;
using Knjigovodstvo.Gui;
using Knjigovodstvo.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Knjigovodstvo
{
    public partial class partnersForm : Form
    {
        public partnersForm()
        {
            InitializeComponent();
            LoadDatagrid();
        }

        private void BtnNewPartner_Click(object sender, EventArgs e)
        {
            PartnersNew form = new PartnersNew();
            form.ShowDialog();
        }

        private void LoadDatagrid()
        {
            dataGridView1.DataSource = new DbDataGet().GetTable("SELECT * FROM Partneri;");
        }

        private void TextBoxFilterPartner_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                String.Format("Naziv LIKE '{0}%' OR Naziv LIKE '% {0}%'", textBoxFilterPartner.Text);
        }

        private void BtnEditPartner_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            Partner partner = new Partner().GetPartnerById(id);
            PartnersNew pn = new PartnersNew();
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
            Partner partner = new Partner().GetPartnerById(id);
            if (new DbDataDelete().DeletePartner(partner))
                MessageBox.Show("Partner obrisan", "Brisanje partnera", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadDatagrid();
        }
    }
}
