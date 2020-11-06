using Knjigovodstvo.City;
using Knjigovodstvo.Code.Validators;
using Knjigovodstvo.Database;
using Knjigovodstvo.Global;
using Knjigovodstvo.Interface;
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
            if (Adresa.Ulica.Length < 2)
                return FormError.Street;
            if (Adresa.Grad.Mjesto.Length < 2)
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
                Datum_Rodenja = zaposlenik.Rows[0]["Datum_Rodenja"].ToString(),
                Adresa = new Adresa()
                {
                    Ulica = zaposlenik.Rows[0]["Ulica"].ToString(),
                    Broj = zaposlenik.Rows[0]["Broj"].ToString(),
                    Grad = new Grad()
                    {
                        Mjesto = zaposlenik.Rows[0]["Mjesto"].ToString(),
                        Drzava = zaposlenik.Rows[0]["Drzava"].ToString(),
                    }
                },
                Kontakt = new Kontakt()
                {
                    Telefon = zaposlenik.Rows[0]["Telefon"].ToString()
                },
                Stručna_Sprema = zaposlenik.Rows[0]["Stručna_Sprema"].ToString(),
                Olaksica = decimal.Parse(zaposlenik.Rows[0]["Olaksica"].ToString()),
                Datum_Dolaska = zaposlenik.Rows[0]["Datum_Dolaska"].ToString(),
                Datum_Odlaska = zaposlenik.Rows[0]["Datum_Odlaska"].ToString()
            };
        }

        public Zaposlenik GetZaposlenikById(int id)
        {
            string condition = $"Id={id};";
            DataTable zaposlenik = new DbDataGet().GetTable(new Zaposlenik(), condition);

            return new Zaposlenik
            {
                Id = int.Parse(zaposlenik.Rows[0]["Id"].ToString()),
                Oib = zaposlenik.Rows[0]["Oib"].ToString(),
                Ime = zaposlenik.Rows[0]["Ime"].ToString(),
                Prezime = zaposlenik.Rows[0]["Prezime"].ToString(),
                Datum_Rodenja = zaposlenik.Rows[0]["Datum_Rodenja"].ToString(),
                Adresa = new Adresa()
                {
                    Ulica = zaposlenik.Rows[0]["Ulica"].ToString(),
                    Broj = zaposlenik.Rows[0]["Broj"].ToString(),
                    Grad = new Grad()
                    {
                        Mjesto = zaposlenik.Rows[0]["Mjesto"].ToString(),
                        Drzava = zaposlenik.Rows[0]["Drzava"].ToString(),
                    }
                },
                Kontakt = new Kontakt()
                {
                    Telefon = zaposlenik.Rows[0]["Telefon"].ToString()
                },
                Stručna_Sprema = zaposlenik.Rows[0]["Stručna_Sprema"].ToString(),
                Olaksica = decimal.Parse(zaposlenik.Rows[0]["Olaksica"].ToString()),
                Datum_Dolaska = zaposlenik.Rows[0]["Datum_Dolaska"].ToString(),
                Datum_Odlaska = zaposlenik.Rows[0]["Datum_Odlaska"].ToString()
            };
        }

        public int Id { get; set; } = 0;
        public string Oib { get; set; } = "";
        public string Ime { get; set; } = "";
        public string Prezime { get; set; } = "";
        public string Datum_Rodenja { get; set; } = "";
        public Adresa Adresa { get; set; } = new Adresa();
        public Kontakt Kontakt { get; set; } = new Kontakt();
        public string Stručna_Sprema { get; set; } = "";
        public decimal Olaksica { get; set; } = 0;
        public string Datum_Dolaska { get; set; } = "";
        public string Datum_Odlaska { get; set; } = "";
    }
}
