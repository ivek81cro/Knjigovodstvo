using Knjigovodstvo.Database;

namespace Knjigovodstvo.Payroll
{
    public class PlacaArhiva : Placa
    {
        public bool Exists()
        {
            int count = new DbDataGet().GetTable(this, 
                $"Oib={Oib} AND Datum_Od='{Datum_Od}' AND Datum_Do='{Datum_Do}'").Rows.Count;

            return count != 0;
        }
        public string Datum_Od { get; set; } = "";
        public string Datum_Do { get; set; } = "";
    }
}
