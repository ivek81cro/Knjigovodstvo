using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Knjigovodstvo.Code.Cities
{
    class CountySelectAll
    {
        public DataTable GetAllCounty()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConnHelper.ConnStr("KnjigovodstvoDb")))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT Id, Naziv FROM Zupanije", conn))
                {
                    //Fill the DataTable with records from Table.
                    
                    sda.Fill(dt);

                    //Insert the Default Item to DataTable.
                    DataRow row = dt.NewRow();
                    row[0] = 0;
                    row[1] = "Odaberite županiju";
                    dt.Rows.InsertAt(row, 0);


                }
            }
            return dt;
        }
    }
}
