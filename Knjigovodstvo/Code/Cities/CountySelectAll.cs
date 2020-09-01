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
            DataTable dt = new DataTable();
            try
            {
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
            }
            catch(SqlException e)
            {
                MessageBox.Show(
                    $"Provjerite vezu sa bazom podataka.\n {e.Message}", 
                    "Greška", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
            catch(Exception e)
            {
                MessageBox.Show(
                    $"Nepoznata greška kod dohvata županija, kontaktirajte podršku.\n {e.Message}",
                    "Greška", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
            return dt;
        }
    }
}
