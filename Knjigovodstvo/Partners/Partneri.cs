using Knjigovodstvo.Code.Validators;
using Knjigovodstvo.Database;
using Knjigovodstvo.Global;
using Knjigovodstvo.Models;
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
            if (!new IbanValidator().Validate(Iban))
                return FormError.Iban;
            if (Kupac != 'k' && Dobavljac != 'd')
                return FormError.Kupac_Dobavljac;

            return FormError.None;
        }

        public bool InsertNew()
        {
            if(new DbDataInsert().InsertData(this))
                return true;

            return false;
        }

        public bool UpdateData()
        {
            if (new DbDataUpdate().UpdateData(this))
                return true;

            return false;
        }

        public Partneri GetPartnerById()
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
            Iban = dt.Rows[0]["Iban"].ToString();
            Mbo = dt.Rows[0]["Mbo"].ToString();
            Kupac = char.Parse(dt.Rows[0]["Kupac"].ToString());
            Dobavljac = char.Parse(dt.Rows[0]["Dobavljac"].ToString());

            return this;
        }

        public OpciPodaci OpciPodaci { get; set; } = new OpciPodaci();
        public Adresa Adresa { get; set; } = new Adresa();
        public Kontakt Kontakt { get; set; } = new Kontakt();
        public string Iban { get; set; } = "";
        public string Mbo { get; set; } = "";
        public char Kupac { get; set; } = 'n';
        public char Dobavljac { get; set; } = 'n';
    }

}
