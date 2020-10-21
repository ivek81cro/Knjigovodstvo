using Knjigovodstvo.Code.Validators;
using Knjigovodstvo.Database;
using Knjigovodstvo.Models;
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
                Id = int.Parse(zaposlenik.Rows[0]["Id"].ToString()),
                Oib = zaposlenik.Rows[0]["Oib"].ToString(),
                Ime = zaposlenik.Rows[0]["Ime"].ToString(),
                Prezime = zaposlenik.Rows[0]["Prezime"].ToString(),
                Datum_Rodenja = zaposlenik.Rows[0]["Datum Rodenja"].ToString(),
                Adresa = zaposlenik.Rows[0]["Adresa"].ToString(),
                Grad = zaposlenik.Rows[0]["Grad"].ToString(),
                Drzava = zaposlenik.Rows[0]["Drzava"].ToString(),
                Telefon = zaposlenik.Rows[0]["Telefon"].ToString(),
                Stručna_Sprema = zaposlenik.Rows[0]["Stručna Sprema"].ToString(),
                Olaksica = float.Parse(zaposlenik.Rows[0]["Olaksica"].ToString()),
                Datum_Dolaska = zaposlenik.Rows[0]["Datum Dolaska"].ToString(),
                Datum_Odlaska = zaposlenik.Rows[0]["Datum Odlaska"].ToString()
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
                Datum_Rodenja = zaposlenik.Rows[0][4].ToString(),
                Adresa = zaposlenik.Rows[0][5].ToString(),
                Grad = zaposlenik.Rows[0][6].ToString(),
                Drzava = zaposlenik.Rows[0][7].ToString(),
                Telefon = zaposlenik.Rows[0][8].ToString(),
                Stručna_Sprema = zaposlenik.Rows[0][9].ToString(),
                Olaksica = float.Parse(zaposlenik.Rows[0][10].ToString()),
                Datum_Dolaska = zaposlenik.Rows[0][11].ToString(),
                Datum_Odlaska = zaposlenik.Rows[0][12].ToString()
            };
        }

        public int Id { get; set; } = 0;
        public string Oib { get; set; } = "";
        public string Ime { get; set; } = "";
        public string Prezime { get; set; } = "";
        public string Datum_Rodenja { get; set; } = "";
        public string Adresa { get; set; } = "";
        public string Grad { get; set; } = "";
        public string Drzava { get; set; } = "";
        public string Telefon { get; set; } = "";
        public string Stručna_Sprema { get; set; } = "";
        public float Olaksica { get; set; } = 0;
        public string Datum_Dolaska { get; set; } = "";
        public string Datum_Odlaska { get; set; } = "";
    }
}
