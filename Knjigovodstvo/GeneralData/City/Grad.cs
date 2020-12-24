﻿using Knjigovodstvo.Database;
using Knjigovodstvo.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace Knjigovodstvo.City
{
    public class Grad : IDbObject
    {
        public FormError ValidateData()
        {
            if (Mjesto.Length < 2 || Mjesto.StartsWith("Odaberite"))
                return FormError.Name;
            if (Zupanija.Length < 2 || Zupanija.StartsWith("Odaberite"))
                return FormError.County;
            if (Drzava.Length < 2)
                return FormError.Country;
            if (Posta.Length != 5 && Posta != "0")
                return FormError.Post;
            if (Sifra.Length != 5)
                return FormError.Sifra;
            if (Prirez > 100 || Prirez < 0)
                return FormError.NumberFormat;

            return FormError.None;
        }

        /// <summary>
        /// Gets list of cities from database.
        /// </summary>
        /// <returns>List of City</returns>
        public List<Grad> GetAllGrad()
        {            
            DataTable dt = new DbDataGet().GetTable(new Grad());
            List<DataRow> rows = dt.AsEnumerable().ToList();
            List<Grad> cityList = new List<Grad>();
            cityList = (from DataRow dr in rows
                        select new Grad()
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Mjesto = dr["Naziv"].ToString(),
                            Drzava = dr["Drzava"].ToString(),
                            Zupanija = dr["Zupanija"].ToString(),
                            Posta = dr["Posta"].ToString(),
                            Sifra = dr["Sifra"].ToString()
                        }).ToList();

            return cityList;
        }

        internal void GetGradById(int id)
        {
            string condition = $"Id={id};";
            DataTable grad = new DbDataGet().GetTable(this, condition);

            Id = int.Parse(grad.Rows[0]["Id"].ToString());
            Mjesto = grad.Rows[0]["Mjesto"].ToString();
            Zupanija = grad.Rows[0]["Zupanija"].ToString();
            Drzava = grad.Rows[0]["Drzava"].ToString();
            Posta = grad.Rows[0]["Posta"].ToString();
            Prirez = decimal.Parse(grad.Rows[0]["Prirez"].ToString());
            Sifra = grad.Rows[0]["Sifra"].ToString();
        }

        /// <summary>
        /// Gets cities from specific county. 
        /// </summary>
        /// <param name="county">Name of county (Županija)</param>
        /// <returns>DataTable</returns>
        public DataTable GetGradoviByZupanija(string county)
        {
            string condition = $"Zupanija='{county}'";
            DataTable dt = new DbDataGet().GetTable(this, condition);

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

        internal bool UpdateData()
        {
            if (new DbDataUpdate().UpdateData(this, $"Mjesto='{Mjesto}'"))
                return true;

            return false;
        }

        public int Id { get; set; } = 0;
        public string Mjesto { get; set; } = "";
        public string Zupanija { get; set; } = "";
        public string Drzava { get; set; } = "";
        public string Posta { get; set; } = "";
        public decimal Prirez { get; set; } = 1;
        public string Sifra { get; set; } = "";
    }
}
