using Knjigovodstvo.Database;
using Knjigovodstvo.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Knjigovodstvo.BankStatements
{
    class IzvodParovi:IDbObject
    {
        public FormError ValidateData()
        {
            throw new NotImplementedException();
        }

        public void InsertData()
        {
            new DbDataInsert().InsertData(this);
        }

        public List<IzvodParovi> GetIzvodParovi()
        {
            DataTable dt = new DbDataGet().GetTable(this);
            List<DataRow> rows = dt.AsEnumerable().ToList();
            List<IzvodParovi> parovi = new List<IzvodParovi>();
            parovi = (from DataRow dr in rows
                      select new IzvodParovi() 
                      {
                          Id = int.Parse(dr["Id"].ToString()),
                          Naziv_Izvod = dr["Naziv_Izvod"].ToString(),
                          Id_Partner = int.Parse(dr["Id_Partner"].ToString())
                      }).ToList();
            return parovi;
        }

        internal bool ExistsInDb()
        {
            return new DbDataGet().GetTable(this, $"Naziv_Izvod='{Naziv_Izvod}'").Rows.Count > 0;
        }

        public int Id { get; set; } = 0;
        public string Naziv_Izvod { get; set; } = "";
        public int Id_Partner { get; set; } = 0;
    }
}
