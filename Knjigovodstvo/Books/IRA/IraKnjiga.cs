using Knjigovodstvo.Database;
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
            Porezna_osnovica_0_per = decimal.Parse(val[14]);
            Porezna_osnovica_5_per = decimal.Parse(val[15]);
            PDV_5_per = decimal.Parse(val[16]);
            Porezna_osnovica_10_per = decimal.Parse(val[17]);
            PDV_10_per = decimal.Parse(val[18]);
            Porezna_osnovica_13_per = decimal.Parse(val[19]);
            PDV_13_per = decimal.Parse(val[20]);
            Porezna_osnovica_23_per = decimal.Parse(val[21]);
            PDV_23_per = decimal.Parse(val[22]);
            Porezna_osnovica_25_per = decimal.Parse(val[23]);
            PDV_25_per = decimal.Parse(val[24]);
            Ukupni_PDV = decimal.Parse(val[25]);
            Ukupno_uplaceno = decimal.Parse(val[26]);
            Preostalo_za_uplatit = decimal.Parse(val[27]);
            Napomena_o_racunu = val[28];
            Zaprimljen_u_HZZO = val[29] == "" ? "Null" : DateTime.ParseExact(val[29], ("dd.MM.yyyy"), CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            Dana_od_zaprimanja = int.Parse(val[30]);
            Dana_neplacanja = int.Parse(val[31]);

            return this;
        }

        internal void GetDataFromDatabaseByRedniBroj()
        {
            var row = new DbDataGet().GetTable(this, $"Redni_broj={Redni_broj}").Rows[0];

            Redni_broj = int.Parse(row["Redni_broj"].ToString());
            Broj_racuna = row["Broj_racuna"].ToString();
            Storno = row["Storno"].ToString() == "1";
            Iz_racuna = int.Parse(row["Iz_racuna"].ToString());
            Datum = row["Datum"].ToString();
            Dospijece = row["Dospijece"].ToString();
            Datum_zadnje_uplate = row["Datum_zadnje_uplate"].ToString();
            Naziv_i_sjediste_kupca = row["Naziv_i_sjediste_kupca"].ToString();
            OIB = row["OIB"].ToString();
            Iznos_s_PDVom = decimal.Parse(row["Iznos_s_PDVom"].ToString());
            Oslobodjeno_PDVa_EU = decimal.Parse(row["Oslobodjeno_PDVa_EU"].ToString());
            Oslobodjeno_PDVa_ostalo = decimal.Parse(row["Oslobodjeno_PDVa_ostalo"].ToString());
            Prolazna_stavka = decimal.Parse(row["Prolazna_stavka"].ToString());
            Porezna_osnovica_0_per = decimal.Parse(row["Porezna_osnovica_0_per"].ToString());
            Porezna_osnovica_5_per = decimal.Parse(row["Porezna_osnovica_5_per"].ToString());
            PDV_5_per = decimal.Parse(row["PDV_5_per"].ToString());
            Porezna_osnovica_10_per = decimal.Parse(row["Porezna_osnovica_10_per"].ToString());
            PDV_10_per = decimal.Parse(row["PDV_10_per"].ToString());
            Porezna_osnovica_13_per = decimal.Parse(row["Porezna_osnovica_13_per"].ToString());
            PDV_13_per = decimal.Parse(row["PDV_13_per"].ToString());
            Porezna_osnovica_23_per = decimal.Parse(row["Porezna_osnovica_23_per"].ToString());
            PDV_23_per = decimal.Parse(row["PDV_23_per"].ToString());
            Porezna_osnovica_25_per = decimal.Parse(row["Porezna_osnovica_25_per"].ToString());
            PDV_25_per = decimal.Parse(row["PDV_25_per"].ToString());
            Ukupni_PDV = decimal.Parse(row["Ukupni_PDV"].ToString());
            Ukupno_uplaceno = decimal.Parse(row["Ukupno_uplaceno"].ToString());
            Preostalo_za_uplatit = decimal.Parse(row["Preostalo_za_uplatit"].ToString());
            Napomena_o_racunu = row["Napomena_o_racunu"].ToString();
            Zaprimljen_u_HZZO = row["Zaprimljen_u_HZZO"].ToString();
            Dana_od_zaprimanja = int.Parse(row["Dana_od_zaprimanja"].ToString());
            Dana_neplacanja = int.Parse(row["Dana_neplacanja"].ToString());
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
        public decimal Porezna_osnovica_0_per { get; set; } = 0;
        public decimal Porezna_osnovica_5_per { get; set; } = 0;
        public decimal PDV_5_per { get; set; } = 0;
        public decimal Porezna_osnovica_10_per { get; set; } = 0;
        public decimal PDV_10_per { get; set; } = 0;
        public decimal Porezna_osnovica_13_per { get; set; } = 0;
        public decimal PDV_13_per { get; set; } = 0;
        public decimal Porezna_osnovica_23_per { get; set; } = 0;
        public decimal PDV_23_per { get; set; } = 0;
        public decimal Porezna_osnovica_25_per { get; set; } = 0;
        public decimal PDV_25_per { get; set; } = 0;
        public decimal Ukupni_PDV { get; set; } = 0;
        public decimal Ukupno_uplaceno { get; set; } = 0;
        public decimal Preostalo_za_uplatit { get; set; } = 0;
        public string Napomena_o_racunu { get; set; } = "";
        public string Zaprimljen_u_HZZO { get; set; } = "";
        public int Dana_od_zaprimanja { get; set; } = 0;
        public int Dana_neplacanja { get; set; } = 0;
    }
}
