using Knjigovodstvo.Books.BookJournal;
using Knjigovodstvo.Database;
using Knjigovodstvo.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace Knjigovodstvo.Books.BalanceSheetJournal
{
    class Temeljnica : IDbObject
    {
        public FormError ValidateData()
        {
            return FormError.None;
        }

        internal void InsertNew()
        {
            new DbDataInsert().InsertData(this);
            
        }

        internal DataTable GetTemeljnicaDataTable(string condition = null)
        {
            return new DbDataGet().GetTable(this, condition);
        }

        internal void GetTemeljnicaByNumber(int number)
        {
            if (number != 0)
            {
                DataTable dt = GetTemeljnicaDataTable($"Broj_temeljnice = {number}");
                Id = int.Parse(dt.Rows[0]["Id"].ToString());
                Broj_temeljnice = int.Parse(dt.Rows[0]["Broj_temeljnice"].ToString());
                Vrsta_temeljnice = dt.Rows[0]["Vrsta_temeljnice"].ToString();
                Datum_knjizenja = dt.Rows[0]["Datum_knjizenja"].ToString();
                Dugovna = decimal.Parse(dt.Rows[0]["Dugovna"].ToString());
                Potražna = decimal.Parse(dt.Rows[0]["Potražna"].ToString());
            }
        }

        public void UpdateTemeljnica()
        {
            Datum_knjizenja = DateTime.ParseExact(
                Datum_knjizenja.Split(' ')[0], "dd.MM.yyyy.", CultureInfo.InvariantCulture)
                .ToString("yyyy-MM-dd");

            new DbDataUpdate().UpdateData(this);
        }

        public int Id { get; set; } = 0;
        public int Broj_temeljnice { get; set; } = 0;
        public string Vrsta_temeljnice { get; set; } = "";
        public string Datum_knjizenja { get; set; } = "";
        public decimal Dugovna { get; set; } = 0;
        public decimal Potražna { get; set; } = 0;
    }
}
