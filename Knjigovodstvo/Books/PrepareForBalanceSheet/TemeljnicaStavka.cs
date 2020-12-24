using Knjigovodstvo.Database;
using Knjigovodstvo.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace Knjigovodstvo.Books.PrepareForBalanceSheet
{
    class TemeljnicaStavka : IDbObject
    {
        public FormError ValidateData()
        {
            throw new NotImplementedException();
        }

        public void SaveToDatabase(List<TemeljnicaStavka> stavke)
        {
            foreach(var stavka in stavke)
                new DbDataInsert().InsertData(stavka);
        }

        public bool CheckIfExistsInDatabase()
        {
            DataTable dt = new DbDataGet().GetTable(this, $"Dokument='{Dokument}' AND Broj={Broj}");
            _stavke = new List<TemeljnicaStavka>();
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    _stavke.Add(new TemeljnicaStavka()
                    {
                        Id = int.Parse(row["Id"].ToString()),
                        Opis = row["Opis"].ToString(),
                        Dokument = row["Dokument"].ToString(),
                        Broj = int.Parse(row["Broj"].ToString()),
                        Konto = row["Konto"].ToString(),
                        Datum = DateTime.ParseExact(row["Datum"].ToString().Split(' ')[0], "dd.MM.yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"),
                        Valuta = row["Valuta"].ToString(),
                        Duguje1 = decimal.Parse(row["Duguje1"].ToString()),
                        Potrazuje1 = decimal.Parse(row["Potrazuje1"].ToString()),
                        Duguje2 = decimal.Parse(row["Duguje2"].ToString()),
                        Potrazuje2 = decimal.Parse(row["Potrazuje2"].ToString()),
                        Broj_temeljnice = int.Parse(row["Broj_temeljnice"].ToString())
                    });
                }
                return true;
            }
            return false;
        }

        public void UpdateStavka()
        {
            foreach(var stavka in _stavke)
            {
                new DbDataUpdate().UpdateData(stavka);
            }
        }

        private List<TemeljnicaStavka> _stavke;

        public int Id { get; set; } = 0;
        public string Opis { get; set; } = "";
        public string Dokument { get; set; } = "";
        public int Broj { get; set; } = 0;
        public string Konto { get; set; } = "";
        public string Datum { get; set; } = "";
        public string Valuta { get; set; } = "HRK";
        public decimal Duguje1 { get; set; } = 0;
        public decimal Potrazuje1 { get; set; } = 0;
        public decimal Duguje2 { get; set; } = 0;
        public decimal Potrazuje2 { get; set; } = 0;
        public int Broj_temeljnice { get; set; } = 0;
    }
}
