using Knjigovodstvo.Helpers;
using Knjigovodstvo.Models;
using Knjigovodstvo.Settings;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Knjigovodstvo.Payroll
{
    class Placa : IDbObject
    {
        public FormError ValidateData() 
        {
            //TODO validate Placa data
            return FormError.None;
        }

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

        public Placa GetPlacaByOib(string oib) 
        {
            DataTable data = new DbDataGet().GetTable(this, $"Oib='{oib}'");
            try
            {
                Id = int.Parse(data.Rows[0][0].ToString());
                Oib = data.Rows[0][1].ToString();
                Bruto = float.Parse(data.Rows[0][2].ToString());
                Mio1 = float.Parse(data.Rows[0][3].ToString());
                Mio2 = float.Parse(data.Rows[0][4].ToString());
                Dohodak = float.Parse(data.Rows[0][5].ToString());
                OsobniOdbitak = float.Parse(data.Rows[0][6].ToString());
                PoreznaOsnovica = float.Parse(data.Rows[0][7].ToString());
                Porez24 = float.Parse(data.Rows[0][8].ToString());
                Porez36 = float.Parse(data.Rows[0][9].ToString());
                PorezUkupno = float.Parse(data.Rows[0][10].ToString());
                Prirez = float.Parse(data.Rows[0][11].ToString());
                UkupnoPorezPrirez = float.Parse(data.Rows[0][12].ToString());
                Neto = float.Parse(data.Rows[0][13].ToString());
                DoprinosZdravstvo = float.Parse(data.Rows[0][14].ToString());
            }
            catch
            {
                Oib = "0";
            }

            return this;
        }

        public int Id { get; set; } = 0;
        public string Oib { get; set; } = "";
        public float Bruto { get; set; } = 0;
        public float Mio1 { get; set; } = 0;
        public float Mio2 { get; set; } = 0;
        public float Dohodak { get; set; } = 0;
        public float OsobniOdbitak { get; set; } = 0;
        public float PoreznaOsnovica { get; set; } = 0;
        public float Porez24 { get; set; } = 0;
        public float Porez36 { get; set; } = 0;
        public float PorezUkupno { get; set; } = 0;
        public float Prirez { get; set; } = 0;
        public float UkupnoPorezPrirez { get; set; } = 0;
        public float Neto { get; set; } = 0;
        public float DoprinosZdravstvo { get; set; } = 0;
    }
}
