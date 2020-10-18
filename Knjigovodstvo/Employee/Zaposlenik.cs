using Knjigovodstvo.City;
using Knjigovodstvo.Code.Validators;
using Knjigovodstvo.Helpers;
using Knjigovodstvo.Models;
using System;
using System.Data;

namespace Knjigovodstvo.Employee
{
    public class Zaposlenik : IDbObject
    {
        public FormError ValidateData()
        {
            if (!new OibValidator().Validate(Oib))
                return FormError.Oib;
            if (Ime.Length < 2)
                return FormError.Name;
            if (Prezime.Length < 2)
                return FormError.Street;
            if (Adresa.Length < 2)
                return FormError.Street;
            if (Grad.Length < 2)
                return FormError.City;

            return FormError.None;
        }

        public bool InsertNew()
        {
            if (new DbDataInsert().InsertData(this))
                return true;

            return false;
        }

        public bool UpdateData(int id)
        {
            Id = id;
            if (new DbDataUpdate().UpdateData(this))
                return true;

            return false;
        }

        internal Zaposlenik GetZaposlenikByOib(string oib)
        {
            string condition = $"Oib='{oib}';";
            DataTable zaposlenik = new DbDataGet().GetTable(new Zaposlenik(), condition);

            return new Zaposlenik
            {
                Id = int.Parse(zaposlenik.Rows[0][0].ToString()),
                Oib = zaposlenik.Rows[0][1].ToString(),
                Ime = zaposlenik.Rows[0][2].ToString(),
                Prezime = zaposlenik.Rows[0][3].ToString(),
                DatumRodenja = zaposlenik.Rows[0][4].ToString(),
                Adresa = zaposlenik.Rows[0][5].ToString(),
                Grad = zaposlenik.Rows[0][6].ToString(),
                Drzava = zaposlenik.Rows[0][7].ToString(),
                Telefon = zaposlenik.Rows[0][8].ToString(),
                StručnaSprema = zaposlenik.Rows[0][9].ToString(),
                Olaksica = float.Parse(zaposlenik.Rows[0][10].ToString()),
                DatumDolaska = zaposlenik.Rows[0][11].ToString(),
                DatumOdlaska = zaposlenik.Rows[0][12].ToString()
            };
        }

        public Zaposlenik GetZaposlenikById(int id)
        {
            string condition = $"Id={id};";
            DataTable zaposlenik = new DbDataGet().GetTable(new Zaposlenik(), condition);

            return new Zaposlenik
            {
                Id = int.Parse(zaposlenik.Rows[0][0].ToString()),
                Oib = zaposlenik.Rows[0][1].ToString(),
                Ime = zaposlenik.Rows[0][2].ToString(),
                Prezime = zaposlenik.Rows[0][3].ToString(),
                DatumRodenja = zaposlenik.Rows[0][4].ToString(),
                Adresa = zaposlenik.Rows[0][5].ToString(),
                Grad = zaposlenik.Rows[0][6].ToString(),
                Drzava = zaposlenik.Rows[0][7].ToString(),
                Telefon = zaposlenik.Rows[0][8].ToString(),
                StručnaSprema = zaposlenik.Rows[0][9].ToString(),
                Olaksica = float.Parse(zaposlenik.Rows[0][10].ToString()),
                DatumDolaska = zaposlenik.Rows[0][11].ToString(),
                DatumOdlaska = zaposlenik.Rows[0][12].ToString()
            };
        }

        public int Id { get; set; } = 0;
        public string Oib { get; set; } = "";
        public string Ime { get; set; } = "";
        public string Prezime { get; set; } = "";
        public string DatumRodenja { get; set; } = "";
        public string Adresa { get; set; } = "";
        public string Grad { get; set; } = "";
        public string Drzava { get; set; } = "";
        public string Telefon { get; set; } = "";
        public string StručnaSprema { get; set; } = "";
        public float Olaksica { get; set; } = 0;
        public string DatumDolaska { get; set; } = "";
        public string DatumOdlaska { get; set; } = "";
    }
}
