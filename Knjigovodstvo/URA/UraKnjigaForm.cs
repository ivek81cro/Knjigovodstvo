using Knjigovodstvo.Database;
using Knjigovodstvo.Global;
using Knjigovodstvo.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Knjigovodstvo.URA
{
    partial class UraKnjigaForm : Form
    {
        public UraKnjigaForm()
        {
            InitializeComponent();
            _dt = new DbDataCustomQuery()
                .ExecuteQuery("SELECT TOP 1 Redni_broj FROM UraKnjiga WHERE Redni_broj IS NOT NULL ORDER BY Redni_broj DESC;");
            if (_dt.Rows.Count != 0)
                _lastRecord = int.Parse(_dt.Rows[0].ItemArray[0].ToString());
            else
                _lastRecord = 0;
            LoadDatagrid();
        }

        void LoadDatagrid()
        {
            dataGridView1.DataSource = new DbDataGet().GetTable(new UraKnjiga());
            FixColumnHeaders();
        }

        void FixColumnHeaders()
        {
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].HeaderText =
                    new TableHeaderFormat().FormatHeader(dataGridView1.Columns[i].HeaderText);
            }
        }

        void FilterDataGridView(object sender, KeyEventArgs e)
        {
            string filterCondition = $"[Naziv_dobavljaca] LIKE '%{textBoxFilterNaziv.Text}%'";

            if (checkBoxDatumi.Checked)
            {
                filterCondition = $"[Datum]>='{dateTimePickerOd.Value.ToString("yyyy-MM-dd")}' " +
                    $"AND [Datum]<='{dateTimePickerDo.Value.ToString("yyyy-MM-dd")}' " +
                    $"AND [Naziv_dobavljaca] LIKE '%{textBoxFilterNaziv.Text}%'";
            }

            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = filterCondition;
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

        private void ButtonFilterDatum_Click(object sender, EventArgs e)
        {
            FilterDataGridView(null, null);
        }

        private void ButtonUcitaj_Click(object sender, EventArgs e)
        {
            ConvertXlsToCsv conv = new ConvertXlsToCsv("ulaznih");
            if (!conv.Convert(ref put))
            {
                MessageBox.Show("Krivo odabrana datoteka", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            _listaStavki = File.ReadAllLines(put).Skip(3).Select(v => new UraKnjiga().FromCsv(v)).ToList();

            var data = new BindingSource
            {
                DataSource = _listaStavki
            };
            dataGridView1.DataSource = data;
            FixColumnHeaders();
        }

        private void ButtonSpremi_Click(object sender, EventArgs e)
        {
            DbDataInsert ins = new DbDataInsert();
            foreach (UraKnjiga stavka in _listaStavki)
            {
                if (stavka.Redni_broj > _lastRecord)
                    ins.InsertData(stavka);
            }
            LoadDatagrid();
        }

        private void ButtonTroskovi_Click(object sender, EventArgs e)
        {
            UraTrosakForm utf = new UraTrosakForm();
            utf.ShowDialog();
        }

        private string put = "";
        private List<UraKnjiga> _listaStavki = new List<UraKnjiga>();
        private readonly int _lastRecord = 0;
        private DataTable _dt;
    }
}
