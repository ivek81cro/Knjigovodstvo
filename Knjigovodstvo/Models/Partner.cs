using Knjigovodstvo.Code.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Knjigovodstvo
{
    class Partner
    {
        public bool ValidateData()
        {
            IbanValidator iban = new IbanValidator();
            if (iban.Validate(Iban))
                return false;

            OibValidator oib = new OibValidator();
            if (oib.Validate(Oib))
                return false;

            //TODO Validate Post, MBO and checkboxes

            return true;
        }

        public bool InsertNew()
        {
            //TODO Insert new partner into db
            return true;
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
        public bool Kupac { get; set; }
        public bool Dobavljac { get; set; }
    }

}
