using Knjigovodstvo.Code.Validators;
using Knjigovodstvo.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Knjigovodstvo
{
    class Partner
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
            if (Kupac != 'k' && Dobavljac != 'd')
                return false;

            return true;
        }

        public bool InsertNew()
        {
            if(new DbDataInsert().InsertPartner(this))
                return true;

            return false;
        }

        public List<Partner> GetPartners(string name)
        {
            throw new NotImplementedException();
        }

        public int Id { get; set; }
        public string Oib { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Posta { get; set; }
        public string Grad { get; set; }
        public string Telefon { get; set; }
        public string Fax { get; set; }
        public string Mail { get; set; }
        public string Iban { get; set; }
        public string Mbo { get; set; }
        public char Kupac { get; set; }
        public char Dobavljac { get; set; }
    }

}
