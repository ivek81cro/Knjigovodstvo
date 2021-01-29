using System;
using System.Collections.Generic;
using System.Linq;

namespace Knjigovodstvo.Database
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
        public DbQueryBuilder(IEnumerable<List<String>> obj, string table, string whereColumn=null)
        {
            _obj = obj;
            _name = _obj.First();
            _value = _obj.ElementAt(1);
            _type = _obj.ElementAt(2);
            _table = table;
            _whereColumn = whereColumn;
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
            string query = "SELECT ";

            for (int i = 0; i < _name.Count; ++i)
            {
                int n;
                if (_table.Contains("Postavke"))
                    n = 5;
                else 
                    n = 2;

                if (_type[i] == "Decimal")
                {
                    query += $"ROUND({_name[i]}, {n}) as {_name[i]}, ";
                }
                else
                    query += _name[i] + ", ";
            }
            query = query[0..^2];

            query += " FROM " + _table + ";";

            return query;
        }

        private string Insert()
        {
            string query = "INSERT INTO " + _table + " ";
            query += "(";
            for (int i = 0; i < _name.Count; ++i)
            {
                if (_name[i] == "Id")
                    continue;
                query += _name[i] + ", ";
            }

            query = query[0..^2];
            query += ") VALUES (";
            for (int i = 0; i < _value.Count; ++i)
            {
                if (_name[i] == "Id")
                    continue;
                if (_type[i] == "Decimal")
                    query += _value[i].Replace(',', '.') + ", ";
                else if(_value[i] == "Null")
                    query +=  _value[i] + ", ";
                else
                    query += "'" + _value[i] + "', ";
            }

            query = query[0..^2];
            query += ");";

            return query;
        }

        private string Update()
        {
            string query = $"UPDATE {_table} ";
            query += "SET ";
            int i = _whereColumn == null ? 1 : 0;
            for ( ; i < _name.Count; ++i)
            {
                if (_name[i] == "Id")
                    continue;
                if (_type[i] == "Decimal")
                    query += _name[i] + "=" + _value[i].Replace(',', '.') + ", ";
                else if (_value[i] == "Null")
                    query += _name[i] + "=" + _value[i] + ", ";
                else
                    query += _name[i] + "='" + _value[i] + "', ";
            }
            query = query[0..^2];

            if (_whereColumn == null)
            {
                query += $" WHERE Id={_value[_name.FindIndex(s => s == "Id")]};";
            }

            return query;
        }        

        private string Delete()
        {
            return $"DELETE FROM {_table} WHERE Id={_value[0]} ;";
        }

        private readonly IEnumerable<List<string>> _obj;
        private readonly string _table;
        private readonly string _whereColumn;
        private readonly List<string> _name;
        private readonly List<string> _value;
        private readonly List<string> _type;
    }
}
