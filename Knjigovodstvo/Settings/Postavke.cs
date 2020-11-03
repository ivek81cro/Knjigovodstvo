using Knjigovodstvo.Database;
using Knjigovodstvo.Interface;
using Knjigovodstvo.Validators;
using System.Data;

namespace Knjigovodstvo.Settings
{
    public enum PlacaStope
    {
        Mio_1,
        Mio_2,
        Porez_Dohodak_24,
        Porez_Dohodak_36,
        Doprinos_Zdravstveno
    }
    class Postavke : IDbObject
    {
        public FormError ValidateData()
        {
            if (Vrijednost.ToString() == "")
            {
                return FormError.Prazno;
            }

            return FormError.None;
        }

        internal Postavke GetPostavkaById(int id)
        {
            string condition = $"Id={id};";
            DataTable postavka = new DbDataGet().GetTable(new Postavke(), condition);
            return new Postavke
            {
                Id = int.Parse(postavka.Rows[0]["Id"].ToString()),
                Naziv = postavka.Rows[0]["Naziv"].ToString(),
                Vrsta = postavka.Rows[0]["Vrsta"].ToString(),
                Vrijednost = decimal.Parse(postavka.Rows[0]["Vrijednost"].ToString())
            };
        }

        internal bool UpdateData(int id)
        {
            Id = id;
            if (new DbDataUpdate().UpdateData(this))
                return true;

            return false;
        }

        internal decimal GetStopaByName(PlacaStope naziv)
        {
            string condition = $"Naziv='{naziv}';";
            DataTable postavka = new DbDataGet().GetTable(new Postavke(), condition);

            return decimal.Parse(postavka.Rows[0][3].ToString());
        }

        public int Id { get; set; } = 0;
        public string Naziv { get; set; } = "";
        public string Vrsta { get; set; } = "";
        public decimal Vrijednost { get; set; } = 0;
    }
}
