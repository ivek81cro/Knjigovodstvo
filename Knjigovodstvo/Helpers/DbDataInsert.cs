using Knjigovodstvo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Knjigovodstvo.Helpers
{
    class DbDataInsert
    {
        /// <summary>
        /// Insert data in database. Name of table based on argument type.
        /// </summary>
        /// <param name="dbObject">Table name based on type name of object.</param>
        /// <returns>Boolean, True if operation successful</returns>
        public bool InsertData(IDbObject dbObject)
        {
            GenericPropertyFinder<IDbObject> property = new GenericPropertyFinder<IDbObject>();

            IEnumerable<List<string>> obj = property.PrintTModelPropertyAndValue(dbObject);
            string table = dbObject.GetType().ToString().Substring(dbObject.GetType().ToString().LastIndexOf('.') + 1);
            string query = new DbQueryBuilder(obj, table).BuildQuery(QueryType.Insert);

            try
            {
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
