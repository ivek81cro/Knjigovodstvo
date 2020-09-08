using Knjigovodstvo.Helpers;
using System.Data;

namespace Knjigovodstvo.Models
{
    class Zupanije : IDbObject
    {        
        public FormError ValidateData()
        {
            if (Naziv == null)
                return FormError.Name;

            return FormError.None;
        }

        /// <summary>
        /// Gets all counties from database
        /// </summary>
        public DataTable GetAllCounty()
        {
            DbDataGet data = new DbDataGet();
            DataTable dt = data.GetTable(new Zupanije());

            DataRow row = dt.NewRow();
            row[0] = 0;
            row[1] = "Odaberite županiju";
            dt.Rows.InsertAt(row, 0);
            return dt;
        }
        public int Id { get; set; } = 0;
        public string Naziv { get; set; } = "";
    }
}
