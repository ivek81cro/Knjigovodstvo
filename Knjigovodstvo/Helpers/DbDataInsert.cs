using Knjigovodstvo.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Knjigovodstvo.Helpers
{
    class DbDataInsert
    {
        public bool InsertData(IDbObject dbObject)
        {
            GenericPropertyFinder<IDbObject> property = new GenericPropertyFinder<IDbObject>();

            IEnumerable<List<string>> obj = property.PrintTModelPropertyAndValue(dbObject);
            List<string> name = obj.First();
            List<string> value = obj.ElementAt(1);
            string query = "INSERT INTO " + dbObject.GetType().ToString().Substring(dbObject.GetType().ToString().LastIndexOf('.') + 1) + " ";
            query += "(";

            for(int i = 1; i< name.Count; ++i)
            {
                query += name[i] + ", ";
            }
            query = query.Substring(0, query.Length - 2);
            query += ") VALUES (";
            for (int i = 1; i < value.Count; ++i)
            {
                query += "'" + value[i] + "', ";
            }
            query = query.Substring(0, query.Length - 2);
            query += ");";
            // TODO, return list of property names and list of values, form guerry and params
            try
            {
                using SqlConnection conn = new SqlConnection(ConnHelper.ConnStr(connection_name));
                using SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }

        private readonly string connection_name = "KnjigovodstvoDb";
    }
}
