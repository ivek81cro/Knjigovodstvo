using Knjigovodstvo.Database;
using Knjigovodstvo.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;

namespace Knjigovodstvo.BankStatements
{
    public class Izvod :IDbObject
    {
        public FormError ValidateData()
        {
            return FormError.None;
        }

        /// <summary>
        /// Sets Id property of current bank statement after insert into database
        /// </summary>
        public void GetCurrentId()
        {
            Id = int.Parse(
                new DbDataExecProcedure()
                .GetTable(ProcedureNames.Izvod_GetLastId)
                .Rows[0]
                .ItemArray[0].ToString());
        }

        /// <summary>
        /// Sets properties of bank statement by it's number from argument
        /// </summary>
        /// <param name="redniBroj"></param>
        public void GetIzvodByRedniBroj(int redniBroj)
        {
            DataTable dt = _dataGet.GetTable(this, $"Redni_broj={redniBroj}");

            Id = int.Parse(dt.Rows[0]["Id"].ToString());
            Redni_broj = int.Parse(dt.Rows[0]["Redni_broj"].ToString());
            Datum_izvoda = dt.Rows[0]["Datum_izvoda"].ToString();
            Suma_potrazna = decimal.Parse(dt.Rows[0]["Suma_potrazna"].ToString());
            Suma_dugovna = decimal.Parse(dt.Rows[0]["Suma_dugovna"].ToString());
            Stanje_prethodnog_izvoda = decimal.Parse(dt.Rows[0]["Stanje_prethodnog_izvoda"].ToString());
            Novo_stanje = decimal.Parse(dt.Rows[0]["Novo_stanje"].ToString());
            Promet = LoadPrometByIzvodId();
            Knjizen = dt.Rows[0]["Knjizen"].ToString() == "True";
        }
        
        /// <summary>
        /// Returns all items from individual bank statement as List<>
        /// </summary>
        /// <returns>List<IzvodPromet></returns>
        private List<IzvodPromet> LoadPrometByIzvodId()
        {
            DataTable dt = _dataGet.GetTable(new IzvodPromet(), $"Id_izvod={Id}");
            List<DataRow> rows = dt.AsEnumerable().ToList();
            List<IzvodPromet> izvodPromet = new List<IzvodPromet>();
            izvodPromet = (from DataRow dr in rows
                           select new IzvodPromet()
                           {
                               Id = int.Parse(dr["Id"].ToString()),
                               Id_izvod = int.Parse(dr["Id_izvod"].ToString()),
                               Dugovna = decimal.Parse(dr["Dugovna"].ToString()),
                               Potrazna = decimal.Parse(dr["Potrazna"].ToString()),
                               Oznaka = dr["Oznaka"].ToString(),
                               Naziv = dr["Naziv"].ToString(),
                               Opis = dr["Opis"].ToString(),
                               Konto = dr["Konto"].ToString()
                           }).ToList();

            return izvodPromet;
        }

        /// <summary>
        /// Insert new bank statement into database
        /// </summary>
        /// <returns>bool</returns>
        public bool InsertData()
        {
            return new DbDataInsert().InsertData(this);
        }

        /// <summary>
        /// Deletes bank statement in database
        /// </summary>
        /// <returns>bool</returns>
        public bool DeleteIzvod()
        {
            return new DbDataDelete().DeleteItem(this);
        }

        /// <summary>
        /// Returns all items from bank statement as DataTable
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetPrometData()
        {
            DataTable dt = new DataTable()
            {
                Columns =
                {
                    { "Naziv", typeof(string) },
                    { "Opis", typeof(string) },
                    { "Konto", typeof(string) },
                    { "Duguje", typeof(decimal) },
                    {"Potražuje", typeof(decimal) }
                }
            };

            foreach (var promet in Promet)
            {
                DataRow row = dt.NewRow();
                row["Naziv"] = promet.Naziv;
                row["Opis"] = promet.Opis;
                row["Konto"] = promet.Konto;
                row["Duguje"] = promet.Oznaka == "D" ? promet.Dugovna : 0;
                row["Potražuje"] = promet.Oznaka == "P" ? promet.Potrazna : 0;
                dt.Rows.Add(row);
            }

            return dt;
        }

        /// <summary>
        /// Update bank statement
        /// </summary>
        internal void UpdateData()
        {
            Datum_izvoda = DateTime
                .ParseExact(Datum_izvoda.Split(' ')[0], ("dd.MM.yyyy."), CultureInfo.InvariantCulture)
                .ToString("yyyy-MM-dd");

            new DbDataUpdate().UpdateData(this);
        }

        /// <summary>
        /// Checks if bank statemena exists in database
        /// </summary>
        /// <returns>bool</returns>
        public bool ExistsInDatabase()
        {
            return _dataGet.GetTable(this, $"Redni_broj={Redni_broj}").Rows.Count > 0;
        }

        private readonly DbDataGet _dataGet = new DbDataGet();
        public List<IzvodPromet> Promet = new List<IzvodPromet>();

        public int Id { get; set; } = 0;
        public int Redni_broj { get; set; } = 0;
        public string Datum_izvoda { get; set; } = "";
        public decimal Suma_potrazna { get; set; } = 0;
        public decimal Suma_dugovna { get; set; }
        public decimal Stanje_prethodnog_izvoda { get; set; } = 0;
        public decimal Novo_stanje { get; set; } = 0;
        public bool Knjizen { get; set; } = false;
    }
}
