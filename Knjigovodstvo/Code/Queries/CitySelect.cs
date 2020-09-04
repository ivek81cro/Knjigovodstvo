﻿using Knjigovodstvo.Helpers;
using Knjigovodstvo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Knjigovodstvo.Code.Cities
{
    class CitySelect
    {
        /// <summary>
        /// Gets list of cities from database.
        /// </summary>
        /// <returns>List of City</returns>
        public List<Opcina> GetAllCities()
        {
            DbDataGet data = new DbDataGet();
            DataTable dt = data.GetTable(new Opcina());
            List<DataRow> rows = dt.AsEnumerable().ToList();
            List<Opcina> cityList = new List<Opcina>();
            cityList = (from DataRow dr in rows
                           select new Opcina()
                           {
                               Naziv = dr["Naziv"].ToString(),
                               Drzava = "Hrvatska",//TODO Add country to City
                               Zupanija = dr["Zupanija"].ToString(),
                               Posta = "00000"//TODO link post number to cities
                           }).ToList();

            return cityList;
        }

        /// <summary>
        /// Gets cities from specific county. 
        /// </summary>
        /// <param name="county">Name of county (Županija)</param>
        /// <returns>DataTable</returns>
        public DataTable GetCityByCounty(string county)
        {
            DbDataGet data = new DbDataGet();
            string condition = String.Format("Zupanija='{0}'", county);
            DataTable dt = data.GetTable(new Opcina(), condition);

            DataRow row = dt.NewRow();
            row[0] = 0;
            row[1] = "Odaberite Grad";
            dt.Rows.InsertAt(row, 0);
            return dt;
        }
    }
}
