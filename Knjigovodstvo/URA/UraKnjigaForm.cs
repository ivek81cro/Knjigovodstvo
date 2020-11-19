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
    public partial class UraKnjigaForm : Form
    {
        public UraKnjigaForm()
        {
            InitializeComponent();
            DataTable dt = new DbDataCustomQuery()
                .ExecuteQuery("SELECT TOP 1 Redni_broj FROM UraKnjiga WHERE Redni_broj IS NOT NULL ORDER BY Redni_broj DESC;");
            if (dt.Rows.Count != 0)
                _lastRecord = int.Parse(dt.Rows[0].ItemArray[0].ToString());
            else
                _lastRecord = 0;
            LoadDatagrid();
        }

        private void LoadDatagrid()
        {
            dataGridView1.DataSource = new DbDataGet().GetTable(new UraKnjiga());
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

        private void ButtonUcitaj_Click(object sender, EventArgs e)
        {
            ConvertXlsToCsv conv = new ConvertXlsToCsv();
            conv.Convert(ref put);

            _listaStavki = File.ReadAllLines(put).Skip(3).Select(v => new UraKnjiga().FromCsv(v)).ToList();

            var data = new BindingSource();
            data.DataSource = _listaStavki;
            dataGridView1.DataSource = data;
            FixColumnHeaders();
        }

        private void buttonSpremi_Click(object sender, EventArgs e)
        {
            DbDataInsert ins = new DbDataInsert();
            foreach (UraKnjiga stavka in _listaStavki)
            {
                if (stavka.Redni_broj > _lastRecord)
                    ins.InsertData(stavka);
            }
            LoadDatagrid();
        }

        private string put = "";
        private List<UraKnjiga> _listaStavki = new List<UraKnjiga>();
        private int _lastRecord = 0;
    }
}
