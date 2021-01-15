using Knjigovodstvo.Database;
using Knjigovodstvo.Interface;
using System;
using System.Globalization;

namespace Knjigovodstvo.URA
{
    public class PrimkaRepro : IDbObject
    {
        public FormError ValidateData()
        {
            throw new NotImplementedException();
        }

        public PrimkaRepro FromCsv(string line)
        {
            string[] val = line.Split(';');

            Redni_broj = int.Parse(val[0]);
            Datum_knjizenja = DateTime.ParseExact(val[1].Split(' ')[0], "dd.MM.yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            Broj_primke = int.Parse(val[2]);
            Storno = val[3] == "*";
            Netto_nabavna_vr = decimal.Parse(val[4]);
            Naziv_dobavljaca = val[5];
            Broj_racuna = val[6];
            Fakturna_vrijednost = decimal.Parse(val[7]);
            Datum_racuna = DateTime.ParseExact(val[8].Split(' ')[0], "dd.MM.yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            Otpremnica = val[9] == "DA";
            Dospijece_placanja = DateTime.ParseExact(val[10].Split(' ')[0], "dd.MM.yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            Nabavna_vrijednost = decimal.Parse(val[11]);
            Rabat = decimal.Parse(val[12]);
            Pretporez = decimal.Parse(val[13]);
            Veleprodajni_rabat = decimal.Parse(val[14]);
            Cassa_sc = decimal.Parse(val[15]);
            Porezni_broj = val[16];
            Broj_u_knjizi_ura = int.Parse(val[17]);

            return this;
        }

        internal void GetDataFromDatabaseByUraBroj()
        {
            var row = new DbDataGet().GetTable(this, $"Broj_u_knjizi_ura={Broj_u_knjizi_ura}").Rows[0];

            Redni_broj = int.Parse(row["Redni_broj"].ToString());
            Datum_knjizenja = row["Datum_knjizenja"].ToString();
            Broj_primke = int.Parse(row["Broj_primke"].ToString());
            Storno = row["Storno"].ToString() == "1";
            Netto_nabavna_vr = decimal.Parse(row["Netto_nabavna_vr"].ToString());
            Naziv_dobavljaca = row["Naziv_dobavljaca"].ToString();
            Broj_racuna = row["Broj_racuna"].ToString();
            Datum_racuna = row["Datum_racuna"].ToString();
            Otpremnica = row["Otpremnica"].ToString() == "1";
            Dospijece_placanja = row["Dospijece_placanja"].ToString();
            Fakturna_vrijednost = decimal.Parse(row["Fakturna_vrijednost"].ToString());
            Nabavna_vrijednost = decimal.Parse(row["Nabavna_vrijednost"].ToString());
            Pretporez = decimal.Parse(row["Pretporez"].ToString());
            Veleprodajni_rabat = decimal.Parse(row["Veleprodajni_rabat"].ToString());
            Rabat = decimal.Parse(row["Rabat"].ToString());
            Cassa_sc = decimal.Parse(row["Cassa_sc"].ToString());
            Porezni_broj = row["Porezni_broj"].ToString();
            Broj_u_knjizi_ura = int.Parse(row["Broj_u_knjizi_ura"].ToString());
        }

        public int Redni_broj { get; set; } = 0;
        public string Datum_knjizenja { get; set; } = "";
        public int Broj_primke { get; set; } = 0;
        public bool Storno { get; set; } = false;
        public decimal Netto_nabavna_vr { get; set; } = 0;
        public string Naziv_dobavljaca { get; set; } = "";
        public string Broj_racuna { get; set; } = "";
        public decimal Fakturna_vrijednost { get; set; } = 0;
        public string Datum_racuna { get; set; } = "";
        public bool Otpremnica { get; set; } = false;
        public string Dospijece_placanja { get; set; } = "";
        public decimal Nabavna_vrijednost { get; set; } = 0;
        public decimal Rabat { get; set; } = 0;
        public decimal Pretporez { get; set; } = 0;
        public decimal Veleprodajni_rabat { get; set; } = 0;
        public decimal Cassa_sc { get; set; } = 0;
        public string Porezni_broj { get; set; } = "";
        public int Broj_u_knjizi_ura { get; set; } = 0;
    }
}
