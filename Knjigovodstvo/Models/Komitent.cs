using System;
using System.Collections.Generic;
using System.Text;

namespace Knjigovodstvo
{
    class Komitent
    {
        //TODO Make validations for data
        public int Oib { get; set; }
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
