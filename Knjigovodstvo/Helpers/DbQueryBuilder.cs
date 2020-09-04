using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Knjigovodstvo.Helpers
{
    public enum QueryType
    {
        Insert,
        Update,
        Delete,
        Select
    }
    public class DbQueryBuilder
    {
        public DbQueryBuilder(IEnumerable<List<String>> obj, string table)
        {
            _obj = obj;
            _name = _obj.First();
            _value = _obj.ElementAt(1);
            _table = table;
        }

        /// <summary>
        /// Build query based on type.
        /// </summary>
        /// <param name="type">Select, Insert, Update, Delete</param>
        /// <returns>Query as string.</returns>
        public string BuildQuery(QueryType type)
        {
            string query = null;
            switch (type)
            {
                case QueryType.Insert:
                    query += Insert();
                    break;
                case QueryType.Update:
                    query += Update();
                    break;
                case QueryType.Delete:
                    query += Delete();
                    break;
                case QueryType.Select:
                    query += Select();
                    break;
            }

            return query;
        }

        private string Select()
        {
            return String.Format("SELECT * FROM {0};", _table);
        }

        private string Insert()
        {
            string query = "INSERT INTO " + _table + " ";
            query += "(";

            for (int i = 1; i < _name.Count; ++i)
            {
                query += _name[i] + ", ";
            }
            query = query.Substring(0, query.Length - 2);
            query += ") VALUES (";
            for (int i = 1; i < _value.Count; ++i)
            {
                query += "'" + _value[i] + "', ";
            }
            query = query.Substring(0, query.Length - 2);
            query += ");";

            return query;
        }

        private string Update()
        {
            string query = "UPDATE " + _table + " ";
            query += "SET ";

            for (int i = 1; i < _name.Count; ++i)
            {
                query += _name[i] + "='" + _value[i] + "', ";
            }
            query = query.Substring(0, query.Length - 2);
            query += " WHERE Id=" + _value[0] + ";";

            return query;
        }

        private string Delete()
        {
            return String.Format("DELETE FROM {0} WHERE Id={1};", _table, _value[0]);
        }

        private readonly IEnumerable<List<string>> _obj;
        private readonly string _table;
        private readonly List<string> _name;
        private readonly List<string> _value;
    }
}
