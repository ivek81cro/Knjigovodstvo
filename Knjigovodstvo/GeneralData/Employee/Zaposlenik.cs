using Knjigovodstvo.City;
using Knjigovodstvo.Code.Validators;
using Knjigovodstvo.Database;
using Knjigovodstvo.Global;
using Knjigovodstvo.Interface;
using Knjigovodstvo.JoppdDocument;
using Knjigovodstvo.Payroll;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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

        public bool UpdateData()
        {
            if (new DbDataUpdate().UpdateData(this))
                return true;

            return false;
        }

        public bool DeleteZaposlenik()
        {
            DbDataDelete del = new DbDataDelete();
            
            Placa p = new Placa();
            p.GetPlacaByOib(Oib);
            del.DeleteItem(p);
            
            ZaposlenikJoppd z = new ZaposlenikJoppd();
            z = z.GetZaposlenikByOib(Oib);
            del.DeleteItem(z);
            
            Dodatak d = new Dodatak();
            foreach (DataRow row in d.GetDodaciByOib(Oib).Rows)
            {
                del.DeleteItem(
                    new Dodatak() 
                    { 
                        Id = int.Parse(row.ItemArray[0].ToString())
                    });
            }
            
            return del.DeleteItem(this);
        }

        internal void GetZaposlenikByOib(string oib)
        {
            string condition = $"Oib='{oib}';";
            DataTable dt = new DbDataGet().GetTable(this, condition);

            SetPrivateMembers(dt);
        }

        private void SetPrirez()
        {
            if (Adresa.Grad.Mjesto != "")
            {
                DataTable dt = new DbDataGet().GetTable(Adresa.Grad, $"Mjesto='{Adresa.Grad.Mjesto}'");
                Adresa.Grad.Prirez = decimal.Parse(dt.Rows[0]["Prirez"].ToString());
            }
        }

        public void GetZaposlenikById()
        {
            DataTable zaposlenik = new DbDataGet().GetTable(this, $"Id={Id}");
            SetPrivateMembers(zaposlenik);
        }

        public List<Zaposlenik> GetListZaposlenik()
        {
            DataTable dt = new DbDataGet().GetTable(this);
            List<DataRow> rows = dt.AsEnumerable().ToList();
            List<Zaposlenik> zaposlenikList = new List<Zaposlenik>();
            zaposlenikList = (from DataRow dr in rows
                        select new Zaposlenik()
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Oib = dr["Oib"].ToString(),
                            Ime = dr["Ime"].ToString(),
                            Prezime = dr["Prezime"].ToString(),
                            Datum_Rodenja = dr["Datum_Rodenja"].ToString(),
                            Adresa = new Adresa()
                            {
                                Ulica = dr["Ulica"].ToString(),
                                Broj = dr["Broj"].ToString(),
                                Grad = new Grad()
                                {
                                    Mjesto = dr["Mjesto"].ToString(),
                                    Drzava = dr["Drzava"].ToString()
                                }
                            },
                            Kontakt = new Kontakt()
                            {
                                Telefon = dr["Telefon"].ToString()
                            },
                            Stručna_Sprema = dr["Stručna_Sprema"].ToString(),
                            Olaksica = decimal.Parse(dr["Olaksica"].ToString()),
                            Datum_Dolaska = dr["Datum_Dolaska"].ToString(),
                            Datum_Odlaska = dr["Datum_Odlaska"].ToString()

                        }).ToList();

            return zaposlenikList;
        }

        private void SetPrivateMembers(DataTable zaposlenik)
        {
            Id = int.Parse(zaposlenik.Rows[0]["Id"].ToString());
            Oib = zaposlenik.Rows[0]["Oib"].ToString();
            Ime = zaposlenik.Rows[0]["Ime"].ToString();
            Prezime = zaposlenik.Rows[0]["Prezime"].ToString();
            Datum_Rodenja = zaposlenik.Rows[0]["Datum_Rodenja"].ToString();
            Adresa.Ulica = zaposlenik.Rows[0]["Ulica"].ToString();
            Adresa.Broj = zaposlenik.Rows[0]["Broj"].ToString();
            Adresa.Grad.Mjesto = zaposlenik.Rows[0]["Mjesto"].ToString();
            Adresa.Grad.Drzava = zaposlenik.Rows[0]["Drzava"].ToString();
            Kontakt.Telefon = zaposlenik.Rows[0]["Telefon"].ToString();
            Stručna_Sprema = zaposlenik.Rows[0]["Stručna_Sprema"].ToString();
            Olaksica = decimal.Parse(zaposlenik.Rows[0]["Olaksica"].ToString());
            Datum_Dolaska = zaposlenik.Rows[0]["Datum_Dolaska"].ToString();
            Datum_Odlaska = zaposlenik.Rows[0]["Datum_Odlaska"].ToString();

            SetPrirez();
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
