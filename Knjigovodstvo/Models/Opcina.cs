using Knjigovodstvo.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Knjigovodstvo.Models
{
    public class Opcina : IDbObject
    {
        public FormError ValidateData()
        {
            if (Naziv.Length < 2 || Naziv.StartsWith("Odaberite"))
                return FormError.Name;
            if (Zupanija.Length < 2 || Zupanija.StartsWith("Odaberite"))
                return FormError.County;
            if (Drzava.Length < 2)
                return FormError.Country;
            if (Posta.Length != 5)
                return FormError.Post;

            return FormError.None;
        }

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
                            Posta = "00000"
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

        public int Id { get; set; } = 0;
        public string Naziv { get; set; } = "";
        public string Zupanija { get; set; } = "";
        public string Drzava { get; set; } = "";
        public string Posta { get; set; } = "";
    }
}
