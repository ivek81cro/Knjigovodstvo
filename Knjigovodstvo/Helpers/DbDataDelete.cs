using System;
using System.Data.SqlClient;

namespace Knjigovodstvo.Helpers
{
    class DbDataDelete
    {
        public bool DeletePartner(Partner partner)
        {
            try
            {
                string query = "DELETE FROM Partneri WHERE Id=@Id;";

                using (SqlConnection conn = new SqlConnection(ConnHelper.ConnStr(connection_name)))
                {
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@Id", partner.Id);
                        conn.Open();
                        command.ExecuteNonQuery();
                        conn.Close();

                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private readonly string connection_name = "KnjigovodstvoDb";
    }
}
