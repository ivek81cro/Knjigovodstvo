using Knjigovodstvo.Global;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using Knjigovodstvo.Database;
using System.Data;
using Knjigovodstvo.Helpers;

namespace Knjigovodstvo.URA
{
    public partial class UraPregledForm : Form
    {
        public UraPregledForm()
        {
            InitializeComponent();
            _lastRecord = int.Parse(new DbDataCustomQuery()
                .ExecuteQuery("SELECT TOP 1 Broj_U_Knjizi_Ura FROM Primka WHERE Redni_Broj IS NOT NULL ORDER BY Broj_U_Knjizi_Ura DESC;")
                .Rows[0].ItemArray[0].ToString());
            LoadDatagrid();
        }

        private void LoadDatagrid()
        {
            dataGridView1.DataSource = new DbDataGet().GetTable(new Primka());
            FixColumnHeaders();
        }

        private void FixColumnHeaders()
        {
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].HeaderText =
                    new TableHeaderFormat().FormatHeader(dataGridView1.Columns[i].HeaderText);
            }
        }
        /// <summary>
        /// Read CSV file into List and fill DataGridView with data for review before saving to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUcitajTablicu_Click(object sender, EventArgs e)
        {
            ConvertXlsToCsv conv = new ConvertXlsToCsv();
            conv.Convert(ref put);

            _listaPrimki = File.ReadAllLines(put).Skip(3).Select(v => new Primka().FromCsv(v)).ToList();

            var data = new BindingSource();
            data.DataSource = _listaPrimki;
            dataGridView1.DataSource = data;
            FixColumnHeaders();
        }
        /// <summary>
        /// Save data from DataGridView to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSpremi_Click(object sender, EventArgs e)
        {
            DbDataInsert ins = new DbDataInsert();
            foreach (Primka primka in _listaPrimki)
            {
                if (primka.Redni_Broj > _lastRecord)
                    ins.InsertData(primka);
            }
            LoadDatagrid();
        }

        private string put = "";
        private List<Primka> _listaPrimki = new List<Primka>();
        private int _lastRecord = 0;
    }
}
