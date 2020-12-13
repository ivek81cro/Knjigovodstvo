using Knjigovodstvo.Database;
using Knjigovodstvo.Interface;
using System;
using System.Data;

namespace Knjigovodstvo.Payroll
{
    public class Dodatak : IDbObject
    {
        public FormError ValidateData()
        {
            throw new NotImplementedException();
        }

        public DataTable GetDodaciByOib(string oib)
        {
            return new DbDataGet().GetTable(this, $"Oib='{oib}';");
        }

        public int Id { get; set; } = 0;
        public string Oib { get; set; } = "";
        public string Sifra { get; set; } = "";
        public decimal Iznos { get; set; } = 0;
    }
}
