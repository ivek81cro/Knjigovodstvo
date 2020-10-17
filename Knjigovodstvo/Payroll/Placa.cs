using System;
using System.Collections.Generic;
using System.Text;

namespace Knjigovodstvo.Payroll
{
    class Placa
    {
        public float Bruto { get; set; }
        public float Mio1 { get; set; }
        public float Mio2 { get; set; }
        public float Dohodak { get; set; }
        public float OsobniOdbitak { get; set; }
        public float PoreznaOsnovica { get; set; }
        public float Porez24 { get; set; }
        public float Porez36 { get; set; }
        public float PorezUkupno { get; set; }
        public float Prirez { get; set; }
        public float UkupnoPorezPrirez { get; set; }
        public float Neto { get; set; }
        public float DoprinosZdravstvo { get; set; }
    }
}
