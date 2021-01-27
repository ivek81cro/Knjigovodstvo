using Knjigovodstvo.Database;
using Knjigovodstvo.Interface;
using System;
using System.Globalization;

namespace Knjigovodstvo
{
    public class PdvStavke : IDbObject
    {
        public FormError ValidateData()
        {
            return FormError.None;
        }

        public bool SaveToDatabase()
        {
            Datum_od = DateTime.ParseExact(Datum_od, "dd.MM.yyyy.", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            Datum_do = DateTime.ParseExact(Datum_do, "dd.MM.yyyy.", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            return new DbDataInsert().InsertData(this);
        }

        public void SumTotals()
        {
            Pretporez_osnovica_ukupno = Pretporez_osnovica_5_per +
                Pretporez_osnovica_13_per +
                Pretporez_osnovica_25_per;

            Pretporez_ukupno = Pretporez_za_T5 +
                Pretporez_za_T13 +
                Pretporez_za_T25;

            Porez_osnovica_ukupno = Porez_osnovica_5_per +
                Porez_osnovica_13_per +
                Porez_osnovica_25_per;

            Porez_ukupno = Porez_za_T5 +
                Porez_za_T13 +
                Porez_za_T25;

            Za_uplatu = Porez_ukupno - Pretporez_ukupno;
        }

        public int Id { get; set; } = 0;
        public string Datum_od { get; set; } = "";
        public string Datum_do { get; set; } = "";
        public decimal Pretporez_osnovica_0_per { get; set; } = 0;
        public decimal Pretporez_osnovica_5_per { get; set; } = 0;
        public decimal Pretporez_osnovica_13_per { get; set; } = 0;
        public decimal Pretporez_osnovica_25_per { get; set; } = 0;
        public decimal Pretporez_osnovica_ukupno { get; set; } = 0;
        public decimal Pretporez_za_T5 { get; set; } = 0;
        public decimal Pretporez_za_T13 { get; set; } = 0;
        public decimal Pretporez_za_T25 { get; set; } = 0;
        public decimal Pretporez_ukupno { get; set; } = 0;
        public decimal Porez_osnovica_0_per { get; set; } = 0;
        public decimal Porez_osnovica_5_per { get; set; } = 0;
        public decimal Porez_osnovica_13_per { get; set; } = 0;
        public decimal Porez_osnovica_25_per { get; set; } = 0;
        public decimal Porez_osnovica_ukupno { get; set; } = 0;
        public decimal Porez_za_T5 { get; set; } = 0;
        public decimal Porez_za_T13 { get; set; } = 0;
        public decimal Porez_za_T25 { get; set; } = 0;
        public decimal Porez_ukupno { get; set; } = 0;
        public decimal Za_uplatu { get; set; } = 0;
    }
}
