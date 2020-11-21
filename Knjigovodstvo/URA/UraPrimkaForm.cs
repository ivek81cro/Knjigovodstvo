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

        void CheckValidRange(object sender, EventArgs e)
        {
            if (dateTimePickerOd.Value > dateTimePickerDo.Value)
            {
                MessageBox.Show(
                    "Početni datum mora biti manji ili jednak završnom.",
                    "Upozorenje",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                dateTimePickerDo.Value = dateTimePickerOd.Value;
            }
        }

        void CheckBoxDatumi_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxDatumi.Checked)
            {
                dateTimePickerOd.Enabled = true;
                dateTimePickerDo.Enabled = true;
            }
            else
            {
                dateTimePickerOd.Enabled = false;
                dateTimePickerDo.Enabled = false;
            }
        }

        void FilterDataGridView(object sender, KeyEventArgs e)
        {
            string filterCondition = $"[Naziv_dobavljaca] LIKE '%{textBoxFilterNaziv.Text}%'";

            if (checkBoxDatumi.Checked)
            {
                filterCondition = $"[Datum_knjizenja]>='{dateTimePickerOd.Value.ToString("yyyy-MM-dd")}' " +
                    $"AND [Datum_knjizenja]<='{dateTimePickerDo.Value.ToString("yyyy-MM-dd")}' " +
                    $"AND [Naziv_dobavljaca] LIKE '%{textBoxFilterNaziv.Text}%'";
            }

           (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = filterCondition;
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

        private void ButtonFilterDatum_Click(object sender, EventArgs e)
        {
            FilterDataGridView(null, null);
        }

        private string put = "";
        private List<Primka> _listaPrimki = new List<Primka>();
        private readonly int _lastRecord = 0;
    }
}
