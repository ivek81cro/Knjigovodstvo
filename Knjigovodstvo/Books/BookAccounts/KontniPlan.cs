using Knjigovodstvo.Database;
using Knjigovodstvo.Interface;
using System.Data;

namespace Knjigovodstvo.FinancialReports
{
    public class KontniPlan : IDbObject
    {
        public FormError ValidateData()
        {
            return FormError.None;
        }

        public DataTable GetObjectDataTable()
        {
            return _dataGet.GetTable(this);
        }

        public DataTable GetObjectDataTable(string condition)
        {
            return _dataGet.GetTable(this, condition);
        }

        public void DeleteKonto()
        {
            new DbDataDelete().DeleteItem(this);
        }

        public bool ExistsKonto(string konto)
        {
            _dt = GetObjectDataTable($"Konto='{konto}'");
            if(_dt.Rows.Count > 0)
            {
                Id = int.Parse(_dt.Rows[0]["Id"].ToString());
                return true;
            }
            return false;
        }

        public int GetIdByKontoNumber()
        {
            _dt = GetObjectDataTable($"Konto='{Konto}'");
            if (_dt.Rows.Count > 0)
            {
                LoadPrivateMembers(_dt.Rows[0]);
            }
            
            return Id = int.Parse(_dt.Rows[0]["Id"].ToString());
        }

        public string GetDescriptionByKontoNumber(string konto)
        {
            if (konto == "")
            {
                Opis = "";
                return "";
            }

            _dt = GetObjectDataTable($"Konto='{konto}'");
            if (_dt.Rows.Count > 0)
            {
                LoadPrivateMembers(_dt.Rows[0]);
            }
            
            return Opis = _dt.Rows[0]["Opis"].ToString();
        }

        public string GetKontoById(int id)
        {
            _dt = GetObjectDataTable($"Id='{id}'");
            if (_dt.Rows.Count > 0)
            {
                LoadPrivateMembers(_dt.Rows[0]);
            }

            return Konto;
        }

        private void LoadPrivateMembers(DataRow row)
        {
            Id = int.Parse(row["Id"].ToString());
            Konto = row["Konto"].ToString();
            Opis = row["Opis"].ToString();
        }

        private DataTable _dt = new DataTable();
        private readonly DbDataGet _dataGet = new DbDataGet();

        public int Id { get; set; } = 0;
        public string Konto { get; set; } = "";
        public string Opis { get; set; } = "";
    }
}
