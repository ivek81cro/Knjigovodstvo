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

            Redni_Broj = int.Parse(val[0]);
            Datum_Knjizenja = DateTime.ParseExact(val[1], ("dd.MM.yyyy"), CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            Broj_Primke = int.Parse(val[2]);
            Storno = val[3] == "*" ? true : false;
            Maloprodajna_Vrijednost = decimal.Parse(val[4]);
            Naziv_Dobavljaca = val[5];
            Broj_Racuna = val[6];
            Datum_Racuna = DateTime.ParseExact(val[7], ("dd.MM.yyyy"), CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            Otpremnica = val[8] == "DA" ? true : false;
            Dospijece_Placanja = DateTime.ParseExact(val[9], ("dd.MM.yyyy"), CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            Fakturna_Vrijednost = decimal.Parse(val[10]);
            Maloprodajna_Marza = decimal.Parse(val[11]);
            Iznos_Pdv = decimal.Parse(val[12]);
            Vrijednost_Bez_Poreza = decimal.Parse(val[13]);
            Nabavna_Vrijednost = decimal.Parse(val[14]);
            Maloprodajni_Rabat = decimal.Parse(val[15]);
            Netto_Nabavna_Vrijednost = decimal.Parse(val[16]);
            Pretporez = decimal.Parse(val[17]);
            Veleprodajni_Rabat = decimal.Parse(val[18]);
            Cassa_Sconto = decimal.Parse(val[19]);
            Netto_Ruc = decimal.Parse(val[20]);
            Povratna_Naknada = decimal.Parse(val[21]);
            Porezni_Broj = val[22];
            Broj_U_Knjizi_Ura = int.Parse(val[23]);

            return this;
        }

        public int Redni_Broj { get; set; } = 0;
        public string Datum_Knjizenja { get; set; } = "";
        public int Broj_Primke { get; set; } = 0;
        public bool Storno { get; set; }
        public decimal Maloprodajna_Vrijednost { get; set; } = 0;
        public string Naziv_Dobavljaca { get; set; } = "";
        public string Broj_Racuna { get; set; } = "";
        public string Datum_Racuna { get; set; } = "";
        public bool Otpremnica { get; set; }
        public string Dospijece_Placanja { get; set; } = "";
        public decimal Fakturna_Vrijednost { get; set; } = 0;
        public decimal Maloprodajna_Marza { get; set; } = 0;
        public decimal Iznos_Pdv { get; set; } = 0;
        public decimal Vrijednost_Bez_Poreza { get; set; } = 0;
        public decimal Nabavna_Vrijednost { get; set; } = 0;
        public decimal Maloprodajni_Rabat { get; set; } = 0;
        public decimal Netto_Nabavna_Vrijednost { get; set; } = 0;
        public decimal Pretporez { get; set; } = 0;
        public decimal Veleprodajni_Rabat { get; set; } = 0;
        public decimal Cassa_Sconto { get; set; } = 0;
        public decimal Netto_Ruc { get; set; } = 0;
        public decimal Povratna_Naknada { get; set; } = 0;
        public string Porezni_Broj { get; set; } = "";
        public int Broj_U_Knjizi_Ura { get; set; } = 0;
    }
}
