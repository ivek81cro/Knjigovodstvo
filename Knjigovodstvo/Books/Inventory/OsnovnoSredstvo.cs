using Knjigovodstvo.Database;
using Knjigovodstvo.Interface;
using System;

namespace Knjigovodstvo.Books.Inventory
{
    class OsnovnoSredstvo : IDbObject
    {
        public FormError ValidateData()
        {
            throw new NotImplementedException();
        }

        internal bool SaveData()
        {
            CalculateCurrentValue();
            return new DbDataInsert().InsertData(this);
        }

        private void CalculateCurrentValue()
        {
            decimal nabavljeno = DateTime.Parse(Datum_nabave).Year;
            decimal today = DateTime.Today.Year - 1;
            Iznos_amortizacije = Nabavna_vrijednost * Stopa_otpisa / 100.0m;
            Otpisano = Iznos_amortizacije * (today-nabavljeno);

            if (Otpisano > Nabavna_vrijednost)
                Otpisano = Nabavna_vrijednost;

            Sadasnja_vrijednost = Nabavna_vrijednost - Otpisano;
        }

        public int Id { get; set; } = 0;
        public string Naziv { get; set; } = "";
        public string Datum_nabave { get; set; } = "";
        public string Datum_uporabe { get; set; } = "";
        public string Dobavljac { get; set; } = "";
        public string Dokument { get; set; } = "";
        public decimal Kolicina { get; set; } = 0;
        public decimal Nabavna_vrijednost { get; set; } = 0;
        public decimal Vijek_trajanja { get; set; } = 0;
        public decimal Stopa_otpisa { get; set; } = 0;
        public decimal Otpisano { get; set; } = 0;
        public decimal Sadasnja_vrijednost { get; set; } = 0;
        public decimal Iznos_amortizacije { get; set; }
    }
}
