using Knjigovodstvo.Database;
using Knjigovodstvo.Employee;
using Knjigovodstvo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

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

            DataTable table = new DbDataGet().GetTable(new PlacaDodatak(), $"Oib='{zaposlenik.Oib}';");
            foreach (DataRow row in table.Rows)
            {
                placa.Dodaci_Ukupno += float.Parse(row["Iznos"].ToString());
            }

            return placa;
        }

        public int Id { get; set; } = 0;
        public string Oib { get; set; } = "";
        public int Sifra { get; set; } = 0;
        public float Iznos { get; set; } = 0;
    }
}
