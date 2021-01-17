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
            throw new NotImplementedException();
        }

        internal void GetCurrentId()
        {
            Id = int.Parse(
                new DbDataExecProcedure()
                .GetTable(ProcedureNames.Izvod_GetLastId)
                .Rows[0]
                .ItemArray[0].ToString());
        }

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

        internal bool InsertData()
        {
            return new DbDataInsert().InsertData(this);
        }

        internal bool DeleteIzvod()
        {
            return new DbDataDelete().DeleteItem(this);
        }

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

        internal void UpdateData()
        {
            Datum_izvoda = DateTime
                .ParseExact(Datum_izvoda.Split(' ')[0], ("dd.MM.yyyy."), CultureInfo.InvariantCulture)
                .ToString("yyyy-MM-dd");

            new DbDataUpdate().UpdateData(this);
        }

        public bool ExistsInDatabase()
        {
            return _dataGet.GetTable(this, $"Redni_broj={Redni_broj}").Rows.Count > 0;
        }

        public int Id { get; set; } = 0;
        public int Redni_broj { get; set; } = 0;
        public string Datum_izvoda { get; set; } = "";
        public decimal Suma_potrazna { get; set; } = 0;
        public decimal Suma_dugovna { get; set; }
        public decimal Stanje_prethodnog_izvoda { get; set; } = 0;
        public decimal Novo_stanje { get; set; } = 0;
        public bool Knjizen { get; set; } = false;

        public List<IzvodPromet> Promet = new List<IzvodPromet>();

        private DbDataGet _dataGet = new DbDataGet();
    }
}
