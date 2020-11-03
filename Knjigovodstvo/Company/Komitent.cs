using Knjigovodstvo.Code.Validators;
using Knjigovodstvo.Database;
using Knjigovodstvo.Interface;

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
            if (Adresa.Length < 2)
                return FormError.Street;
            if (Posta.Length != 5)
                return FormError.Post;
            if (Grad.Length < 2)
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
        public string Adresa { get; set; } = "";
        public string Posta { get; set; } = "";
        public string Grad { get; set; } = "";
        public string Telefon { get; set; } = "";
        public string Fax { get; set; } = "";
        public string Mail { get; set; } = "";
        public string Iban { get; set; } = "";
        public string Mbo { get; set; } = "";
        public string Vrsta_djelatnosti { get; set; } = "";
        public string Sifra_djelatnosti { get; set; } = "";
        public string Naziv_djelatnosti { get; set; } = "";
    }
}
