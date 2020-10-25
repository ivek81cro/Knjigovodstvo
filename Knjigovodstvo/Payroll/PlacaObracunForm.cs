using Knjigovodstvo.Database;
using Knjigovodstvo.Employee;
using Knjigovodstvo.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Knjigovodstvo.Payroll
{
    public partial class PlacaObracunForm : Form
    {
        public PlacaObracunForm()
        {
            InitializeComponent();
            DateTime date = DateTime.Now.AddMonths(-1);
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            dateTimePickerDatumOd.Value = firstDayOfMonth;
            dateTimePickerDatumDo.Value = lastDayOfMonth;
            FillListPlaca();
            LoadDatagrid();
        }

        private void FillListPlaca()
        {
            DataTable dt = new DbDataGet().GetTable(new Placa());

            List<DataRow> rows = dt.AsEnumerable().ToList();
            _place = (from DataRow data in rows
                      select new Placa()
                      {
                          Id = int.Parse(data["Id"].ToString()),
                          Oib = data["Oib"].ToString(),
                          Bruto = float.Parse(data["Bruto"].ToString()),
                          Mio_1 = float.Parse(data["Mio_1"].ToString()),
                          Mio_2 = float.Parse(data["Mio_2"].ToString()),
                          Dohodak = float.Parse(data["Dohodak"].ToString()),
                          Osobni_Odbitak = float.Parse(data["Osobni_Odbitak"].ToString()),
                          Porezna_Osnovica = float.Parse(data["Porezna_Osnovica"].ToString()),
                          Porez_24_per = float.Parse(data["Porez_24_per"].ToString()),
                          Porez_36_per = float.Parse(data["Porez_36_per"].ToString()),
                          Porez_Ukupno = float.Parse(data["Porez_Ukupno"].ToString()),
                          Prirez = float.Parse(data["Prirez"].ToString()),
                          Ukupno_Porez_i_Prirez = float.Parse(data["Ukupno_Porez_i_Prirez"].ToString()),
                          Neto = float.Parse(data["Neto"].ToString()),
                          Doprinos_Zdravstvo = float.Parse(data["Doprinos_Zdravstvo"].ToString()),
                          Dodaci_Ukupno = float.Parse(data["Dodaci_Ukupno"].ToString())

                      }).ToList();
        }

        private void buttonObracunajSve_Click(object sender, EventArgs e)
        {
            _placeObracun = (from Placa placa in _place
                             select new PlacaObracun()
                             {
                                 Oib = placa.Oib,
                                 Bruto = placa.Bruto,
                                 Mio_1 = placa.Mio_1,
                                 Mio_2 = placa.Mio_2,
                                 Dohodak = placa.Dohodak,
                                 Osobni_Odbitak = placa.Osobni_Odbitak,
                                 Porezna_Osnovica = placa.Porezna_Osnovica,
                                 Porez_24_per = placa.Porez_24_per,
                                 Porez_36_per = placa.Porez_36_per,
                                 Porez_Ukupno = placa.Porez_Ukupno,
                                 Prirez = placa.Prirez,
                                 Ukupno_Porez_i_Prirez = placa.Ukupno_Porez_i_Prirez,
                                 Neto = placa.Neto,
                                 Doprinos_Zdravstvo = placa.Doprinos_Zdravstvo,
                                 Dodaci_Ukupno = placa.Dodaci_Ukupno,
                                 Datum_Od = dateTimePickerDatumOd.Value.ToString("yyyy-MM-dd"),
                                 Datum_Do = dateTimePickerDatumDo.Value.ToString("yyyy-MM-dd")
                             }).ToList();

            SaveObracun();
        }

        private void SaveObracun()
        {
            DbDataInsert insert = new DbDataInsert();

            foreach (PlacaObracun placaObracun in _placeObracun)
            {
                insert.InsertData(placaObracun);
            }

            LoadDatagrid();
        }

        private void LoadDatagrid()
        {
            dataGridView1.DataSource = _dbDataGet.GetTable(new PlacaObracun());
            for (int i = 2; i < dataGridView1.Columns.Count-2; i++)
            {
                dataGridView1.Columns[i].DefaultCellStyle.Format = "0.00";
                dataGridView1.Columns[i].HeaderText =
                    new TableHeaderFormat().FormatHeader(dataGridView1.Columns[i].HeaderText);
            }
        }

        private List<PlacaObracun> _placeObracun = new List<PlacaObracun>();
        private List<Placa> _place = new List<Placa>();
        private DbDataGet _dbDataGet = new DbDataGet();
    }
}
