using Knjigovodstvo.Interface;
using System;
using System.Globalization;

namespace Knjigovodstvo.IRA
{
    class IraKnjiga : IDbObject
    {
        public FormError ValidateData()
        {
            throw new NotImplementedException();
        }

        public IraKnjiga FromCsv(string line)
        {
            string[] val = line.Split(';');

            Redni_broj = int.Parse(val[1]);
            Broj_racuna = val[2];
            Storno = val[3] == "*";
            Iz_racuna = int.Parse(val[4]);
            Datum = DateTime.ParseExact(val[5], ("dd.MM.yyyy"), CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            Dospijece = DateTime.ParseExact(val[6], ("dd.MM.yyyy"), CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            Datum_zadnje_uplate = val[7] == "" ? "Null" : DateTime.ParseExact(val[7], ("dd.MM.yyyy"), CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            Naziv_i_sjediste_kupca = val[8];
            OIB = val[9];
            Iznos_s_PDVom = decimal.Parse(val[10]);
            Oslobodjeno_PDVa_EU = decimal.Parse(val[11]);
            Oslobodjeno_PDVa_ostalo = decimal.Parse(val[12]);
            Prolazna_stavka = decimal.Parse(val[13]);
            Porezna_osnovica_0perc = decimal.Parse(val[14]);
            Porezna_osnovica_5perc = decimal.Parse(val[15]);
            PDV_5perc = decimal.Parse(val[16]);
            Porezna_osnovica_10perc = decimal.Parse(val[17]);
            PDV_10perc = decimal.Parse(val[18]);
            Porezna_osnovica_13perc = decimal.Parse(val[19]);
            PDV_13perc = decimal.Parse(val[20]);
            Porezna_osnovica_23perc = decimal.Parse(val[21]);
            PDV_23perc = decimal.Parse(val[22]);
            Porezna_osnovica_25perc = decimal.Parse(val[23]);
            PDV_25perc = decimal.Parse(val[24]);
            Ukupni_PDV = decimal.Parse(val[25]);
            Ukupno_uplaceno = decimal.Parse(val[26]);
            Preostalo_za_uplatit = decimal.Parse(val[27]);
            Napomana_o_racunu = val[28];
            Zaprimljen_u_HZZO = val[29] == "" ? "Null" : DateTime.ParseExact(val[29], ("dd.MM.yyyy"), CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            Dana_od_zaprimanja = int.Parse(val[30]);
            Dana_neplacanja = int.Parse(val[31]);

            return this;
        }

        public int Redni_broj { get; set; } = 0;
        public string Broj_racuna { get; set; } = "";
        public bool Storno { get; set; }
        public int Iz_racuna { get; set; } = 0;
        public string Datum { get; set; } = "";
        public string Dospijece { get; set; } = "";
        public string Datum_zadnje_uplate { get; set; } = "";
        public string Naziv_i_sjediste_kupca { get; set; } = "";
        public string OIB { get; set; } = "";
        public decimal Iznos_s_PDVom { get; set; } = 0;
        public decimal Oslobodjeno_PDVa_EU { get; set; } = 0;
        public decimal Oslobodjeno_PDVa_ostalo { get; set; } = 0;
        public decimal Prolazna_stavka { get; set; } = 0;
        public decimal Porezna_osnovica_0perc { get; set; } = 0;
        public decimal Porezna_osnovica_5perc { get; set; } = 0;
        public decimal PDV_5perc { get; set; } = 0;
        public decimal Porezna_osnovica_10perc { get; set; } = 0;
        public decimal PDV_10perc { get; set; } = 0;
        public decimal Porezna_osnovica_13perc { get; set; } = 0;
        public decimal PDV_13perc { get; set; } = 0;
        public decimal Porezna_osnovica_23perc { get; set; } = 0;
        public decimal PDV_23perc { get; set; } = 0;
        public decimal Porezna_osnovica_25perc { get; set; } = 0;
        public decimal PDV_25perc { get; set; } = 0;
        public decimal Ukupni_PDV { get; set; } = 0;
        public decimal Ukupno_uplaceno { get; set; } = 0;
        public decimal Preostalo_za_uplatit { get; set; } = 0;
        public string Napomana_o_racunu { get; set; } = "";
        public string Zaprimljen_u_HZZO { get; set; } = "";
        public int Dana_od_zaprimanja { get; set; } = 0;
        public int Dana_neplacanja { get; set; } = 0;
    }
}
