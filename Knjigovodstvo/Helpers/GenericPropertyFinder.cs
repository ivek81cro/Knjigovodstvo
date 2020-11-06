using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Knjigovodstvo.Helpers
{
    public class GenericPropertyFinder<TModel> where TModel : class
    {
        /// <summary>
        /// Gets names and values of object as lists of strings
        /// </summary>
        /// <returns>Lists of strings</returns>
        public IEnumerable<List<string>> PrintTModelPropertyAndValue(TModel tmodelObj)
        {
            //Getting Type of Generic Class Model
            Type tModelType = tmodelObj.GetType();

            //Getting Type Name as database table name
            _tableName[0] = tModelType.Name;

            GetTableNames();

            //Now we will loop in all properties one by one to get value
            FindNestedClassProperties(tmodelObj);

            return new List<List<string>> { _propName, _propValue, _propType };
        }

        private void FindNestedClassProperties(object propValue, int level = 0)
        {
            if (propValue == null)
                return;

            var childProps = propValue.GetType().GetProperties();
            foreach (var property in childProps)
            {
                if (CheckIfInTable(property.Name.ToString()))
                {
                    _propName.Add(property.Name.ToString());
                    _propValue.Add(property.GetValue(propValue).ToString());
                    _propType.Add(property.PropertyType.Name.ToString());
                    _items.Remove("Id");
                }
                else if(property.DeclaringType.Name == _tableName[level]
                    && property.PropertyType != typeof(string)
                    && !property.GetType().IsValueType)
                {
                    //When going into next level nested object, save current as table name
                    _tableName[level + 1] = property.GetValue(propValue).GetType().Name;
                    FindNestedClassProperties(property.GetValue(propValue), level + 1);
                }
            }
        }

        /// <summary>
        /// Gets name of existing tables from database
        /// </summary>
        private void GetTableNames()
        {
            DataTable dt = new DataTable();
            try
            {
                using SqlConnection conn = new SqlConnection(ConnHelper.ConnStr("KnjigovodstvoDb"));
                string query = $"SELECT name FROM sys.columns WHERE object_id = OBJECT_ID('{_tableName[0]}')";
                using SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                //Fill the DataTable with records from Table.
                sda.Fill(dt);
            }
            catch 
            {
                
            }

            foreach(DataRow row in dt.Rows)
            {
                _items.Add(row.ItemArray[0].ToString());
            }
        }

        private bool CheckIfInTable(string table)
        {
            if (_items.Contains(table))
                return true;

            return false;
        }

        private List<string> _propName = new List<string>();
        private List<string> _propValue = new List<string>();
        private List<string> _propType = new List<string>();
        private List<string> _items = new List<string>();
        private string[] _tableName = new string[10];
    }
}
