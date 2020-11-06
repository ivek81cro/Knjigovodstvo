using Knjigovodstvo.Code.Validators;
using Knjigovodstvo.Database;
using Knjigovodstvo.Global;
using Knjigovodstvo.Models;

namespace Knjigovodstvo
{
    public class Komitent : IDbObject
    {
        public FormError ValidateData()
        {
            if (!new OibValidator().Validate(Oib))
                return FormError.Oib;
            if (Naziv.Length < 2)
                return FormError.Name;
            if (Adresa.Ulica.Length < 2)
                return FormError.Street;
            if (Adresa.Grad.Posta.Length != 5)
                return FormError.Post;
            if (Adresa.Grad.Mjesto.Length < 2)
                return FormError.City;
            if (!new IbanValidator().Validate(Iban))
                return FormError.Iban;
            
            return FormError.None;
        }

        public bool InsertNew()
        {
            if (new DbDataInsert().InsertData(this))
                return true;

            return false;
        }

        public bool UpdateData(int id)
        {
            Id = id;
            if (new DbDataUpdate().UpdateData(this))
                return true;

            return false;
        }

        public int Id { get; set; } = 0;
        public string Oib { get; set; } = "00000000000";
        public string Naziv { get; set; } = "";
        public Adresa Adresa { get; set; } = new Adresa();
        public Kontakt Kontakt { get; set; } = new Kontakt();
        public string Iban { get; set; } = "";
        public string Mbo { get; set; } = "";
        public string Vrsta_djelatnosti { get; set; } = "";
        public string Sifra_djelatnosti { get; set; } = "";
        public string Naziv_djelatnosti { get; set; } = "";
    }
}
