using System;
using System.Collections.Generic;
using System.Text;

namespace Knjigovodstvo.Models
{
    class Zaposlenik
    {
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
