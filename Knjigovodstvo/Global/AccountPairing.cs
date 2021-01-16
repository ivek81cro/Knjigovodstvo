using Knjigovodstvo.BankStatements;
using Knjigovodstvo.FinancialReports;
using Knjigovodstvo.Partners;
using System;
using System.Windows.Forms;

namespace Knjigovodstvo.Global 
{
    public partial class AccountPairing : UserControl
    {
        public AccountPairing(DataGridView dataGridView1)
        {
            InitializeComponent();
            _dataGridView1 = dataGridView1;            
        }

        public Delegate userFunctionPointer;

        private static void MessageShow()
        {
            MessageBox.Show("Postoji već upareni konto.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ButtonPartneri_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = _dataGridView1.SelectedRows[0];
            string naziv = row.Cells["Naziv"].Value.ToString();
            using var form = new PartneriTableForm();
            form.OdabirPartnera();

            Partneri partner = new Partneri();
            partner.OpciPodaci.Id = form.IdPartner;
            partner.GetPartnerById();

            KontniPlan kontniPlan = new KontniPlan
            {
                Konto = row.Cells["Dugovna"].Value.ToString() == "0" ? partner.KontoK : partner.KontoD
            };

            IzvodParovi par = new IzvodParovi()
            {
                Naziv_Izvod = naziv,
                Id_Konto = kontniPlan.GetIdByKontoNumber()
            };

            if (!par.ExistsInDb() && par.Id_Konto != 0)
            {
                par.InsertData();
                userFunctionPointer.DynamicInvoke();
            }
            else
            {
                MessageShow();
            }
        }

        private void ButtonKontniPlan_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = _dataGridView1.SelectedRows[0];
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
                KontniPlan konto = new KontniPlan
                {
                    Id = par.Id_Konto
                };

                row.Cells["Konto"].Value = konto.GetKontoById();

                userFunctionPointer.DynamicInvoke();
            }
            else
            {
                MessageShow();
            }
        }

        private readonly DataGridView _dataGridView1;
    }
}
