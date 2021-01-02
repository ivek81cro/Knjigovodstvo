using Knjigovodstvo.Global;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using Knjigovodstvo.Database;
using System.Data;
using Knjigovodstvo.Helpers;
using Knjigovodstvo.Settings.SettingsBookkeeping;
using Knjigovodstvo.Settings;
using Knjigovodstvo.Books.PrepareForBalanceSheet;

namespace Knjigovodstvo.URA
{
    public partial class UraPrimkaForm : Form
    {
        public UraPrimkaForm()
        {
            _columns.Add(0, "Datum_knjizenja");
            _columns.Add(1, "Naziv_dobavljaca");
            _columns.Add(2, "Broj_racuna");
            InitializeComponent();
            DataTable dt = new DbDataCustomQuery()
                .ExecuteQuery("SELECT TOP 1 Broj_u_knjizi_ura FROM Primka WHERE Redni_broj IS NOT NULL ORDER BY Broj_u_knjizi_ura DESC;");
            if (dt.Rows.Count != 0)
                _lastRecord = int.Parse(dt.Rows[0].ItemArray[0].ToString());
            else
                _lastRecord = 0;

            _bookNames = BookNames.Ura_primka;
            LoadDatagrid();
            LoadBookkeepingSettings();
        }

        private void LoadDatagrid()
        {
            dataGridView1.DataSource = new DbDataGet().GetTable(_primka, $" Redni_broj <> 0 ORDER BY Redni_broj");
            FixColumnHeaders();
        }

        private void LoadBookkeepingSettings()
        {
            List<DataRow> dr = new DbDataGet().GetTable(new PostavkeKnjizenja(), $"Knjiga='{_bookNames}'").AsEnumerable().ToList();
            _postavkeKnjizenja = new List<PostavkeKnjizenja>();
            _postavkeKnjizenja = (from DataRow dRow in dr
                                  select new PostavkeKnjizenja()
                                  {
                                      Id = int.Parse(dRow["Id"].ToString()),
                                      Knjiga = dRow["Knjiga"].ToString(),
                                      Naziv_stupca = dRow["Naziv_stupca"].ToString(),
                                      Konto = dRow["Konto"].ToString(),
                                      Strana = dRow["Strana"].ToString(),
                                      Mijenja_predznak = dRow["Mijenja_predznak"].ToString() == "True"
                                  }).ToList();

        }

        private void FixColumnHeaders()
        {
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].HeaderText =
                    new TableHeaderFormat().FormatHeader(dataGridView1.Columns[i].HeaderText);
            }
        }

        private void SetSelectedItem(DataGridViewRow row)
        {
            _primka.Broj_u_knjizi_ura = int.Parse(row.Cells["Broj_u_knjizi_ura"].Value.ToString());
            _primka.GetDataFromDatabaseByUraBroj();
        }
        /// <summary>
        /// Read CSV file into List and fill DataGridView with data for review before saving to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLoadTable_Click(object sender, EventArgs e)
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
                if (primka.Broj_u_knjizi_ura > _lastRecord)
                    ins.InsertData(primka);
                else
                    new DbDataUpdate().UpdateData(primka, $"Broj_u_knjizi_ura={primka.Broj_u_knjizi_ura}");
            }
            LoadDatagrid();
        }

        private void ButtonPostavke_Click(object sender, EventArgs e)
        {
            PostavkeKnjizenjaPregledForm form = new PostavkeKnjizenjaPregledForm(_bookNames);
            form.FormClosing += new FormClosingEventHandler(PostavkeClosing_Event);
            form.ShowDialog();
        }

        private void PostavkeClosing_Event(object sender, FormClosingEventArgs e)
        {
            LoadBookkeepingSettings();
        }

        private void ButtonKnjizi_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                SetSelectedItem(row);
                using TemeljnicaPripremaForm form = new TemeljnicaPripremaForm(_primka, _postavkeKnjizenja);
                form.ShowDialog();
                if (!form.Knjizeno)
                    break;
                else
                    new DbDataCustomQuery()
                        .ExecuteQuery($"UPDATE UraKnjiga SET Knjizen = 1 WHERE Redni_broj = {_primka.Broj_u_knjizi_ura}");
            }
        }

        private readonly Primka _primka = new Primka();
        private List<PostavkeKnjizenja> _postavkeKnjizenja;
        private readonly BookNames _bookNames;
        private string put = "";
        private List<Primka> _listaPrimki = new List<Primka>();
        private readonly int _lastRecord = 0;
        private readonly Dictionary<int, string> _columns = new Dictionary<int, string>();
    }
}
