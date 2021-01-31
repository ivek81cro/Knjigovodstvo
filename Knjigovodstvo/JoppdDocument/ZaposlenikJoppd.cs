using Knjigovodstvo.Database;
using Knjigovodstvo.Interface;
using System;
using System.Data;

namespace Knjigovodstvo.JoppdDocument
{
    class ZaposlenikJoppd : IDbObject
    {
        public FormError ValidateData()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns all data for employees form as DataTable
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetZaposlenikJoppdDataTable()
        {
            return new DbDataGet().GetTable(this);
        }

        /// <summary>
        /// Returns all data for employees form as DataTable by condition
        /// </summary>
        /// <param name="condition"></param>
        /// <returns>DataTable</returns>
        public DataTable GetZaposlenikJoppdDataTable(string condition)
        {
            return new DbDataGet().GetTable(this, condition);
        }

        /// <summary>
        /// Returns data for employees form as DataTable for specific employee
        /// </summary>
        /// <returns></returns>
        public ZaposlenikJoppd GetZaposlenikByOib()
        {
            DataRow row = GetZaposlenikJoppdDataTable($"Oib='{Oib}'").Rows[0];
            SetPrivateMembers(row);

            return new ZaposlenikJoppd();
        }

        /// <summary>
        /// Returns data for employees form as DataTable for specific employee
        /// </summary>
        /// <param name="oib"></param>
        /// <returns></returns>
        public ZaposlenikJoppd GetZaposlenikByOib(string oib)
        {
            DataRow row = GetZaposlenikJoppdDataTable($"Oib='{oib}'").Rows[0];
            SetPrivateMembers(row);

            return new ZaposlenikJoppd();
        }

        private void SetPrivateMembers(DataRow row)
        {
            Id = int.Parse(row["Id"].ToString());
            Oib = row["Oib"].ToString();
            Nacin_Isplate = row["Nacin_Isplate"].ToString();
            Stjecatelj = row["Stjecatelj"].ToString();
            Primitak = row["Primitak"].ToString();
            Beneficirani = row["Beneficirani"].ToString();
            Invaliditet = row["Invaliditet"].ToString();
            Mjesec = row["Mjesec"].ToString();
            Vrijeme = row["Vrijeme"].ToString();

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
