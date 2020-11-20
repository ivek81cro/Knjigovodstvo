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
            _obj = SortPropertiesCustom(obj);
            _name = _obj.First();
            _value = _obj.ElementAt(1);
            _type = _obj.ElementAt(2);
            _table = table;
            _whereColumn = whereColumn;
        }

        private IEnumerable<List<string>> SortPropertiesCustom(IEnumerable<List<string>> obj)
        {
            List<string> col_names = new List<string>()
            {
                "Id", "Oib", "Naziv", "Mbo", "Ime", "Prezime", "Mjesto", "Posta", "Ulica", "Broj", "Email", "Telefon","Fax"
            };
            List<string> new_name = new List<string>();
            List<string> new_value = new List<string>();
            List<string> new_type = new List<string>();
            for (int i = 0; i < col_names.Count; i++)
            {
                for (int j = 0; j < obj.ElementAt(0).Count; j++)
                {
                    if (String.Compare(col_names[i], obj.ElementAt(0)[j]) == 0 && !new_name.Contains(obj.ElementAt(0)[j]))
                    {
                        new_name.Add(obj.ElementAt(0)[j]);
                        new_value.Add(obj.ElementAt(1)[j]);
                        new_type.Add(obj.ElementAt(2)[j]);
                        break;
                    }
                }
            }
            for (int i = 0; i < obj.ElementAt(0).Count; i++)
            {
                if (!new_name.Contains(obj.ElementAt(0)[i]) )
                {
                    new_name.Add(obj.ElementAt(0)[i]);
                    new_value.Add(obj.ElementAt(1)[i]);
                    new_type.Add(obj.ElementAt(2)[i]);
                }
            }

            return new List<List<string>> { new_name, new_value, new_type};
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
            query = query.Substring(0, query.Length - 2);

            query += " FROM " + _table + ";";

            return query;
        }

        private string Insert()
        {
            string query = "INSERT INTO " + _table + " ";
            query += "(";
            int i = _name[0] == "Id" ? 1 : 0;
            for (; i < _name.Count; ++i)
            {
                query += _name[i] + ", ";
            }

            query = query.Substring(0, query.Length - 2);
            query += ") VALUES (";
            i = _name[0] == "Id" ? 1 : 0;
            for (; i < _value.Count; ++i)
            {
                if (_type[i] == "Decimal")
                    query += _value[i].Replace(',', '.') + ", ";
                else if(_value[i] == "Null")
                    query +=  _value[i] + ", ";
                else
                    query += "'" + _value[i] + "', ";
            }

            query = query.Substring(0, query.Length - 2);
            query += ");";

            return query;
        }

        private string Update()
        {
            string query = $"UPDATE {_table} ";
            query += "SET ";

            for (int i = 1; i < _name.Count; ++i)
            {
                if (_type[i] == "Decimal")
                    query += _name[i] + "=" + _value[i].Replace(',', '.') + ", ";
                else if (_value[i] == "Null")
                    query += _name[i] + "=" + _value[i] + ", ";
                else
                    query += _name[i] + "='" + _value[i] + "', ";
            }

            query = query.Substring(0, query.Length - 2);
            if (_whereColumn == null)
                query += $" WHERE Id={_value[0]};";
            else
            {
                int i;
                for (i = 0; i<_name.Count; ++i)
                {
                    if (_name[i].Contains(_whereColumn))
                        break;
                }
                query += $" WHERE {_whereColumn}='{_value[i]}';";
            }

            return query;
        }        

        private string Delete()
        {
            return $"DELETE FROM {_table} WHERE Id={_value[0]};";
        }

        private readonly IEnumerable<List<string>> _obj;
        private readonly string _table;
        private readonly string _whereColumn;
        private readonly List<string> _name;
        private readonly List<string> _value;
        private readonly List<string> _type;
    }
}
