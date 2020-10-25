using Knjigovodstvo.Models;

namespace Knjigovodstvo.Payroll
{
    class PlacaObracun : IDbObject
    {
        public FormError ValidateData()
        {
            throw new System.NotImplementedException();
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
