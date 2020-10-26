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
        public float Bruto { get; set; } = 0;
        public float Mio_1 { get; set; } = 0;
        public float Mio_2 { get; set; } = 0;
        public float Dohodak { get; set; } = 0;
        public float Osobni_Odbitak { get; set; } = 0;
        public float Porezna_Osnovica { get; set; } = 0;
        public float Porez_24_per { get; set; } = 0;
        public float Porez_36_per { get; set; } = 0;
        public float Porez_Ukupno { get; set; } = 0;
        public float Prirez { get; set; } = 0;
        public float Ukupno_Porez_i_Prirez { get; set; } = 0;
        public float Neto { get; set; } = 0;
        public float Doprinos_Zdravstvo { get; set; } = 0;
        public float Dodaci_Ukupno { get; set; } = 0;
        public string Datum_Od { get; set; } = "";
        public string Datum_Do { get; set; } = "";

    }
}
