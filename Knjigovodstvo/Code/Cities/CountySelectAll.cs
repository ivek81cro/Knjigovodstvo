using Knjigovodstvo.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Knjigovodstvo.Code.Cities
{
    class CountySelectAll
    {
        public DataTable GetAllCounty()
        {
            DbDataGet data = new DbDataGet();
            string query = "SELECT Id, Naziv FROM Zupanije;";
            DataTable dt = data.GetTable(query);
            
            DataRow row = dt.NewRow();
            row[0] = 0;
            row[1] = "Odaberite županiju";
            dt.Rows.InsertAt(row, 0);
            return dt;
        }
    }
}
