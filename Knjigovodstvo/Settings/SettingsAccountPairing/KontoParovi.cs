using Knjigovodstvo.Database;
using Knjigovodstvo.Interface;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Knjigovodstvo.Settings
{
    public class KontoParovi : IDbObject
    {
        public KontoParovi(BookNames bookName)
        {
            Knjiga = bookName.ToString();
        }

        private KontoParovi()
        {
        }

        public DataTable GetKontoParoviDataTable(string condition)
        {
            return new DbDataGet().GetTable(this, condition);
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
            return new DbDataGet().GetTable(this, $"Knjiga={Knjiga} AND Naziv='{Naziv}'").Rows.Count > 0;
        }

        /// <summary>
        /// Returns list of saved pairs by user
        /// </summary>
        /// <returns></returns>
        public List<KontoParovi> GetParoviList()
        {
            DataTable dt = GetKontoParoviDataTable($"Knjiga='{Knjiga}'");
            List<DataRow> rows = dt.AsEnumerable().ToList();
            List<KontoParovi> parovi = new List<KontoParovi>();
            parovi = (from DataRow dr in rows
                      select new KontoParovi()
                      {
                          Id = int.Parse(dr["Id"].ToString()),
                          Naziv = dr["Naziv"].ToString(),
                          Id_Konto = int.Parse(dr["Id_Konto"].ToString()),
                          Knjiga = this.Knjiga
                      }).ToList();
            return parovi;
        }

        public int Id { get; set; } = 0;
        public string Naziv { get; set; } = "";
        public string Opis { get; set; } = "";
        public int Id_Konto { get; set; } = 0;
        public string Knjiga { get; set; } = "";
    }
}
