﻿using Knjigovodstvo.Database;
using Knjigovodstvo.Models;
using Knjigovodstvo.Settings;
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
                iznos -= Mio_1 = iznos * (p.GetStopaByName(PlacaStope.Mio_1) + p.GetStopaByName(PlacaStope.Mio_2));
                Mio_2 = 0;
            }
            else
            {
                Mio_1 = iznos * p.GetStopaByName(PlacaStope.Mio_1);
                Mio_2 = iznos * p.GetStopaByName(PlacaStope.Mio_2);
                iznos -= Mio_1 + Mio_2;
            }
            Dohodak = iznos;
            iznos -= Osobni_Odbitak = 2500.0f * (1.6f + odbitak);
            Porezna_Osnovica = iznos;

            if (Porezna_Osnovica > 30000)
            {
                iznos -= Porez_24_per = 30000.0f * p.GetStopaByName(PlacaStope.Porez_Dohodak_24);
                iznos -= Porez_36_per = (Porezna_Osnovica - 30000) * p.GetStopaByName(PlacaStope.Porez_Dohodak_36);
            }
            else
            {
                iznos -= Porez_24_per = Porezna_Osnovica * p.GetStopaByName(PlacaStope.Porez_Dohodak_24);
                Porez_36_per = 0;
            }
            iznos -= Prirez = ( Porez_Ukupno = Porez_24_per + Porez_36_per) * prirez;
            Ukupno_Porez_i_Prirez = Porez_Ukupno + Prirez;
            Neto = iznos + Osobni_Odbitak;

            Doprinos_Zdravstvo = Bruto * p.GetStopaByName(PlacaStope.Doprinos_Zdravstveno);


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
                Mio_1 = float.Parse(data.Rows[0][3].ToString());
                Mio_2 = float.Parse(data.Rows[0][4].ToString());
                Dohodak = float.Parse(data.Rows[0][5].ToString());
                Osobni_Odbitak = float.Parse(data.Rows[0][6].ToString());
                Porezna_Osnovica = float.Parse(data.Rows[0][7].ToString());
                Porez_24_per = float.Parse(data.Rows[0][8].ToString());
                Porez_36_per = float.Parse(data.Rows[0][9].ToString());
                Porez_Ukupno = float.Parse(data.Rows[0][10].ToString());
                Prirez = float.Parse(data.Rows[0][11].ToString());
                Ukupno_Porez_i_Prirez = float.Parse(data.Rows[0][12].ToString());
                Neto = float.Parse(data.Rows[0][13].ToString());
                Doprinos_Zdravstvo = float.Parse(data.Rows[0][14].ToString());
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
        public float Mio_1 { get; set; } = 0;
        public float Mio_2 { get; set; } = 0;
        public float Dohodak { get; set; } = 0;
        public float Osobni_Odbitak { get; set; } = 0;
        public float Porezna_Osnovica { get; set; } = 0;
        public float Porez_24_per { get; set; } = 0;
        public float Porez_36_per { get; set; } = 0;
        public float Porez_Ukupno { get; set; } = 0;
        public float Prirez { get; set; } = 0;
        public float Ukupno_Porez_i_Prirez { get; set; } = 0;
        public float Neto { get; set; } = 0;
        public float Doprinos_Zdravstvo { get; set; } = 0;
    }
}
