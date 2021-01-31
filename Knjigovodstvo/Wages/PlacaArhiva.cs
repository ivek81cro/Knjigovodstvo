﻿using Knjigovodstvo.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Linq;

namespace Knjigovodstvo.Wages
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

        internal void DeleteRow()
        {
            new DbDataDelete().DeleteItem(this);
        }

        internal DataTable GetPlacaArhivaDataTable(string condition = null)
        {
            return _dataGet.GetTable(this, condition);
        }

        internal List<PlacaArhiva> DataTableToList(DataTable dt)
        {
            List<PlacaArhiva> list = new List<PlacaArhiva>();
            list = (from DataRow dr in dt.Rows
                           select new PlacaArhiva()
                           {
                               Id = int.Parse(dr["Id"].ToString()),
                               Oib = dr["Oib"].ToString(),
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
                               Dodaci_Ukupno = Convert.ToDecimal(dr["Dodaci_Ukupno"].ToString())
                           }).ToList();
            return list;
        }

        internal PlacaArhiva ConvertDataRow(DataGridViewRow row)
        {
            return new PlacaArhiva() 
            {
                Oib = row.Cells["Oib"].Value.ToString(),
                Bruto = Convert.ToDecimal(row.Cells["Bruto"].Value.ToString()),
                Mio_1 = Convert.ToDecimal(row.Cells["Mio_1"].Value.ToString()),
                Mio_2 = Convert.ToDecimal(row.Cells["Mio_2"].Value.ToString()),
                Dohodak = Convert.ToDecimal(row.Cells["Dohodak"].Value.ToString()),
                Osobni_Odbitak = Convert.ToDecimal(row.Cells["Osobni_Odbitak"].Value.ToString()),
                Porezna_Osnovica = Convert.ToDecimal(row.Cells["Porezna_Osnovica"].Value.ToString()),
                Porez_1 = Convert.ToDecimal(row.Cells["Porez_1"].Value.ToString()),
                Porez_2 = Convert.ToDecimal(row.Cells["Porez_2"].Value.ToString()),
                Porez_Ukupno = Convert.ToDecimal(row.Cells["Porez_Ukupno"].Value.ToString()),
                Prirez = Convert.ToDecimal(row.Cells["Prirez"].Value.ToString()),
                Ukupno_Porez_i_Prirez = Convert.ToDecimal(row.Cells["Ukupno_Porez_i_Prirez"].Value.ToString()),
                Neto = Convert.ToDecimal(row.Cells["Neto"].Value.ToString()),
                Doprinos_Zdravstvo = Convert.ToDecimal(row.Cells["Doprinos_Zdravstvo"].Value.ToString()),
                Dodaci_Ukupno = Convert.ToDecimal(row.Cells["Dodaci_Ukupno"].Value.ToString())
            };
        }

        private readonly DbDataGet _dataGet = new DbDataGet();
        private DataTable _dt = new DataTable();

        public string Datum_Od { get; set; } = "";
        public string Datum_Do { get; set; } = "";
        public string Datum_obracuna { get; set; } = "";
        public bool Knjizen { get; set; } = false;
    }
}
