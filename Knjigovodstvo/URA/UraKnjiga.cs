using Knjigovodstvo.Interface;
using System;
using System.Globalization;

namespace Knjigovodstvo.URA
{
    class UraKnjiga : IDbObject
    {
        public UraKnjiga FromCsv(string line)
        {
            string[] val = line.Split(';');

            Redni_broj = int.Parse(val[1]);
            Datum = DateTime.ParseExact(val[2], ("dd.MM.yyyy"), CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            Broj_racuna = val[3];
            Storno = val[4] == "*";
            Storno_broja = int.Parse(val[5]);
            Datum_racuna = DateTime.ParseExact(val[6], ("dd.MM.yyyy"), CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            Starost_racuna = int.Parse(val[7]);
            Dospijece = DateTime.ParseExact(val[8], ("dd.MM.yyyy"), CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            Planirana_uplata = val[9] == "" ? 0 : decimal.Parse(val[9]);
            Datum_uplate = val[10] == "" ? "Null" : DateTime.ParseExact(val[10], ("dd.MM.yyyy"), CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            Za_uplatu = decimal.Parse(val[11]);
            Naziv_dobavljaca = val[12];
            Broj_primke = int.Parse(val[13]);
            Napomena_o_racunu = val[14];
            Netto_nabavna_vrijednost = decimal.Parse(val[15]);
            Sjedište_dobavljaca = val[16];
            OIB = val[17];
            Iznos_s_porezom = decimal.Parse(val[18]);
            Porezna_osnovica_0perc = decimal.Parse(val[19]);
            Porezna_osnovica_5perc = decimal.Parse(val[20]);
            Pretporez_za_T5 = decimal.Parse(val[21]);
            Porezna_osnovica_10perc = decimal.Parse(val[22]);
            Pretporez_za_T10 = decimal.Parse(val[23]);
            Porezna_osnovica_13perc = decimal.Parse(val[24]);
            Pretporez_za_T13 = decimal.Parse(val[25]);
            Porezna_osnovica_23perc = decimal.Parse(val[26]);
            Pretporez_za_T23 = decimal.Parse(val[27]);
            Porezna_osnovica_25perc = decimal.Parse(val[28]);
            Pretporez_za_T25 = decimal.Parse(val[29]);
            Ukupni_pretporez = decimal.Parse(val[30]);
            Moze_se_odbiti = decimal.Parse(val[31]);
            Ne_moze_se_odbiti = decimal.Parse(val[32]);
            Iznos_bez_poreza = decimal.Parse(val[33]);
            Prolazna_stavka = decimal.Parse(val[34]);
            Neoporezivo = decimal.Parse(val[35]);
            Cassa_perc = decimal.Parse(val[36]);
            Cassa_sconto = decimal.Parse(val[37]);
            Broj_odobrenja = val[38];
            Odobrenje_bez_PDVa = decimal.Parse(val[39]);
            Odobreni_PDV = decimal.Parse(val[40]);
            Datum_podnosenja = val[41] == "" ? "Null" : DateTime.ParseExact(val[41], ("dd.MM.yyyy"), CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            Datum_izvrsenja = val[42] == "" ? "Null" : DateTime.ParseExact(val[42], ("dd.MM.yyyy"), CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            Ukupno_uplaceno = decimal.Parse(val[43]);
            Preostalo_za_uplatit = decimal.Parse(val[44]);
            Dospijece_dana = int.Parse(val[45]);

            return this;
        }

        public FormError ValidateData()
        {
            throw new System.NotImplementedException();
        }

        public int Redni_broj { get; set; } = 0;
        public string Datum { get; set; } = "";
        public string Broj_racuna { get; set; } = "";
        public bool Storno { get; set; }
        public int Storno_broja { get; set; } = 0;
        public string Datum_racuna { get; set; } = "";
        public int Starost_racuna { get; set; } = 0;
        public string Dospijece { get; set; } = "";
        public decimal Planirana_uplata { get; set; } = 0;
        public string Datum_uplate { get; set; } = "";
        public decimal Za_uplatu { get; set; } = 0;
        public string Naziv_dobavljaca { get; set; } = "";
        public int Broj_primke { get; set; } = 0;
        public string Napomena_o_racunu { get; set; } = "";
        public decimal Netto_nabavna_vrijednost { get; set; } = 0;
        public string Sjedište_dobavljaca { get; set; } = "";
        public string OIB { get; set; } = "";
        public decimal Iznos_s_porezom { get; set; } = 0;
        public decimal Porezna_osnovica_0perc { get; set; } = 0;
        public decimal Porezna_osnovica_5perc { get; set; } = 0;
        public decimal Pretporez_za_T5 { get; set; } = 0;
        public decimal Porezna_osnovica_10perc { get; set; } = 0;
        public decimal Pretporez_za_T10 { get; set; } = 0;
        public decimal Porezna_osnovica_13perc { get; set; } = 0;
        public decimal Pretporez_za_T13 { get; set; } = 0;
        public decimal Porezna_osnovica_23perc { get; set; } = 0;
        public decimal Pretporez_za_T23 { get; set; } = 0;
        public decimal Porezna_osnovica_25perc { get; set; } = 0;
        public decimal Pretporez_za_T25 { get; set; } = 0;
        public decimal Ukupni_pretporez { get; set; } = 0;
        public decimal Moze_se_odbiti { get; set; } = 0;
        public decimal Ne_moze_se_odbiti { get; set; } = 0;
        public decimal Iznos_bez_poreza { get; set; } = 0;
        public decimal Prolazna_stavka { get; set; } = 0;
        public decimal Neoporezivo { get; set; } = 0;
        public decimal Cassa_perc { get; set; } = 0;
        public decimal Cassa_sconto { get; set; } = 0;
        public string Broj_odobrenja { get; set; } = "";
        public decimal Odobrenje_bez_PDVa { get; set; } = 0;
        public decimal Odobreni_PDV { get; set; } = 0;
        public string Datum_podnosenja { get; set; } = "";
        public string Datum_izvrsenja { get; set; } = "";
        public decimal Ukupno_uplaceno { get; set; } = 0;
        public decimal Preostalo_za_uplatit { get; set; } = 0;
        public int Dospijece_dana { get; set; } = 0;
    }
}
