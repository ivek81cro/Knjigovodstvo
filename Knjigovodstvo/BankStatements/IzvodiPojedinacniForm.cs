using Knjigovodstvo.FinancialReports;
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

            _bindingList = new BindingList<IzvodPromet>(_izvod.Promet);
            _dSource = new BindingSource(_bindingList, null);

            dataGridView1.DataSource = _dSource;
            CustomiseColumns();

            FillKontoColumn();
        }

        private void FillKontoColumn()
        {
            List<IzvodParovi> parovi = new IzvodParovi().GetIzvodParovi();
            KontniPlan konto = new KontniPlan();
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Konto"].Value.ToString() == "" &&
                    parovi.Exists(p => p.Naziv_Izvod == row.Cells["Naziv"].Value.ToString()))
                {
                    int idPartner = parovi
                        .Where(p => p.Naziv_Izvod == row.Cells["Naziv"]
                        .Value.ToString())
                        .FirstOrDefault().Id_Konto;
                    konto.Id = idPartner;
                    konto.GetKontoById();
                    row.Cells["Konto"].Value = konto.Konto;
                }
            }
        }

        private static void MessageShow()
        {
            MessageBox.Show("Postoji već upareni konto.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ButtonSpremi_Click(object sender, System.EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Konto"].Value.ToString() == "")
                {
                    MessageBox.Show("Niste popunili sva polja 'Konto'","Upozorenje",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return;
                }
            }

            if (_izvod.ExistsInDatabase())
            {
                MessageBox.Show("Izvod već postoji u bazi", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
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

        private void ButtonPartneri_Click(object sender, System.EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            string naziv = row.Cells["Naziv"].Value.ToString();
            using var form = new PartneriTableForm();
            form.OdabirPartnera();
            
            Partneri partner = new Partneri();
            partner.OpciPodaci.Id = form.IdPartner; 
            partner.GetPartnerById();
            
            KontniPlan kontniPlan = new KontniPlan();
            kontniPlan.Konto = row.Cells["Dugovna"].Value.ToString() == "0" ? partner.KontoK : partner.KontoD;
            IzvodParovi par = new IzvodParovi()
            {
                Naziv_Izvod = naziv,
                Id_Konto = kontniPlan.GetIdByKontoNumber()
            };

            if (!par.ExistsInDb() && par.Id_Konto != 0)
            {
                par.InsertData();
                FillKontoColumn();
            }
            else
            {
                MessageShow();
            }
        }

        private void ButtonKontniPlan_Click(object sender, System.EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            string naziv = row.Cells["Naziv"].Value.ToString();
            using var form = new KontniPlanPregledForm();
            form.ShowDialog();
            IzvodParovi par = new IzvodParovi()
            {
                Naziv_Izvod = naziv,
                Id_Konto = form.Id_Konto
            };

            if (!par.ExistsInDb() && par.Id_Konto != 0)
            {
                par.InsertData();
                KontniPlan konto = new KontniPlan();
                konto.Id = par.Id_Konto;
                row.Cells["Konto"].Value = konto.GetKontoById();
            }
            else
            {
                MessageShow();
            }
        }
        
        private readonly Izvod _izvod;
        BindingSource _dSource = new BindingSource();
        BindingList<IzvodPromet> _bindingList;
    }
}
