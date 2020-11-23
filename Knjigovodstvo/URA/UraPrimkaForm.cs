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
    public partial class UraPrimkaForm : Form
    {
        public UraPrimkaForm()
        {
            _columns.Add(0, "Datum_knjizenja");
            _columns.Add(1, "Naziv_dobavljaca");
            InitializeComponent();
            DataTable dt = new DbDataCustomQuery()
                .ExecuteQuery("SELECT TOP 1 Broj_u_knjizi_ura FROM Primka WHERE Redni_broj IS NOT NULL ORDER BY Broj_u_knjizi_ura DESC;");
            if (dt.Rows.Count != 0)
                _lastRecord = int.Parse(dt.Rows[0].ItemArray[0].ToString());
            else
                _lastRecord = 0;
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
            ConvertXlsToCsv conv = new ConvertXlsToCsv("Primke");
            if (!conv.Convert(ref put))
            {
                MessageBox.Show("Krivo odabrana datoteka", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            _listaPrimki = File.ReadAllLines(put).Skip(3).Select(v => new Primka().FromCsv(v)).ToList();

            var data = new BindingSource
            {
                DataSource = _listaPrimki
            };
            dataGridView1.DataSource = data;
            FixColumnHeaders();
        }
        /// <summary>
        /// Save data from DataGridView to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSpremi_Click(object sender, EventArgs e)
        {
            DbDataInsert ins = new DbDataInsert();
            foreach (Primka primka in _listaPrimki)
            {
                if (primka.Redni_broj > _lastRecord)
                    ins.InsertData(primka);
            }
            LoadDatagrid();
        }

        private string put = "";
        private List<Primka> _listaPrimki = new List<Primka>();
        private readonly int _lastRecord = 0;
        private Dictionary<int, string> _columns=new Dictionary<int, string>();
    }
}
