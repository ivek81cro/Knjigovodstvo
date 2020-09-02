using Knjigovodstvo.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Knjigovodstvo.Code.Cities
{
    class CitySelect
    {
        public DataTable GetAllCities()
        {
            DbDataGet data = new DbDataGet();
            string query = String.Format("SELECT Id, Naziv FROM Opcina;");
            DataTable dt = data.GetTable(query);
            
            return dt;
        }
        public DataTable GetCityByCounty(string county)
        {
            DbDataGet data = new DbDataGet();
            string query = String.Format("SELECT Id, Naziv FROM Opcina where Zupanija='{0}';", county);
            DataTable dt = data.GetTable(query);

            DataRow row = dt.NewRow();
            row[0] = 0;
            row[1] = "Odaberite Grad";
            dt.Rows.InsertAt(row, 0);
            return dt;
        }
    }
}
