using Knjigovodstvo.Code.Validators;
using Knjigovodstvo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Knjigovodstvo
{
    class Komitent : IDbObject
    {
        public bool ValidateData()
        {
            if (!new OibValidator().Validate(Oib))
                return false;
            if (Naziv.Length < 2)
                return false;
            if (Adresa.Length < 2)
                return false;
            if (Posta.Length != 5)
                return false;
            if (Grad.Length < 2)
                return false;
            if (!new IbanValidator().Validate(Iban))
                return false;
            return true;
        }

        public string Oib { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Posta { get; set; }
        public string Grad { get; set; }
        public string Telefon { get; set; }
        public string Fax { get; set; }
        public string Mail { get; set; }
        public string Iban { get; set; }
        public string Vrsta_djelatnosti { get; set; }
        public string Sifra_djelatnosti { get; set; }
        public string Naziv_djelatnosti { get; set; }
        public string Mbo { get; set; }
    }
}
