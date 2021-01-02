using Knjigovodstvo.Books.PrepareForBalanceSheet;
using Knjigovodstvo.Interface;
using System.Collections.Generic;

namespace Knjigovodstvo.Books.BalanceSheetJournal
{
    class Temeljnice:IDbObject
    {
        public FormError ValidateData()
        {
            throw new System.NotImplementedException();
        }

        public int Id { get; set; }
        public int Broj_temeljnice { get; set; }
        public string Vrsta_temeljnice { get; set; }
        public string Datum_knjizenja { get; set; }
        public decimal Duguje { get; set; }
        public decimal Potrazuje { get; set; }
    }
}
