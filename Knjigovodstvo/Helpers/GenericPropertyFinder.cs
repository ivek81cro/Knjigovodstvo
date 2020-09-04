using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Knjigovodstvo.Helpers
{
    public class GenericPropertyFinder<TModel> where TModel : class
    {
        /// <summary>
        /// Gets names and values of object as lists of strings
        /// </summary>
        /// <returns>Lists of strings</returns>
        public IEnumerable<List<String>> PrintTModelPropertyAndValue(TModel tmodelObj)
        {
            //Getting Type of Generic Class Model
            Type tModelType = tmodelObj.GetType();

            //We will be defining a PropertyInfo Object which contains details about the class property 
            PropertyInfo[] arrayPropertyInfos = tModelType.GetProperties();

            List<string> propName = new List<string>();
            List<string> propValue = new List<string>();
            //Now we will loop in all properties one by one to get value
            foreach (PropertyInfo property in arrayPropertyInfos)
            {
                propName.Add(property.Name.ToString());
                propValue.Add(property.GetValue(tmodelObj).ToString());
            }

            return new List<List<String>> { propName, propValue };
        }
    }
}
