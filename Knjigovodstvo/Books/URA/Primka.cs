using Knjigovodstvo.Interface;
using System;
using System.Globalization;

namespace Knjigovodstvo.URA
{
    class Primka : IDbObject
    {
        public FormError ValidateData()
        {
            throw new NotImplementedException();
        }

        public Primka FromCsv(string line)
        {
            string[] val = line.Split(';');

            Redni_broj = int.Parse(val[0]);
            Datum_knjizenja = DateTime.ParseExact(val[1], ("dd.MM.yyyy"), CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            Broj_primke = int.Parse(val[2]);
            Storno = val[3] == "*" ? true : false;
            Maloprodajna_vrijednost = decimal.Parse(val[4]);
            Naziv_dobavljaca = val[5];
            Broj_racuna = val[6];
            Datum_racuna = DateTime.ParseExact(val[7], ("dd.MM.yyyy"), CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            Otpremnica = val[8] == "DA" ? true : false;
            Dospijece_placanja = DateTime.ParseExact(val[9], ("dd.MM.yyyy"), CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            Fakturna_vrijednost = decimal.Parse(val[10]);
            Maloprodajna_marza = decimal.Parse(val[11]);
            Iznos_pdv = decimal.Parse(val[12]);
            Vrijednost_bez_poreza = decimal.Parse(val[13]);
            Nabavna_vrijednost = decimal.Parse(val[14]);
            Maloprodajni_rabat = decimal.Parse(val[15]);
            Netto_nabavna_vrijednost = decimal.Parse(val[16]);
            Pretporez = decimal.Parse(val[17]);
            Veleprodajni_rabat = decimal.Parse(val[18]);
            Cassa_sconto = decimal.Parse(val[19]);
            Netto_ruc = decimal.Parse(val[20]);
            Povratna_naknada = decimal.Parse(val[21]);
            Porezni_broj = val[22];
            Broj_u_knjizi_ura = int.Parse(val[23]);

            return this;
        }

        public int Redni_broj { get; set; } = 0;
        public string Datum_knjizenja { get; set; } = "";
        public int Broj_primke { get; set; } = 0;
        public bool Storno { get; set; }
        public decimal Maloprodajna_vrijednost { get; set; } = 0;
        public string Naziv_dobavljaca { get; set; } = "";
        public string Broj_racuna { get; set; } = "";
        public string Datum_racuna { get; set; } = "";
        public bool Otpremnica { get; set; }
        public string Dospijece_placanja { get; set; } = "";
        public decimal Fakturna_vrijednost { get; set; } = 0;
        public decimal Maloprodajna_marza { get; set; } = 0;
        public decimal Iznos_pdv { get; set; } = 0;
        public decimal Vrijednost_bez_poreza { get; set; } = 0;
        public decimal Nabavna_vrijednost { get; set; } = 0;
        public decimal Maloprodajni_rabat { get; set; } = 0;
        public decimal Netto_nabavna_vrijednost { get; set; } = 0;
        public decimal Pretporez { get; set; } = 0;
        public decimal Veleprodajni_rabat { get; set; } = 0;
        public decimal Cassa_sconto { get; set; } = 0;
        public decimal Netto_ruc { get; set; } = 0;
        public decimal Povratna_naknada { get; set; } = 0;
        public string Porezni_broj { get; set; } = "";
        public int Broj_u_knjizi_ura { get; set; } = 0;
    }
}
