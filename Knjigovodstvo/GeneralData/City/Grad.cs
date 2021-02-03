using Knjigovodstvo.Database;
using Knjigovodstvo.Interface;
using System;
using System.Data;

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

        public DataTable GetGradDataTable()
        {
            return new DbDataGet().GetTable(this);
        }

        public DataTable GetGradDataTable(string condition)
        {
            return new DbDataGet().GetTable(this, condition);
        }

        internal bool InsertNew()
        {
            if (new DbDataInsert().InsertData(this))
                return true;

            return false;
        }

        internal bool UpdateData()
        {
            if (new DbDataUpdate().UpdateData(this))
                return true;

            return false;
        }

        internal bool DeleteGrad()
        {
            return new DbDataDelete().DeleteItem(this);
        }

        internal void GetGradById(int id)
        {
            DataTable dataTable = GetGradDataTable($"Id={id};");
            SetPrivateMembers(dataTable);
        }

        internal Grad GetGradByMjesto(string mjesto)
        {
            DataTable dataTable = GetGradDataTable($"Mjesto='{mjesto}';");
            SetPrivateMembers(dataTable);

            return this;
        }

        /// <summary>
        /// Gets cities from specific county. 
        /// </summary>
        /// <param name="county">Name of county (Županija)</param>
        /// <returns>DataTable</returns>
        public DataTable GetGradoviByZupanija(string county)
        {
            DataTable dt = GetGradDataTable($"Zupanija='{county}'");

            DataRow row = dt.NewRow();
            row[0] = 0;
            row[1] = "Odaberite Grad";
            dt.Rows.InsertAt(row, 0);
            return dt;
        }

        private void SetPrivateMembers(DataTable dataTable)
        {
            Id = int.Parse(dataTable.Rows[0]["Id"].ToString());
            Mjesto = dataTable.Rows[0]["Mjesto"].ToString();
            Zupanija = dataTable.Rows[0]["Zupanija"].ToString();
            Drzava = dataTable.Rows[0]["Drzava"].ToString();
            Posta = dataTable.Rows[0]["Posta"].ToString();
            Prirez = decimal.Parse(dataTable.Rows[0]["Prirez"].ToString());
            Sifra = dataTable.Rows[0]["Sifra"].ToString();
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
