using Knjigovodstvo.BankStatements;
using Knjigovodstvo.Books.URA;
using Knjigovodstvo.Database;
using Knjigovodstvo.Interface;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Knjigovodstvo.Global.BaseClass
{
    public class Parovi : IDbObject
    {
        public FormError ValidateData()
        {
            return FormError.None;
        }

        public bool InsertData()
        {
            return new DbDataInsert().InsertData(this);
        }

        /// <summary>
        /// Returns if statement exists in database based on "Naziv"
        /// </summary>
        /// <returns></returns>
        public bool ExistsInDbByNaziv()
        {
            return new DbDataGet().GetTable(this, $"Naziv='{Naziv}'").Rows.Count > 0;
        }

        /// <summary>
        /// Returns list of saved pairs by user
        /// </summary>
        /// <returns></returns>
        public List<Parovi> GetParoviList()
        {
            DataTable dt;
            string derivedName = _derivedName;
            if (_derivedName == "KnjigaUraParovi")
            {
                dt = new DbDataGet().GetTable(new KnjigaUraParovi());             
            }
            else
            {
                dt = new DbDataGet().GetTable(new IzvodParovi());
            }

            List<DataRow> rows = dt.AsEnumerable().ToList();
            List<Parovi> parovi = new List<Parovi>();
            parovi = (from DataRow dr in rows
                      select new Parovi()
                      {
                          Id = int.Parse(dr["Id"].ToString()),
                          Naziv = dr["Naziv"].ToString(),
                          Id_Konto = int.Parse(dr["Id_Konto"].ToString()),
                          _derivedName = derivedName
                      }).ToList();
            return parovi;
        }

        protected string _derivedName;

        public int Id { get; set; } = 0;
        public string Naziv { get; set; } = "";
        public int Id_Konto { get; set; } = 0;
    }
}
