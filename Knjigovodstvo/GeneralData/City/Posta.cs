﻿using Knjigovodstvo.Database;
using Knjigovodstvo.Interface;
using System.Data;

namespace Knjigovodstvo.City
{
    class Posta : IDbObject
    {
        public FormError ValidateData()
        {
            return FormError.None;
        }

        public DataTable GetPostaByGrad(string grad)
        {
            string condition = $"Mjesto='{grad}'";
            DbDataGet data = new DbDataGet();
            DataTable dt = data.GetTable(this, condition);

            return dt;
        }

        public int BrojPu { get; set; } = 0;
        public string Adresa { get; set; } = "";
        public string Mjesto { get; set; } = "";
        public string Grad { get; set; } = "";
        public string Zupanija { get; set; } = "";
    }
}
