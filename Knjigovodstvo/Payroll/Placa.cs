using Knjigovodstvo.Employee;
using Knjigovodstvo.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Knjigovodstvo.Payroll
{
    class Placa
    {
        public Placa Izracun(float bruto, float prirez, float odbitak, bool drugi = false)
        {
            Postavke p = new Postavke();
            float iznos = bruto;
            Bruto = iznos;
            if (drugi)
            {
                iznos -= Mio1 = iznos * (p.GetStopaByName(PlacaStope.Mio_1) + p.GetStopaByName(PlacaStope.Mio_2));
                Mio2 = 0;
            }
            else
            {
                Mio1 = iznos * p.GetStopaByName(PlacaStope.Mio_1);
                Mio2 = iznos * p.GetStopaByName(PlacaStope.Mio_2);
                iznos -= Mio1 + Mio2;
            }
            Dohodak = iznos;
            iznos -= OsobniOdbitak = 2500.0f * (1.6f + odbitak);
            PoreznaOsnovica = iznos;

            if (PoreznaOsnovica > 30000)
            {
                iznos -= Porez24 = 30000.0f * p.GetStopaByName(PlacaStope.Porez_Dohodak_24);
                iznos -= Porez36 = (PoreznaOsnovica - 30000) * p.GetStopaByName(PlacaStope.Porez_Dohodak_36);
            }
            else
            {
                iznos -= Porez24 = PoreznaOsnovica * p.GetStopaByName(PlacaStope.Porez_Dohodak_24);
                Porez36 = 0;
            }
            iznos -= Prirez = ( PorezUkupno = Porez24 + Porez36) * prirez;
            UkupnoPorezPrirez = PorezUkupno + Prirez;
            Neto = iznos + OsobniOdbitak;

            DoprinosZdravstvo = Bruto * p.GetStopaByName(PlacaStope.Doprinos_Zdravstveno);


            return this;
        }

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
