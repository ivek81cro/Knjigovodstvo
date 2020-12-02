using Knjigovodstvo.Helpers;
using Knjigovodstvo.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Knjigovodstvo.Database
{
    class DbDataGet
    {
        /// <summary>
        /// Gets table from database depending on recieved object.
        /// </summary>
        /// <param name="dbObject">Table name based on type name of object.</param>
        /// <param name="condition">Parameter after WHERE in SQL query. (Ex. Id=0), default null</param>
        /// <returns>DataTable based on condition</returns>
        public DataTable GetTable(IDbObject dbObject, string condition=null)
        {
            GenericPropertyFinder<IDbObject> property = new GenericPropertyFinder<IDbObject>();

            IEnumerable<List<string>> obj = property.PrintTModelPropertyAndValue(dbObject);
            string table = dbObject.GetType().ToString()[(dbObject.GetType().ToString().LastIndexOf('.') + 1)..];
            string query = new DbQueryBuilder(obj, table).BuildQuery(QueryType.Select);

            if(condition != null)
            {
                if(query.EndsWith(';'))
                    query = query[0..^1];
                query += $" WHERE {condition};";
            }

            DataTable dt = new DataTable();
            try
            {
                using SqlConnection conn = new SqlConnection(ConnHelper.ConnStr(connection_name));
                using SqlDataAdapter sda = new SqlDataAdapter(query, conn);

                //Fill the DataTable with records from Table.
                sda.Fill(dt);
            }
            catch (SqlException e)
            {
                MessageBox.Show(
                    $"Provjerite vezu sa bazom podataka.\n {e.Message}",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    $"Nepoznata greška kod dohvata županija, kontaktirajte podršku.\n {e.Message}",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            return dt;
        }

        private readonly string connection_name = "KnjigovodstvoDb";
    }
}
