using Knjigovodstvo.Database;
using Knjigovodstvo.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace Knjigovodstvo.URA
{
    public class KnjigaUra : IDbObject
    {
        public KnjigaUra FromCsv(string line)
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
            Porezna_osnovica_0_per = decimal.Parse(val[19]);
            Porezna_osnovica_5_per = decimal.Parse(val[20]);
            Pretporez_za_T5 = decimal.Parse(val[21]);
            Porezna_osnovica_10_per = decimal.Parse(val[22]);
            Pretporez_za_T10 = decimal.Parse(val[23]);
            Porezna_osnovica_13_per = decimal.Parse(val[24]);
            Pretporez_za_T13 = decimal.Parse(val[25]);
            Porezna_osnovica_23_per = decimal.Parse(val[26]);
            Pretporez_za_T23 = decimal.Parse(val[27]);
            Porezna_osnovica_25_per = decimal.Parse(val[28]);
            Pretporez_za_T25 = decimal.Parse(val[29]);
            Ukupni_pretporez = decimal.Parse(val[30]);
            Moze_se_odbiti = decimal.Parse(val[31]);
            Ne_moze_se_odbiti = decimal.Parse(val[32]);
            Iznos_bez_poreza = decimal.Parse(val[33]);
            Prolazna_stavka = decimal.Parse(val[34]);
            Neoporezivo = decimal.Parse(val[35]);
            Cassa_per = decimal.Parse(val[36]);
            Cassa_sconto = decimal.Parse(val[37]);
            Broj_odobrenja = val[38];
            Odobrenja_bez_PDVa = val[39];
            Odobreni_PDV = decimal.Parse(val[40]);
            Datum_podnosenja = val[41] == "" ? "Null" : DateTime.ParseExact(val[41], ("dd.MM.yyyy"), CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            Datum_izvrsenja = val[42] == "" ? "Null" : DateTime.ParseExact(val[42], ("dd.MM.yyyy"), CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            Ukupno_uplaceno = decimal.Parse(val[43]);
            Preostalo_za_uplatit = decimal.Parse(val[44]);
            Dospijece_dana = int.Parse(val[45]);

            return this;
        }

        public void GetDataFromDatabaseByRedniBroj()
        {
            var datatable = _dataGet.GetTable(this, $"Redni_broj={Redni_broj}");
            FillData(datatable.Rows[0]);
        }

        public void FillData(DataRow row)
        {
            Datum = row["Datum"].ToString();
            Broj_racuna = row["Broj_racuna"].ToString();
            Storno = row["Storno"].ToString() == "1";
            Storno_broja = int.Parse(row["Storno_broja"].ToString());
            Datum_racuna = row["Datum_racuna"].ToString();
            Starost_racuna = int.Parse(row["Starost_racuna"].ToString());
            Dospijece = row["Dospijece"].ToString();
            Planirana_uplata = decimal.Parse(row["Planirana_uplata"].ToString());
            Datum_uplate = row["Datum_uplate"].ToString();
            Za_uplatu = decimal.Parse(row["Za_uplatu"].ToString());
            Naziv_dobavljaca = row["Naziv_dobavljaca"].ToString();
            Broj_primke = int.Parse(row["Broj_primke"].ToString());
            Napomena_o_racunu = row["Napomena_o_racunu"].ToString();
            Netto_nabavna_vrijednost = decimal.Parse(row["Netto_nabavna_vrijednost"].ToString());
            Sjedište_dobavljaca = row["Sjedište_dobavljaca"].ToString();
            OIB = row["OIB"].ToString();
            Iznos_s_porezom = decimal.Parse(row["Iznos_s_porezom"].ToString());
            Porezna_osnovica_0_per = decimal.Parse(row["Porezna_osnovica_0_per"].ToString());
            Porezna_osnovica_5_per = decimal.Parse(row["Porezna_osnovica_5_per"].ToString());
            Pretporez_za_T5 = decimal.Parse(row["Pretporez_za_T5"].ToString());
            Porezna_osnovica_10_per = decimal.Parse(row["Porezna_osnovica_10_per"].ToString());
            Pretporez_za_T10 = decimal.Parse(row["Pretporez_za_T10"].ToString());
            Porezna_osnovica_13_per = decimal.Parse(row["Porezna_osnovica_13_per"].ToString());
            Pretporez_za_T13 = decimal.Parse(row["Pretporez_za_T13"].ToString());
            Porezna_osnovica_23_per = decimal.Parse(row["Porezna_osnovica_23_per"].ToString());
            Pretporez_za_T23 = decimal.Parse(row["Pretporez_za_T23"].ToString());
            Porezna_osnovica_25_per = decimal.Parse(row["Porezna_osnovica_25_per"].ToString());
            Pretporez_za_T25 = decimal.Parse(row["Pretporez_za_T25"].ToString());
            Ukupni_pretporez = decimal.Parse(row["Ukupni_pretporez"].ToString());
            Moze_se_odbiti = decimal.Parse(row["Moze_se_odbiti"].ToString());
            Ne_moze_se_odbiti = decimal.Parse(row["Ne_moze_se_odbiti"].ToString());
            Iznos_bez_poreza = decimal.Parse(row["Iznos_bez_poreza"].ToString());
            Prolazna_stavka = decimal.Parse(row["Prolazna_stavka"].ToString());
            Neoporezivo = decimal.Parse(row["Neoporezivo"].ToString());
            Cassa_per = decimal.Parse(row["Cassa_per"].ToString());
            Cassa_sconto = decimal.Parse(row["Cassa_sconto"].ToString());
            Broj_odobrenja = row["Broj_odobrenja"].ToString();
            Odobrenja_bez_PDVa = row["Odobrenja_bez_PDVa"].ToString();
            Odobreni_PDV = decimal.Parse(row["Odobreni_PDV"].ToString());
            Datum_podnosenja = row["Datum_podnosenja"].ToString();
            Datum_izvrsenja = row["Datum_izvrsenja"].ToString();
            Ukupno_uplaceno = decimal.Parse(row["Ukupno_uplaceno"].ToString());
            Preostalo_za_uplatit = decimal.Parse(row["Preostalo_za_uplatit"].ToString());
            Dospijece_dana = int.Parse(row["Dospijece_dana"].ToString());
            Knjizen = row["Knjizen"].ToString() == "1";
        }

        public FormError ValidateData()
        {
            throw new NotImplementedException();
        }

        private DbDataGet _dataGet = new DbDataGet();

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
        public decimal Porezna_osnovica_0_per { get; set; } = 0;
        public decimal Porezna_osnovica_5_per { get; set; } = 0;
        public decimal Pretporez_za_T5 { get; set; } = 0;
        public decimal Porezna_osnovica_10_per { get; set; } = 0;
        public decimal Pretporez_za_T10 { get; set; } = 0;
        public decimal Porezna_osnovica_13_per { get; set; } = 0;
        public decimal Pretporez_za_T13 { get; set; } = 0;
        public decimal Porezna_osnovica_23_per { get; set; } = 0;
        public decimal Pretporez_za_T23 { get; set; } = 0;
        public decimal Porezna_osnovica_25_per { get; set; } = 0;
        public decimal Pretporez_za_T25 { get; set; } = 0;
        public decimal Ukupni_pretporez { get; set; } = 0;
        public decimal Moze_se_odbiti { get; set; } = 0;
        public decimal Ne_moze_se_odbiti { get; set; } = 0;
        public decimal Iznos_bez_poreza { get; set; } = 0;
        public decimal Prolazna_stavka { get; set; } = 0;
        public decimal Neoporezivo { get; set; } = 0;
        public decimal Cassa_per { get; set; } = 0;
        public decimal Cassa_sconto { get; set; } = 0;
        public string Broj_odobrenja { get; set; } = "";
        public string Odobrenja_bez_PDVa { get; set; } = "";
        public decimal Odobreni_PDV { get; set; } = 0;
        public string Datum_podnosenja { get; set; } = "";
        public string Datum_izvrsenja { get; set; } = "";
        public decimal Ukupno_uplaceno { get; set; } = 0;
        public decimal Preostalo_za_uplatit { get; set; } = 0;
        public int Dospijece_dana { get; set; } = 0;
        public bool Knjizen { get; set; } = false;
    }
}
