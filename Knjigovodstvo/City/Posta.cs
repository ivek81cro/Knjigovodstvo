using Knjigovodstvo.Database;
using Knjigovodstvo.Models;
using System.Data;

namespace Knjigovodstvo.City
{
    class Posta : IDbObject
    {
        public FormError ValidateData()
        {
            //TODO: Validation
            return FormError.None;
        }

        public DataTable GetPostaByGrad(string grad)
        {
            string condition = $"Mjesto='{grad}'";
            DbDataGet data = new DbDataGet();
            DataTable dt = data.GetTable(new Posta(), condition);

            DataRow row = dt.NewRow();
            row[0] = 0;
            row[1] = "Odaberite br. pošte";
            dt.Rows.InsertAt(row, 0);

            return dt;
        }

        public int BrojPu { get; set; } = 0;
        public string Adresa { get; set; } = "";
        public string Mjesto { get; set; } = "";
        public string Grad { get; set; } = "";
        public string Zupanija { get; set; } = "";
    }
}
