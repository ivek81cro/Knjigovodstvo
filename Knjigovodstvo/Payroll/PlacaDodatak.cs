using Knjigovodstvo.Database;
using Knjigovodstvo.Employee;
using Knjigovodstvo.Interface;
using System;
using System.Data;

namespace Knjigovodstvo.Payroll
{
    class PlacaDodatak : IDbObject
    {
        public FormError ValidateData()
        {
            throw new NotImplementedException();
        }

        public Placa ZbrojiDodatke(Placa placa, Zaposlenik zaposlenik)
        {
            placa.Dodaci_Ukupno = 0;

            _dt = new DbDataGet().GetTable(new PlacaDodatak(), $"Oib='{zaposlenik.Oib}';");
            foreach (DataRow row in _dt.Rows)
            {
                placa.Dodaci_Ukupno += decimal.Parse(row["Iznos"].ToString());
            }

            return placa;
        }

        public DataTable GetDodaciByOib(string oib)
        {
            return _dt = new DbDataGet().GetTable(this, $"Oib='{oib}';");
        }

        private DataTable _dt = new DataTable();

        public int Id { get; set; } = 0;
        public string Oib { get; set; } = "";
        public string Sifra { get; set; } = "";
        public decimal Iznos { get; set; } = 0;
    }
}
