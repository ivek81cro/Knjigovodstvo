﻿using Knjigovodstvo.Database;
using Knjigovodstvo.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace Knjigovodstvo.Books.BookJournal
{
    public class DnevnikKnjizenja : IDbObject
    {
        public FormError ValidateData()
        {
            return FormError.None;
        }

        public int GetLatestBrojTemeljnice()
        {
            DataTable dt = new DbDataGet()
                                .GetTable(this, $"Id <> 0 ORDER BY Broj_temeljnice DESC");
            int latest = 1;
            if (dt.Rows.Count > 0)
            {
                latest = int.Parse(dt.Rows[0]["Broj_temeljnice"].ToString()) + 1;
            }
            return latest;
        }

        internal DnevnikKnjizenja ConvertDataGridViewRow(DataGridViewRow row)
        {
            return new DnevnikKnjizenja()
            {
                Opis = row.Cells["Opis"].Value.ToString(),
                Dokument = row.Cells["Dokument"].Value.ToString(),
                Broj = int.Parse(row.Cells["Broj"].Value.ToString()),
                Konto = row.Cells["Konto"].Value.ToString(),
                
                Datum = DateTime.ParseExact(
                    row.Cells["Datum"].Value.ToString().Split(' ')[0]
                    , "dd.MM.yyyy."
                    , CultureInfo.InvariantCulture)
                .ToString("yyyy-MM-dd"),
                
                Valuta = row.Cells["Valuta"].Value.ToString(),
                Dugovna = decimal.Parse(row.Cells["Dugovna"].Value.ToString()),
                Potražna = decimal.Parse(row.Cells["Potražna"].Value.ToString()),
            };
        }

        internal DataTable GetDnevnikByTemeljnica(int brojTemeljnice)
        {
            return new DbDataGet().GetTable(this, $"Broj_temeljnice = {brojTemeljnice}");
        }

        internal void SaveToDatabase(List<DnevnikKnjizenja> dk)
        {
            foreach(var item in dk)
            {
                item.InsertNew();
            }
        }

        private void InsertNew()
        {
            new DbDataInsert().InsertData(this);
        }

        public int Id { get; set; } = 0;
        public string Opis { get; set; } = "";
        public string Dokument { get; set; } = "";
        public int Broj { get; set; } = 0;
        public string Konto { get; set; } = "";
        public string Datum { get; set; } = "";
        public string Valuta { get; set; } = "HRK";
        public decimal Dugovna { get; set; } = 0;
        public decimal Potražna { get; set; } = 0;
        public int Broj_temeljnice { get; set; } = 0;
    }
}
