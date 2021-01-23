using Knjigovodstvo.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Knjigovodstvo.Payroll
{
    public class PlacaArhiva : Placa
    {
        public bool Exists()
        {
            _dt = _dataGet.GetTable(this, 
                $"Oib='{Oib}' AND Datum_Od='{Datum_Od}' AND Datum_Do='{Datum_Do}'");
            int count = _dt.Rows.Count;
            if (count != 0)
                Id = int.Parse(_dt.Rows[0]["Id"].ToString());

            return count != 0;
        }

        public List<PlacaArhiva> GetListFromArhiva()
        {
            _dt = _dataGet.GetTable(new PlacaArhiva());

            List<PlacaArhiva> placaArhivaList = new List<PlacaArhiva>();
            placaArhivaList = (from DataRow dr in _dt.Rows
                               select new PlacaArhiva()
                               {
                                   Id = Convert.ToInt32(dr["Id"]),
                                   Oib = dr["Oib"].ToString(),
                                   Datum_Od = dr["Datum_Od"].ToString(),
                                   Datum_Do = dr["Datum_Do"].ToString(),
                                   Datum_obracuna = dr["Datum_obracuna"].ToString(),
                                   Bruto = Convert.ToDecimal(dr["Bruto"].ToString()),
                                   Mio_1 = Convert.ToDecimal(dr["Mio_1"].ToString()),
                                   Mio_2 = Convert.ToDecimal(dr["Mio_2"].ToString()),
                                   Dohodak = Convert.ToDecimal(dr["Dohodak"].ToString()),
                                   Osobni_Odbitak = Convert.ToDecimal(dr["Osobni_Odbitak"].ToString()),
                                   Porezna_Osnovica = Convert.ToDecimal(dr["Porezna_Osnovica"].ToString()),
                                   Porez_1 = Convert.ToDecimal(dr["Porez_1"].ToString()),
                                   Porez_2 = Convert.ToDecimal(dr["Porez_2"].ToString()),
                                   Porez_Ukupno = Convert.ToDecimal(dr["Porez_Ukupno"].ToString()),
                                   Prirez = Convert.ToDecimal(dr["Prirez"].ToString()),
                                   Ukupno_Porez_i_Prirez = Convert.ToDecimal(dr["Ukupno_Porez_i_Prirez"].ToString()),
                                   Neto = Convert.ToDecimal(dr["Neto"].ToString()),
                                   Doprinos_Zdravstvo = Convert.ToDecimal(dr["Doprinos_Zdravstvo"].ToString()),
                                   Dodaci_Ukupno = Convert.ToDecimal(dr["Dodaci_Ukupno"].ToString()),
                                   Knjizen = dr["Knjizen"].ToString() == "1",
                               }).ToList();
            
            return placaArhivaList;
        }

        private readonly DbDataGet _dataGet = new DbDataGet();
        private DataTable _dt = new DataTable();

        public string Datum_Od { get; set; } = "";
        public string Datum_Do { get; set; } = "";
        public string Datum_obracuna { get; set; } = "";
        public bool Knjizen { get; set; } = false;
    }
}
