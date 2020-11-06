using Knjigovodstvo.Code.Validators;
using Knjigovodstvo.Database;
using Knjigovodstvo.Global;
using Knjigovodstvo.Models;
using Knjigovodstvo.Interface;

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

        public OpciPodaci OpciPodaci { get; set; } = new OpciPodaci();
        public Adresa Adresa { get; set; } = new Adresa();
        public Kontakt Kontakt { get; set; } = new Kontakt();
        public string Vrsta_djelatnosti { get; set; } = "";
        public string Sifra_djelatnosti { get; set; } = "";
        public string Naziv_djelatnosti { get; set; } = "";
    }
}
