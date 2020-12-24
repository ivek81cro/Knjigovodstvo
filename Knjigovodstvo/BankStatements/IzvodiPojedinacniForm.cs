using Knjigovodstvo.Partners;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Knjigovodstvo.BankStatements
{
    public partial class IzvodiPojedinacniForm : Form
    {
        public IzvodiPojedinacniForm(Izvod izvodKnjiga)
        {
            _izvod = izvodKnjiga;
            InitializeComponent();
            FillData();
        }

        private void FillData()
        {
            labelDatumIzvoda.Text = "Datum izvoda: " + _izvod.Datum_izvoda;
            labelRedniBroj.Text = "Redni broj: " + _izvod.Redni_broj.ToString();
            labelStanjeZavrsno.Text = "Stanje završno: " + _izvod.Novo_stanje.ToString() + " HRK";

            var bindingList = new BindingList<IzvodPromet>(_izvod.Promet);
            var dSource = new BindingSource(bindingList, null);
            dataGridView1.DataSource = dSource;

            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["Id_izvod"].Visible = false;
            dataGridView1.Columns["Oznaka"].Visible = false;

            FillKontoColumn();
        }

        private void FillKontoColumn()
        {
            List<IzvodParovi> parovi = new IzvodParovi().GetIzvodParovi();
            Partneri partner = new Partneri();
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Konto"].Value.ToString() == "" &&
                    parovi.Exists(p => p.Naziv_Izvod == row.Cells["Naziv"].Value.ToString()))
                {
                    int idPartner = parovi
                        .Where(p => p.Naziv_Izvod == row.Cells["Naziv"]
                        .Value.ToString())
                        .FirstOrDefault().Id_Partner;
                    partner.OpciPodaci.Id = idPartner;
                    partner.GetPartnerById();
                    string konto = row.Cells["Potrazna"].Value.ToString() == "0" ? partner.KontoD : partner.KontoK;
                    row.Cells["Konto"].Value = konto;
                }
            }
        }

        private void ButtonSpremi_Click(object sender, System.EventArgs e)
        {
            if (_izvod.InsertData())
            {
                _izvod.GetCurrentId();
            }

            if(_izvod.Id != 0)
            {
                foreach( var promet in _izvod.Promet)
                {
                    promet.Id_izvod = _izvod.Id;
                    promet.InsertData();
                }
            }

            Close();
        }

        private void ButtonUpariKonto_Click(object sender, System.EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            string naziv = row.Cells["Naziv"].Value.ToString();
            using (var form = new PartneriTableForm())
            {
                form.OdabirPartnera();
                form.ShowDialog();
                IzvodParovi p = new IzvodParovi()
                {
                    Naziv_Izvod = naziv,
                    Id_Partner = form.IdPartner
                };

                if (!p.ExistsInDb())
                {
                    p.InsertData();
                    Partneri partner = new Partneri();
                    partner.OpciPodaci.Id = form.IdPartner;
                    partner.GetPartnerById();
                    row.Cells["Konto"].Value = row.Cells["Duguje"]
                        .Value.ToString() == "0" ? partner.KontoK : partner.KontoD;
                }
                else
                {
                    MessageBox.Show("Postoji već upareni konto.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        
        private readonly Izvod _izvod;
    }
}
