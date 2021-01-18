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
    }
}
