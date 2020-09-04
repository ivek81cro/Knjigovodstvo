using Knjigovodstvo.Helpers;
using Knjigovodstvo.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Knjigovodstvo.Code.Cities
{
    class CountySelect
    {
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
    }
}
