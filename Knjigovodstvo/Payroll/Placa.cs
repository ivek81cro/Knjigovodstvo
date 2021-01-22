using Knjigovodstvo.Database;
using Knjigovodstvo.Interface;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Knjigovodstvo.Payroll
{
    public class Placa : IDbObject
    {
        public FormError ValidateData() 
        {
            return FormError.None;
        }

        public void GetPlacaByOib(string oib) 
        {
            DataTable data = new DbDataGet().GetTable(this, $"Oib='{oib}'");
            try
            {
                Id = int.Parse(data.Rows[0]["Id"].ToString());
                Oib = data.Rows[0]["Oib"].ToString();
                Bruto = decimal.Parse(data.Rows[0]["Bruto"].ToString());
                Mio_1 = decimal.Parse(data.Rows[0]["Mio_1"].ToString());
                Mio_2 = decimal.Parse(data.Rows[0]["Mio_2"].ToString());
                Dohodak = decimal.Parse(data.Rows[0]["Dohodak"].ToString());
                Osobni_Odbitak = decimal.Parse(data.Rows[0]["Osobni_Odbitak"].ToString());
                Porezna_Osnovica = decimal.Parse(data.Rows[0]["Porezna_Osnovica"].ToString());
                Porez_1 = decimal.Parse(data.Rows[0]["Porez_1"].ToString());
                Porez_2 = decimal.Parse(data.Rows[0]["Porez_2"].ToString());
                Porez_Ukupno = decimal.Parse(data.Rows[0]["Porez_Ukupno"].ToString());
                Prirez = decimal.Parse(data.Rows[0]["Prirez"].ToString());
                Ukupno_Porez_i_Prirez = decimal.Parse(data.Rows[0]["Ukupno_Porez_i_Prirez"].ToString());
                Neto = decimal.Parse(data.Rows[0]["Neto"].ToString());
                Doprinos_Zdravstvo = decimal.Parse(data.Rows[0]["Doprinos_Zdravstvo"].ToString());
                Dodaci_Ukupno = decimal.Parse(data.Rows[0]["Dodaci_Ukupno"].ToString());
            }
            catch
            {
                Oib = "0";
            }
        }

        public void SumAllDodaci()
        {
            Dodaci_Ukupno = 0;
            foreach(var dodatak in _dodaci)
            {
                Dodaci_Ukupno += dodatak.Iznos;
            }
        }

        internal void AddDodaci(List<Dodatak> dodaci)
        {
            _dodaci = dodaci;
            SumAllDodaci();
        }

        internal List<Placa> GetListOfPlaca()
        {
            List<Placa> place = new List<Placa>();
            List<DataRow> rows = new DbDataGet().GetTable(this).AsEnumerable().ToList();
            place = (from DataRow data in rows
                      select new Placa()
                      {
                          Id = int.Parse(data["Id"].ToString()),
                          Oib = data["Oib"].ToString(),
                          Bruto = decimal.Parse(data["Bruto"].ToString()),
                          Mio_1 = decimal.Parse(data["Mio_1"].ToString()),
                          Mio_2 = decimal.Parse(data["Mio_2"].ToString()),
                          Dohodak = decimal.Parse(data["Dohodak"].ToString()),
                          Osobni_Odbitak = decimal.Parse(data["Osobni_Odbitak"].ToString()),
                          Porezna_Osnovica = decimal.Parse(data["Porezna_Osnovica"].ToString()),
                          Porez_1 = decimal.Parse(data["Porez_1"].ToString()),
                          Porez_2 = decimal.Parse(data["Porez_2"].ToString()),
                          Porez_Ukupno = decimal.Parse(data["Porez_Ukupno"].ToString()),
                          Prirez = decimal.Parse(data["Prirez"].ToString()),
                          Ukupno_Porez_i_Prirez = decimal.Parse(data["Ukupno_Porez_i_Prirez"].ToString()),
                          Neto = decimal.Parse(data["Neto"].ToString()),
                          Doprinos_Zdravstvo = decimal.Parse(data["Doprinos_Zdravstvo"].ToString()),
                          Dodaci_Ukupno = decimal.Parse(data["Dodaci_Ukupno"].ToString())
                      }).ToList();
            return place;
        }

        internal List<Dodatak> GetDodaci()
        {
            return _dodaci;
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
