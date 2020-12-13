using Knjigovodstvo.Database;
using Knjigovodstvo.Interface;
using System;
using System.Data;

namespace Knjigovodstvo.FinancialReports
{
    public class KontniPlan : IDbObject
    {
        public FormError ValidateData()
        {
            throw new NotImplementedException();
        }

        public bool ExistsKonto(string konto)
        {
            _dt = new DbDataGet().GetTable(this, $"Konto='{konto}'");
            if(_dt.Rows.Count > 0)
            {
                Id = int.Parse(_dt.Rows[0]["Id"].ToString());
                return true;
            }
            return false;
        }

        public int GetIdByKontoNumber()
        {
            _dt = new DbDataGet()
                .GetTable(this, $"Konto='{Konto}'");
            Opis = _dt.Rows[0]["Opis"].ToString();

            return Id = int.Parse(_dt.Rows[0]["Id"].ToString());
        }

        public string GetDescriptiopnByKontoNumber(string konto)
        {
            _dt = new DbDataGet()
                .GetTable(this, $"Konto='{konto}'");

            return Opis = _dt.Rows[0]["Opis"].ToString();
        }

        private DataTable _dt = new DataTable();

        public int Id { get; set; } = 0;
        public string Konto { get; set; } = "";
        public string Opis { get; set; } = "";
    }
}
