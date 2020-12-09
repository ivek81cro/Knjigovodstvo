using Knjigovodstvo.Database;
using Knjigovodstvo.Interface;
using System.Data;

namespace Knjigovodstvo.Settings
{
    public enum PlacaStope
    {
        Mio_1,
        Mio_2,
        Porez_Dohodak_1,
        Porez_Dohodak_2,
        Doprinos_Zdravstveno,
        Osnovica_odbitka,
        Osnovni_odbitak_koeficjent
    }
    public class PostavkePlace : IDbObject
    {
        public FormError ValidateData()
        {
            if (Vrijednost.ToString() == "")
            {
                return FormError.Prazno;
            }

            return FormError.None;
        }

        internal void GetPostavkaById(int id)
        {
            string condition = $"Id={id};";
            DataTable postavka = new DbDataGet().GetTable(this, condition);

            Id = int.Parse(postavka.Rows[0]["Id"].ToString());
            Naziv = postavka.Rows[0]["Naziv"].ToString();
            Vrsta = postavka.Rows[0]["Vrsta"].ToString();
            Vrijednost = decimal.Parse(postavka.Rows[0]["Vrijednost"].ToString());

        }

        internal bool UpdateData()
        {
            if (new DbDataUpdate().UpdateData(this))
                return true;

            return false;
        }

        internal decimal GetStopaByName(PlacaStope naziv)
        {
            string condition = $"Naziv='{naziv}';";
            DataTable postavka = new DbDataGet().GetTable(this, condition);

            return decimal.Parse(postavka.Rows[0]["Vrijednost"].ToString());
        }

        public int Id { get; set; } = 0;
        public string Naziv { get; set; } = "";
        public string Vrsta { get; set; } = "";
        public decimal Vrijednost { get; set; } = 0;
    }
}
