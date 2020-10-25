using Knjigovodstvo.Database;
using Knjigovodstvo.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Knjigovodstvo.City
{
    public class Grad : IDbObject
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
            if (Sifra.Length != 5)
                return FormError.Sifra;

            return FormError.None;
        }

        /// <summary>
        /// Gets list of cities from database.
        /// </summary>
        /// <returns>List of City</returns>
        public List<Grad> GetAllGrad()
        {
            DbDataGet data = new DbDataGet();
            DataTable dt = data.GetTable(new Grad());
            List<DataRow> rows = dt.AsEnumerable().ToList();
            List<Grad> cityList = new List<Grad>();
            cityList = (from DataRow dr in rows
                        select new Grad()
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Naziv = dr["Naziv"].ToString(),
                            Drzava = dr["Drzava"].ToString(),
                            Zupanija = dr["Zupanija"].ToString(),
                            Posta = dr["Posta"].ToString(),
                            Sifra = dr["Sifra"].ToString()
                        }).ToList();

            return cityList;
        }

        internal Grad GetGradById(int id)
        {
            string condition = $"Id={id};";
            DataTable grad = new DbDataGet().GetTable(new Grad(), condition);

            return new Grad
            {
                Id = int.Parse(grad.Rows[0]["Id"].ToString()),
                Naziv = grad.Rows[0]["Naziv"].ToString(),
                Zupanija = grad.Rows[0]["Zupanija"].ToString(),
                Drzava = grad.Rows[0]["Drzava"].ToString(),
                Posta = grad.Rows[0]["Posta"].ToString(),
                Prirez = float.Parse(grad.Rows[0]["Prirez"].ToString()),
                Sifra = grad.Rows[0]["Sifra"].ToString()
            };
        }

        /// <summary>
        /// Gets cities from specific county. 
        /// </summary>
        /// <param name="county">Name of county (Županija)</param>
        /// <returns>DataTable</returns>
        public DataTable GetGradoviByZupanija(string county)
        {
            DbDataGet data = new DbDataGet();
            string condition = $"Zupanija='{county}'";
            DataTable dt = data.GetTable(new Grad(), condition);

            DataRow row = dt.NewRow();
            row[0] = 0;
            row[1] = "Odaberite Grad";
            dt.Rows.InsertAt(row, 0);
            return dt;
        }

        internal bool InsertNew()
        {
            if(new DbDataInsert().InsertData(this))
                return true;

            return false;
        }

        internal bool UpdateData(int id)
        {
            Id = id;
            if (new DbDataUpdate().UpdateData(this))
                return true;

            return false;
        }

        public int Id { get; set; } = 0;
        public string Naziv { get; set; } = "";
        public string Zupanija { get; set; } = "";
        public string Drzava { get; set; } = "";
        public string Posta { get; set; } = "";
        public float Prirez { get; set; } = 1;
        public string Sifra { get; set; } = "";
    }
}
