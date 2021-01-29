using Knjigovodstvo.Helpers;
using Knjigovodstvo.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Knjigovodstvo.Database
{
    class DbDataDelete : DbData
    {
        /// <summary>Deletes row from table</summary>
        /// <param name="id">Id of row in table.</param>
        /// <param name="table">Name of table in database.</param>
        /// <returns>Bool True if operation successful.</returns>
        public bool DeleteItem(IDbObject dbObject, string condition = null)
        {
            GenericPropertyFinder<IDbObject> property = new GenericPropertyFinder<IDbObject>();

            IEnumerable<List<string>> obj = property.PrintTModelPropertyAndValue(dbObject);
            string table = dbObject.GetType().ToString()[(dbObject.GetType().ToString().LastIndexOf('.') + 1)..];
            string query = new DbQueryBuilder(obj, table).BuildQuery(QueryType.Delete);

            if (condition != null)
            {
                query = query[0..^1];
                query += condition;
            }

            try
            {
                using SqlConnection conn = new SqlConnection(ConnHelper.ConnStr(connection_name));
                using SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                command.ExecuteNonQuery();
                command.Dispose();
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
    }
}
