using Knjigovodstvo.Database;
using Knjigovodstvo.IRA;
using Knjigovodstvo.URA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Knjigovodstvo
{
    public partial class PorezPdvForm : Form
    {
        public PorezPdvForm()
        {
            InitializeComponent();
        }

        private void ImportDataFromDatabase()
        {
            string datumOd = dateTimePickerOd.Value.ToString("yyyy-MM-dd");
            string datumDo = dateTimePickerDo.Value.ToString("yyyy-MM-dd");
            DataTable dt = new DbDataGet().GetTable(new KnjigaUra(), $"Datum BETWEEN '{datumOd}' AND '{datumDo}'");
            foreach(DataRow row in dt.Rows)
            {
                KnjigaUra ura = new KnjigaUra();
                ura.FillData(row);
                _knjigaUra.Add(ura);
            }

            dt = new DbDataGet().GetTable(new KnjigaIra(), $"Datum BETWEEN '{datumOd}' AND '{datumDo}'");
            foreach (DataRow row in dt.Rows)
            {
                KnjigaIra ira = new KnjigaIra();
                ira.FillData(row);
                _knjigaIra.Add(ira);
            }
        }

        private void ButtonKnjizi_Click(object sender, EventArgs e)
        {
        }

        private void buttonIzracunaj_Click(object sender, EventArgs e)
        {
            ImportDataFromDatabase();
        }

        private List<KnjigaUra> _knjigaUra = new List<KnjigaUra>();
        private List<KnjigaIra> _knjigaIra = new List<KnjigaIra>();
    }
}
