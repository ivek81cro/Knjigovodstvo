using Knjigovodstvo.Database;
using Knjigovodstvo.Interface;
using System;
using System.Data;

namespace Knjigovodstvo.Books.PrepareForBalanceSheet
{
    class TemeljnicaStavka : IDbObject
    {
        public FormError ValidateData()
        {
            throw new NotImplementedException();
        }

        public void SaveToDatabase()
        {
            new DbDataInsert().InsertData(this);
        }

        public bool CheckIfExistsInDatabase() 
        {
            DataTable dt = new DbDataGet().GetTable(this, $"Broj={Broj} AND Konto='{Konto}'");
            if (dt.Rows.Count > 0)
            {
                Id= int.Parse(dt.Rows[0]["Id"].ToString());
                return true;
            }
            return false;
        }

        public void UpdateStavka()
        {
            new DbDataUpdate().UpdateData(this);
        }

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
