using Knjigovodstvo.Global.Helpers;
using Knjigovodstvo.Helpers;
using Knjigovodstvo.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Knjigovodstvo.Database
{
    class DbDataInsert : DbData
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
            GetTableName(dbObject);
            string query = new DbQueryBuilder(obj, _table).BuildQuery(QueryType.Insert);

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

        private void GetTableName(IDbObject dbObject)
        {
            _table = dbObject.GetType()
                            .ToString()[(dbObject.GetType()
                                               .ToString()
                                               .LastIndexOf('.') + 1)..];
        }

        internal void InsertDataBulk(IDbObject obj, DataGridView dgv)
        {
            DataTable dt = new DgvToDataTable().ToDataTable(dgv);
            try
            {
                using SqlConnection conn = new SqlConnection(ConnHelper.ConnStr(connection_name));
                GetTableName(obj);
                using var bulkCopy = new SqlBulkCopy(conn.ConnectionString);
                // when DT columns match db.table names
                foreach (DataColumn col in dt.Columns)
                {
                    bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                }

                bulkCopy.BulkCopyTimeout = 600;
                bulkCopy.DestinationTableName = _table;
                bulkCopy.WriteToServer(dt);
            }
            catch(Exception e)
            {
                MessageBox.Show("Bulk greška: " + e.Message);
            }
        }

        private string _table;
    }
}
