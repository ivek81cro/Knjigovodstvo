using Knjigovodstvo.Books.PrepareForBalanceSheet;
using Knjigovodstvo.Database;
using Knjigovodstvo.Global;
using Knjigovodstvo.Helpers;
using Knjigovodstvo.Settings.SettingsBookkeeping;
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
            _columns.Add(0, "Datum");
            _columns.Add(1, "Naziv_dobavljaca");
            _columns.Add(2, "Broj_racuna");
            InitializeComponent();
            _dt = new DbDataCustomQuery()
                .ExecuteQuery("SELECT TOP 1 Redni_broj FROM UraKnjiga WHERE Redni_broj IS NOT NULL ORDER BY Redni_broj DESC;");
            if (_dt.Rows.Count != 0)
                _lastRecord = int.Parse(_dt.Rows[0].ItemArray[0].ToString());
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

        private void SetSelectedItem() 
        {
            var row = dataGridView1.SelectedRows[0];
            _uraKnjiga.Redni_broj = int.Parse(row.Cells["Redni_broj"].Value.ToString());
            _uraKnjiga.GetDataFromDatabaseByRedbiBroj();
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
            dataGridView1.DataSource = new DbDataExecProcedure().GetTable(ProcedureNames.Izdvoji_Troskove);
            FixColumnHeaders();
        }

        private void ButtonOdobrenja_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new DbDataExecProcedure().GetTable(ProcedureNames.Izdvoji_Odobrenja);
            FixColumnHeaders();
        }

        private void OpenPostavkeForm(object sender, EventArgs e)
        {
            PostavkeKnjizenjaPregledForm form = new PostavkeKnjizenjaPregledForm("Ura");
            form.ShowDialog();
        }

        private void ButtonKnjizi_Click(object sender, EventArgs e)
        {
            SetSelectedItem();
            TemeljnicaForm form = new TemeljnicaForm(_uraKnjiga);
            form.ShowDialog();
        }

        private string put = "";
        private List<UraKnjiga> _listaStavki = new List<UraKnjiga>();
        private readonly int _lastRecord = 0;
        private DataTable _dt;
        private Dictionary<int, string> _columns = new Dictionary<int, string>();
        private UraKnjiga _uraKnjiga = new UraKnjiga();
    }
}
