using Knjigovodstvo.Database;
using Knjigovodstvo.Interface;
using System.Collections.Generic;
using System.Data;

namespace Knjigovodstvo.Wages
{
    public class Placa : IDbObject
    {
        public FormError ValidateData() 
        {
            return FormError.None;
        }

        /// <summary>
        /// Returns wage table as DataTable
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetPlacaDataTable()
        {
            return new DbDataGet().GetTable(this);
        }

        /// <summary>
        /// Returns wage table as DataTable by condition
        /// </summary>
        /// <param name="condition"></param>
        /// <returns>DataTable</returns>
        public DataTable GetPlacaDataTable(string condition)
        {
            return new DbDataGet().GetTable(this, condition);
        }

        /// <summary>
        /// Sets parameters based on argument Oib
        /// </summary>
        /// <param name="oib">String</param>
        public void GetPlacaByOib(string oib) 
        {
            DataRow row = GetPlacaDataTable($"Oib='{oib}'").Rows[0];
            SetPrivateMembers(row);
        }

        /// <summary>
        /// Sets parameters based on set property Oib
        /// </summary>
        /// <param name="oib">String</param>
        public void GetPlacaByOib()
        {
            DataRow row = GetPlacaDataTable($"Oib='{Oib}'").Rows[0];
            SetPrivateMembers(row);
        }

        /// <summary>
        /// Sums all bonuses related to employee that are in database
        /// </summary>
        public void SumAllDodaci()
        {
            Dodaci_Ukupno = 0;
            foreach(var dodatak in _dodaci)
            {
                Dodaci_Ukupno += dodatak.Iznos;
            }
        }

        /// <summary>
        /// Adds bonuses to employee
        /// </summary>
        /// <param name="dodaci"></param>
        public void AddDodaci(List<Dodatak> dodaci)
        {
            _dodaci = dodaci;
            SumAllDodaci();
        }

        /// <summary>
        /// Returns List of bonuses for employee
        /// </summary>
        /// <returns></returns>
        public List<Dodatak> GetDodaci()
        {
            return _dodaci;
        }

        private void SetPrivateMembers(DataRow row)
        {
            Id = int.Parse(row["Id"].ToString());
            Oib = row["Oib"].ToString();
            Bruto = decimal.Parse(row["Bruto"].ToString());
            Mio_1 = decimal.Parse(row["Mio_1"].ToString());
            Mio_2 = decimal.Parse(row["Mio_2"].ToString());
            Dohodak = decimal.Parse(row["Dohodak"].ToString());
            Osobni_Odbitak = decimal.Parse(row["Osobni_Odbitak"].ToString());
            Porezna_Osnovica = decimal.Parse(row["Porezna_Osnovica"].ToString());
            Porez_1 = decimal.Parse(row["Porez_1"].ToString());
            Porez_2 = decimal.Parse(row["Porez_2"].ToString());
            Porez_Ukupno = decimal.Parse(row["Porez_Ukupno"].ToString());
            Prirez = decimal.Parse(row["Prirez"].ToString());
            Ukupno_Porez_i_Prirez = decimal.Parse(row["Ukupno_Porez_i_Prirez"].ToString());
            Neto = decimal.Parse(row["Neto"].ToString());
            Doprinos_Zdravstvo = decimal.Parse(row["Doprinos_Zdravstvo"].ToString());
            Dodaci_Ukupno = decimal.Parse(row["Dodaci_Ukupno"].ToString());
        }

        private List<Dodatak> _dodaci = new List<Dodatak>();

        public int Id { get; set; } = 0;
        public string Oib { get; set; } = "";
        public decimal Bruto { get; set; } = 0;
        public decimal Mio_1 { get; set; } = 0;
        public decimal Mio_2 { get; set; } = 0;
        public decimal Dohodak { get; set; } = 0;
        public decimal Osobni_Odbitak { get; set; } = 0;
        public decimal Porezna_Osnovica { get; set; } = 0;
        public decimal Porez_1 { get; set; } = 0;
        public decimal Porez_2 { get; set; } = 0;
        public decimal Porez_Ukupno { get; set; } = 0;
        public decimal Prirez { get; set; } = 0;
        public decimal Ukupno_Porez_i_Prirez { get; set; } = 0;
        public decimal Neto { get; set; } = 0;
        public decimal Doprinos_Zdravstvo { get; set; } = 0;
        public decimal Dodaci_Ukupno { get; set; } = 0;
    }
}
