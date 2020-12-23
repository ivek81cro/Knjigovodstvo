using Knjigovodstvo.Database;
using System;
using System.Data;
using System.Windows.Forms;

namespace Knjigovodstvo.Partners
{
    public partial class PartneriTableForm : Form
    {
        public PartneriTableForm()
        {
            InitializeComponent();
            LoadDatagrid();

        }
        private void LoadDatagrid()
        {
            dataGridView1.DataSource = new DataView(new DbDataGet().GetTable(_partner))
                .ToTable(false, "Id", "Oib", "Naziv", "Ulica", "Broj", "Posta", "Mjesto", "Telefon", "Fax", "Email", "Iban", "Mbo");
        }

        internal void OdabirPartnera()
        {
            btnEditPartner.Visible = false;
            btnDeletePartner.Visible = false;
            btnOdaberi.Visible = true;
        }

        private void TextBoxFilterPartner_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                $"Naziv LIKE '{textBoxFilterPartner.Text}%' OR Naziv LIKE '% {textBoxFilterPartner.Text}%'";
        }

        private void BtnNewPartner_Click(object sender, EventArgs e)
        {
            PartnerUnosForm form = new PartnerUnosForm();
            form.FormClosing += new FormClosingEventHandler(PartnersNew_FormClosing);
            form.ShowDialog();
        }

        private void BtnEditPartner_Click(object sender, EventArgs e)
        {
            _partner.OpciPodaci.Id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            _partner.GetPartnerById();
            PartnerUnosForm pn = new PartnerUnosForm(_partner);
            pn.FormClosing += new FormClosingEventHandler(PartnersNew_FormClosing);
            pn.ShowDialog();
        }
        private void PartnersNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoadDatagrid();
        }

        private void BtnDeletePartner_Click(object sender, EventArgs e)
        {
            _partner.OpciPodaci.Id = int.Parse(dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString());
            DialogResult result = MessageBox.Show("Da li ste sigurni da želite obrisati odabranog partnera?", 
                "Brisanje partnera", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (new DbDataDelete().DeleteItem(_partner))
                    MessageBox.Show("Podatak obrisan", "Brisanje podatka", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                LoadDatagrid();
            }
        }

        private void BtnOdaberi_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                IdPartner = int.Parse(dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString());
                Close();
            }
            else
                MessageBox.Show("Niste odabrali red.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private readonly Partneri _partner = new Partneri();
        public int IdPartner { get; private set; } = 0;
    }
}
