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
            _dt = _partner.GetPartnerDataTable();
            dbDataGridView1.DataSource = _dt;
            dbDataGridView1.Columns["Id"].Visible = false;
            dbDataGridView1.Columns["Id1"].Visible = false;
            dbDataGridView1.Columns["KontoK"].Visible = false;
            dbDataGridView1.Columns["KontoD"].Visible = false;
        }

        internal void OdabirPartnera()
        {
            buttonEditPartner.Visible = false;
            buttonDeletePartner.Visible = false;
            buttonOdaberi.Visible = true;
            ShowDialog();
        }

        private void TextBoxFilterPartner_TextChanged(object sender, EventArgs e)
        {
            (dbDataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                $"Naziv LIKE '{textBoxPartnerFilter.Text}%' OR Naziv LIKE '% {textBoxPartnerFilter.Text}%'";
        }

        private void ButtonNewPartner_Click(object sender, EventArgs e)
        {
            PartnerUnosForm form = new PartnerUnosForm();
            form.ShowDialog();
            LoadDatagrid();
        }

        private void ButtonEditPartner_Click(object sender, EventArgs e)
        {
            if (_partner.OpciPodaci.Id != 0)
            {
                _partner.OpciPodaci.Id = int.Parse(dbDataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                _partner.GetPartnerById();
                PartnerUnosForm pn = new PartnerUnosForm();
                pn.InitPartner(_partner);
                pn.ShowDialog();
                LoadDatagrid();
            }
        }

        private void ButtonDeletePartner_Click(object sender, EventArgs e)
        {
            _partner.OpciPodaci.Id = int.Parse(dbDataGridView1.SelectedRows[0].Cells["Id"].Value.ToString());
            DialogResult result = MessageBox.Show("Da li ste sigurni da želite obrisati odabranog partnera?", 
                "Brisanje partnera", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (new DbDataDelete().DeleteItem(_partner))
                    MessageBox.Show("Podatak obrisan", "Brisanje podatka", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                LoadDatagrid();
            }
        }

        private void ButtonOdaberi_Click(object sender, EventArgs e)
        {
            if (dbDataGridView1.SelectedRows.Count != 0)
            {
                IdPartner = int.Parse(dbDataGridView1.SelectedRows[0].Cells["Id"].Value.ToString());
                Close();
            }
            else
                MessageBox.Show("Niste odabrali red.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private readonly Partneri _partner = new Partneri();
        private DataTable _dt = new DataTable();
        public int IdPartner { get; private set; } = 0;
    }
}
