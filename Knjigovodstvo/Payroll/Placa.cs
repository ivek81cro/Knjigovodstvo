using Knjigovodstvo.Database;
using Knjigovodstvo.Models;
using Knjigovodstvo.Settings;
using System.Data;

namespace Knjigovodstvo.Payroll
{
    public class Placa : IDbObject
    {
        public FormError ValidateData() 
        {
            //TODO validate Placa data
            return FormError.None;
        }

        public Placa Izracun(decimal bruto, decimal prirez, decimal dodaci, decimal odbitak, bool drugi = false)
        {
            Postavke p = new Postavke();
            decimal iznos = bruto;
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
            iznos -= Osobni_Odbitak = 2500.0m * (1.6m + odbitak);
            Porezna_Osnovica = iznos;

            if (Porezna_Osnovica > 30000)
            {
                iznos -= Porez_24_per = 30000.0m * p.GetStopaByName(PlacaStope.Porez_Dohodak_24);
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
            Dodaci_Ukupno = dodaci;


            return this;
        }

        public Placa GetPlacaByOib(string oib) 
        {
            DataTable data = new DbDataGet().GetTable(this, $"Oib='{oib}'");
            try
            {
                Id = int.Parse(data.Rows[0]["Id"].ToString());
                Oib = data.Rows[0]["Oib"].ToString();
                Bruto = decimal.Parse(data.Rows[0]["Bruto"].ToString());
                Mio_1 = decimal.Parse(data.Rows[0]["Mio_1"].ToString());
                Mio_2 = decimal.Parse(data.Rows[0]["Mio_2"].ToString());
                Dohodak = decimal.Parse(data.Rows[0]["Dohodak"].ToString());
                Osobni_Odbitak = decimal.Parse(data.Rows[0]["Osobni_Odbitak"].ToString());
                Porezna_Osnovica = decimal.Parse(data.Rows[0]["Porezna_Osnovica"].ToString());
                Porez_24_per = decimal.Parse(data.Rows[0]["Porez_24_per"].ToString());
                Porez_36_per = decimal.Parse(data.Rows[0]["Porez_36_per"].ToString());
                Porez_Ukupno = decimal.Parse(data.Rows[0]["Porez_Ukupno"].ToString());
                Prirez = decimal.Parse(data.Rows[0]["Prirez"].ToString());
                Ukupno_Porez_i_Prirez = decimal.Parse(data.Rows[0]["Ukupno_Porez_i_Prirez"].ToString());
                Neto = decimal.Parse(data.Rows[0]["Neto"].ToString());
                Doprinos_Zdravstvo = decimal.Parse(data.Rows[0]["Doprinos_Zdravstvo"].ToString());
                Dodaci_Ukupno = decimal.Parse(data.Rows[0]["Dodaci_Ukupno"].ToString());
            }
            catch
            {
                Oib = "0";
            }

            return this;
        }

        public int Id { get; set; } = 0;
        public string Oib { get; set; } = "";
        public decimal Bruto { get; set; } = 0;
        public decimal Mio_1 { get; set; } = 0;
        public decimal Mio_2 { get; set; } = 0;
        public decimal Dohodak { get; set; } = 0;
        public decimal Osobni_Odbitak { get; set; } = 0;
        public decimal Porezna_Osnovica { get; set; } = 0;
        public decimal Porez_24_per { get; set; } = 0;
        public decimal Porez_36_per { get; set; } = 0;
        public decimal Porez_Ukupno { get; set; } = 0;
        public decimal Prirez { get; set; } = 0;
        public decimal Ukupno_Porez_i_Prirez { get; set; } = 0;
        public decimal Neto { get; set; } = 0;
        public decimal Doprinos_Zdravstvo { get; set; } = 0;
        public decimal Dodaci_Ukupno { get; set; } = 0;
    }
}
