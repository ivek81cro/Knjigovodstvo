using Knjigovodstvo.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Knjigovodstvo.Helpers
{
    class DbDataUpdate
    {
        public bool UpadatePartner(IDbObject dbObject)
        {
            GenericPropertyFinder<IDbObject> property = new GenericPropertyFinder<IDbObject>();

            IEnumerable<List<string>> obj = property.PrintTModelPropertyAndValue(dbObject);
            List<string> name = obj.First();
            List<string> value = obj.ElementAt(1);
            string query = "UPDATE " + dbObject.GetType().ToString().Substring(dbObject.GetType().ToString().LastIndexOf('.') + 1) + " ";
            query += "SET ";

            for (int i = 1; i < name.Count; ++i)
            {
                query += name[i] + "='" + value[i] + "', ";
            }
            query = query.Substring(0, query.Length - 2);
            query += " WHERE Id=" + value[0] + ";";
            
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
