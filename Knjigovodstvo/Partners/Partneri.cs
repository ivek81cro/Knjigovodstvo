using Knjigovodstvo.Code.Validators;
using Knjigovodstvo.Database;
using Knjigovodstvo.FinancialReports;
using Knjigovodstvo.Global;
using Knjigovodstvo.Interface;
using System.Data;

namespace Knjigovodstvo.Partners
{

    public class Partneri : IDbObject
    {
        public FormError ValidateData()
        {
            if (!new OibValidator().Validate(OpciPodaci.Oib))
                return FormError.Oib;
            if (OpciPodaci.Naziv.Length < 2)
                return FormError.Name;
            if (Adresa.Ulica.Length < 2)
                return FormError.Street;
            if (Adresa.Grad.Posta.Length != 5)
                return FormError.Post;
            if (Adresa.Grad.Mjesto.Length < 2)
                return FormError.City;
            if (!new IbanValidator().Validate(OpciPodaci.Iban))
                return FormError.Iban;

            return FormError.None;
        }

        public bool InsertNew()
        {
            SetKonto();

            if (new DbDataInsert().InsertData(this))
            {
                InsertNewKonto();
                return true;
            }
            return false;
        }

        private void SetKonto()
        {
            string sifra = OpciPodaci.Id.ToString();
            string kontoK = KontoK;
            string kontoD = KontoD;

            if (KontoK.StartsWith("12"))
            {
                while (kontoK.Length + sifra.Length < 8)
                    kontoK += "0";
                kontoK += sifra;
            }

            if (KontoD.StartsWith("22"))
            {
                while (kontoD.Length + sifra.Length < 8)
                    kontoD += "0";
                kontoD += sifra;
            }

            KontoK = kontoK;
            KontoD = kontoD;
        }

        private void InsertNewKonto()
        {
            if(KontoK.Length == 8)
            {
                _kontniPlan.Konto = KontoK;
                _kontniPlan.Opis = OpciPodaci.Naziv;
                _dataInsert.InsertData(_kontniPlan);
            }

            if (KontoD.Length == 8)
            {
                _kontniPlan.Konto = KontoD;
                _kontniPlan.Opis = OpciPodaci.Naziv;
                _dataInsert.InsertData(_kontniPlan);
            }
        }

        public bool UpdateData()
        {
            DbDataUpdate dbUpdate = new DbDataUpdate();
            SetKonto();
            DataTable dtD = new DbDataGet().GetTable(_kontniPlan, $"Konto = '{KontoD}'");
            if (dtD.Rows.Count > 0 && _kontniPlan.GetKontniPlanIdByKonto(KontoD))
            {
                _kontniPlan.Opis = OpciPodaci.Naziv;
                _kontniPlan.Konto = KontoD;
                dbUpdate.UpdateData(_kontniPlan);
            }

            DataTable dtK = new DbDataGet().GetTable(_kontniPlan, $"Konto = '{KontoK}'");
            if (dtK.Rows.Count > 0 && _kontniPlan.GetKontniPlanIdByKonto(KontoD))
            {
                _kontniPlan.Opis = OpciPodaci.Naziv;
                _kontniPlan.Konto = KontoK;
                dbUpdate.UpdateData(_kontniPlan);
            }

            if (dbUpdate.UpdateData(this))
                return true;

            return false;
        }

        public void GetPartnerById()
        {
            string condition = $"Id={OpciPodaci.Id};";
            DataTable dt = new DbDataGet().GetTable(this, condition);

            OpciPodaci.Id = int.Parse(dt.Rows[0]["Id"].ToString());
            OpciPodaci.Oib = dt.Rows[0]["Oib"].ToString();
            OpciPodaci.Naziv = dt.Rows[0]["Naziv"].ToString();
            Adresa.Ulica = dt.Rows[0]["Ulica"].ToString();
            Adresa.Broj = dt.Rows[0]["Broj"].ToString();
            Adresa.Grad.Posta = dt.Rows[0]["Posta"].ToString();
            Adresa.Grad.Mjesto = dt.Rows[0]["Mjesto"].ToString();
            Kontakt.Telefon = dt.Rows[0]["Telefon"].ToString();
            Kontakt.Fax = dt.Rows[0]["Fax"].ToString();
            Kontakt.Email = dt.Rows[0]["Email"].ToString();
            OpciPodaci.Iban = dt.Rows[0]["Iban"].ToString();
            OpciPodaci.Mbo = dt.Rows[0]["Mbo"].ToString();
            KontoK = dt.Rows[0]["KontoK"].ToString();
            KontoD = dt.Rows[0]["KontoD"].ToString();
        }

        public OpciPodaci OpciPodaci { get; set; } = new OpciPodaci();
        public Adresa Adresa { get; set; } = new Adresa();
        public Kontakt Kontakt { get; set; } = new Kontakt();
        public string KontoK { get; set; } = "";
        public string KontoD { get; set; } = "";

        private KontniPlan _kontniPlan = new KontniPlan();
        private DbDataInsert _dataInsert = new DbDataInsert();
    }

}
