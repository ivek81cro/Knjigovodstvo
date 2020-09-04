using Knjigovodstvo.Models;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Knjigovodstvo.Helpers
{
    class DbDataDelete
    {
        public bool DeleteItem(int id, string database)
        {
            try
            {
                string query = String.Format("DELETE FROM {0} WHERE Id={1};", database, id);

                using SqlConnection conn = new SqlConnection(ConnHelper.ConnStr(connection_name));
                using SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();

                return true;
            }
            catch (SqlException e)
            {
                MessageBox.Show(
                    $"Provjerite vezu sa bazom podataka.\n {e.Message}",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    $"Nepoznata greška kod brisanja podataka, kontaktirajte podršku.\n {e.Message}",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
        }

        private readonly string connection_name = "KnjigovodstvoDb";
    }
}
