using Knjigovodstvo.Database;
using System.Data;

namespace Knjigovodstvo.Payroll
{
    public class DodatakArhiva : Dodatak
    {
        public void SaveToDatabase()
        {
            string condition = $"Oib='{Oib}' AND Sifra='{Sifra}' AND Datum_Od='{Datum_Od}' AND Datum_Do='{Datum_Do}'";
            DataTable dt = new DbDataGet().GetTable(this, condition);
            if (dt.Rows.Count == 0)
            {
                new DbDataInsert().InsertData(this);
            }
            else
            {
                Id = int.Parse(new DbDataCustomQuery()
                    .ExecuteQuery($"SELECT Id FROM DodatakArhiva WHERE {condition}").Rows[0]["Id"]
                    .ToString());
                new DbDataUpdate().UpdateData(this);
            }
        }
        public string Datum_Od { get; set; } = "";
        public string Datum_Do { get; set; } = "";
        public string Datum_obracuna { get; set; } = "";
    }
}
