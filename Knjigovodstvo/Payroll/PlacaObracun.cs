using Knjigovodstvo.Database;
using Knjigovodstvo.Models;
using System.Data;

namespace Knjigovodstvo.Payroll
{
    class PlacaObracun : IDbObject
    {
        public FormError ValidateData()
        {
            throw new System.NotImplementedException();
        }

        public int Exists()
        {
            DataTable postojece = new DbDataGet().GetTable(new PlacaObracun(), 
                $"Oib='{Oib}' AND Datum_Od='{Datum_Od}' AND Datum_Do='{Datum_Do}';");
            int kontrola = postojece.Rows.Count;
            if ( kontrola >= 1)
            {
                return int.Parse(postojece.Rows[0]["Id"].ToString());
            }

            return 0;
        }

        public int Id { get; set; } = 0;
        public string Oib { get; set; } = "";
        public decimal Bruto { get; set; } = 0;
        public decimal Mio_1 { get; set; } = 0;
        public decimal Mio_2 { get; set; } = 0;
        public decimal Dohodak { get; set; } = 0;
        public decimal Osobni_Odbitak { get; set; } = 0;
        public decimal Porezna_Osnovica { get; set; } = 0;
        public decimal Porez_24_per { get; set; } = 0;
        public decimal Porez_36_per { get; set; } = 0;
        public decimal Porez_Ukupno { get; set; } = 0;
        public decimal Prirez { get; set; } = 0;
        public decimal Ukupno_Porez_i_Prirez { get; set; } = 0;
        public decimal Neto { get; set; } = 0;
        public decimal Doprinos_Zdravstvo { get; set; } = 0;
        public decimal Dodaci_Ukupno { get; set; } = 0;
        public string Datum_Od { get; set; } = "";
        public string Datum_Do { get; set; } = "";

    }
}
