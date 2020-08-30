using System;
using System.Collections.Generic;
using System.Text;

namespace Knjigovodstvo
{
    class Partner
    {
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
