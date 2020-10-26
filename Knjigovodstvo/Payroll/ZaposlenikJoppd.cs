using Knjigovodstvo.Database;
using Knjigovodstvo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Knjigovodstvo.Payroll
{
    class ZaposlenikJoppd : IDbObject
    {
        public FormError ValidateData()
        {
            throw new NotImplementedException();
        }

        public ZaposlenikJoppd GetZaposlenikByOib(string oib)
        {
            string condition = $"Oib='{oib}';";
            DataTable zaposlenik = new DbDataGet().GetTable(new ZaposlenikJoppd(), condition);
            if (zaposlenik.Rows.Count > 0)
            {
                return new ZaposlenikJoppd
                {
                    Id = int.Parse(zaposlenik.Rows[0]["Id"].ToString()),
                    Oib = zaposlenik.Rows[0]["Oib"].ToString(),
                    Nacin_Isplate = zaposlenik.Rows[0]["Nacin_Isplate"].ToString(),
                    Stjecatelj = zaposlenik.Rows[0]["Stjecatelj"].ToString(),
                    Primitak = zaposlenik.Rows[0]["Primitak"].ToString(),
                    Beneficirani = zaposlenik.Rows[0]["Beneficirani"].ToString(),
                    Invaliditet = zaposlenik.Rows[0]["Invaliditet"].ToString(),
                    Mjesec = zaposlenik.Rows[0]["Mjesec"].ToString(),
                    Vrijeme = zaposlenik.Rows[0]["Vrijeme"].ToString()
                };
            }

            return new ZaposlenikJoppd();
        }

        public int Id { get; set; } = 0;
        public string Oib { get; set; } = "";
        public string Nacin_Isplate { get; set; } = "";
        public string Stjecatelj { get; set; } = "";
        public string Primitak { get; set; } = "";
        public string Beneficirani { get; set; } = "";
        public string Invaliditet { get; set; } = "";
        public string Mjesec { get; set; } = "";
        public string Vrijeme { get; set; } = "";
    }
}
