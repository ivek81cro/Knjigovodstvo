using Knjigovodstvo.Database;
using System.Data;

namespace Knjigovodstvo.Payroll
{
    public class PlacaArhiva : Placa
    {
        public bool Exists()
        {
            DataTable dt = new DbDataGet().GetTable(this, 
                $"Oib='{Oib}' AND Datum_Od='{Datum_Od}' AND Datum_Do='{Datum_Do}'");
            int count = dt.Rows.Count;
            if (count != 0)
                Id = int.Parse(dt.Rows[0]["Id"].ToString());

            return count != 0;
        }

        public string Datum_Od { get; set; } = "";
        public string Datum_Do { get; set; } = "";
        public string Datum_obracuna { get; set; } = "";
    }
}
