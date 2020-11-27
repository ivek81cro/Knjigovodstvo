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

        public bool GetKontniPlanIdByKonto(string konto)
        {
            DataTable dt = new DbDataGet().GetTable(this, $"Konto='{konto}'");
            if(dt.Rows.Count > 0)
            {
                Id = int.Parse(dt.Rows[0]["Id"].ToString());
                return true;
            }
            return false;
        }

        public int Id { get; set; } = 0;
        public string Konto { get; set; } = "";
        public string Opis { get; set; } = "";
    }
}
