using Knjigovodstvo.City;
using Knjigovodstvo.Code.Validators;
using Knjigovodstvo.Database;
using Knjigovodstvo.Global;
using Knjigovodstvo.Interface;
using Knjigovodstvo.JoppdDocument;
using Knjigovodstvo.Wages;
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

        /// <summary>
        /// Inserts new employee in database table
        /// </summary>
        /// <returns>bool</returns>
        public bool InsertNew()
        {
            if (new DbDataInsert().InsertData(this))
                return true;

            return false;
        }

        /// <summary>
        /// Updates table in database for selected employee
        /// </summary>
        /// <returns>bool</returns>
        public bool UpdateData()
        {
            if (new DbDataUpdate().UpdateData(this))
                return true;

            return false;
        }

        /// <summary>
        /// <para>Returns employee table as DataTable based on condition</para>
        /// <para>Example - Condition format as string $"Oib='{oib}'"</para>
        /// </summary>
        /// <param name="condition"></param>
        /// <returns>DataTable</returns>
        internal DataTable GetZaposlenikDataTable(string condition = null)
        {
            return new DbDataGet().GetTable(this, condition);
        }

        /// <summary>
        /// Returns employee table as DataTable
        /// </summary>
        /// <returns>DataTable</returns>
        internal DataTable GetZaposlenikDataTable()
        {
            return new DbDataGet().GetTable(this);
        }

        /// <summary>
        /// Sets properties of employee based on set Id
        /// </summary>
        public void GetZaposlenikById()
        {
            DataRow row = GetZaposlenikDataTable($"Id={Id}").Rows[0];
            SetPrivateMembers(row);
        }

        /// <summary>
        /// Sets properties of employee based on set Id
        /// </summary>
        public void GetZaposlenikByOib()
        {
            DataRow row = GetZaposlenikDataTable($"Oib='{Oib}'").Rows[0];
            SetPrivateMembers(row);
        }

        /// <summary>
        /// Sets properties of employee based on Id argument
        /// </summary>
        /// <param name="oib"></param>
        public void GetZaposlenikByOib(string oib)
        {
            DataRow row = GetZaposlenikDataTable($"Oib='{oib}'").Rows[0];
            SetPrivateMembers(row);
        }

        /// <summary>
        /// Deletes selected employee from database and wage settings related to him, excep archive data
        /// </summary>
        /// <returns>bool</returns>
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

        /// <summary>
        /// Returns list of employees from database as List<>
        /// </summary>
        /// <returns>List<Zaposlenik></returns>
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

        /// <summary>
        /// Sets tax based on employee residency
        /// </summary>
        private void SetPrirez()
        {
            if (Adresa.Grad.Mjesto != "")
            {
                DataTable dt = new DbDataGet().GetTable(Adresa.Grad, $"Mjesto='{Adresa.Grad.Mjesto}'");
                Adresa.Grad.Prirez = decimal.Parse(dt.Rows[0]["Prirez"].ToString());
            }
        }

        private void SetPrivateMembers(DataRow row)
        {
            Id = int.Parse(row["Id"].ToString());
            Oib = row["Oib"].ToString();
            Ime = row["Ime"].ToString();
            Prezime = row["Prezime"].ToString();
            Adresa.Ulica = row["Ulica"].ToString();
            Adresa.Broj = row["Broj"].ToString();
            Adresa.Grad.Mjesto = row["Mjesto"].ToString();
            Adresa.Grad.Drzava = row["Drzava"].ToString();
            Kontakt.Telefon = row["Telefon"].ToString();
            Stručna_Sprema = row["Stručna_Sprema"].ToString();
            Olaksica = decimal.Parse(row["Olaksica"].ToString());
            Datum_Dolaska = row["Datum_Dolaska"].ToString();
            Datum_Odlaska = row["Datum_Odlaska"].ToString();

            SetPrirez();
        }

        public int Id { get; set; } = 0;
        public string Oib { get; set; } = "";
        public string Ime { get; set; } = "";
        public string Prezime { get; set; } = "";
        public Adresa Adresa { get; set; } = new Adresa();
        public Kontakt Kontakt { get; set; } = new Kontakt();
        public string Stručna_Sprema { get; set; } = "";
        public decimal Olaksica { get; set; } = 0;
        public string Datum_Dolaska { get; set; } = "";
        public string Datum_Odlaska { get; set; } = "";
    }
}
