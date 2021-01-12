using Knjigovodstvo.Code.Validators;
using Knjigovodstvo.Database;
using Knjigovodstvo.Global;
using Knjigovodstvo.Interface;
using System.Data;

namespace Knjigovodstvo
{
    public class Komitent : IDbObject
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
            if (new DbDataInsert().InsertData(this))
                return true;

            return false;
        }

        public bool UpdateData()
        {
            if (new DbDataUpdate().UpdateData(this))
                return true;

            return false;
        }

        public void GetData()
        {
            DataTable dt = new DbDataGet().GetTable(this);
            OpciPodaci.Oib = dt.Rows[0]["Oib"].ToString();
            OpciPodaci.Naziv = dt.Rows[0]["Naziv"].ToString();
            OpciPodaci.Id = int.Parse(dt.Rows[0]["Id"].ToString());
            OpciPodaci.Iban = dt.Rows[0]["Iban"].ToString();
            OpciPodaci.Mbo = dt.Rows[0]["Mbo"].ToString();
            Adresa.Grad.Mjesto = dt.Rows[0]["Mjesto"].ToString();
            Adresa.Ulica = dt.Rows[0]["Ulica"].ToString();
            Adresa.Broj = dt.Rows[0]["Broj"].ToString();
            Kontakt.Email = dt.Rows[0]["Email"].ToString();
            Kontakt.Telefon = dt.Rows[0]["Telefon"].ToString();
            Kontakt.Fax = dt.Rows[0]["Fax"].ToString();
            Vrsta_djelatnosti = dt.Rows[0]["Vrsta_djelatnosti"].ToString();
            Sifra_djelatnosti = dt.Rows[0]["Sifra_djelatnosti"].ToString();
            Naziv_djelatnosti = dt.Rows[0]["Naziv_djelatnosti"].ToString();
        }

        public OpciPodaci OpciPodaci { get; set; } = new OpciPodaci();
        public Adresa Adresa { get; set; } = new Adresa();
        public Kontakt Kontakt { get; set; } = new Kontakt();
        public string Vrsta_djelatnosti { get; set; } = "";
        public string Sifra_djelatnosti { get; set; } = "";
        public string Naziv_djelatnosti { get; set; } = "";
    }
}
