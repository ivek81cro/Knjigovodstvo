using Knjigovodstvo.Code.Validators;
using Knjigovodstvo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Knjigovodstvo.Employee
{
    class Zaposlenik : IDbObject
    {
        public FormError ValidateData()
        {
            if (!new OibValidator().Validate(Oib))
                return FormError.Oib;
            if (Ime.Length < 2)
                return FormError.Name;
            if (Prezime.Length < 2)
                return FormError.Street;
            if (Adresa.Length < 2)
                return FormError.Street;
            if (Grad.Length < 2)
                return FormError.City;

            return FormError.None;
        }

        public string Oib { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string DatumRodenja { get; set; }
        public string Adresa { get; set; }
        public string Grad { get; set; }
        public string Drzava { get; set; }
        public string Telefon { get; set; }
        public string StručnaSprema { get; set; }
        public float Olaksica { get; set; }
        public string DatumDolaska { get; set; }
        public string DatumOdlaska { get; set; }
    }
}
