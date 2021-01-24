using Knjigovodstvo.Books.PrepareForBalanceSheet;
using Knjigovodstvo.Database;
using Knjigovodstvo.Employee;
using Knjigovodstvo.Global.Helpers;
using Knjigovodstvo.Helpers;
using Knjigovodstvo.Settings;
using Knjigovodstvo.Settings.SettingsBookkeeping;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            _bookName = BookNames.Place;
            _place = new Placa().GetListOfPlaca();
            _zaposlenici = new Zaposlenik().GetListZaposlenik();
            _dt = new DbDataGet().GetTable(new Placa());

            FillComboBoxMjesec();
            LoadBookkeepingsettings();
            LoadDatagrid();
        }

        private void LoadDatagrid()
        {            
            _dt.Columns.Add("Odabir", typeof(bool)).SetOrdinal(0);
            _dt.Columns.Add("Ime_i_prezime", typeof(string)).SetOrdinal(1);
            Zaposlenik z = new Zaposlenik();
            foreach (DataRow row in _dt.Rows)
            {
                z = _zaposlenici.Find(z => z.Oib == row["Oib"].ToString());
                row["Ime_i_prezime"] = z.Ime + ' ' + z.Prezime;
            }
            dbDataGridView1.DataSource = _dt;
            dbDataGridView1.Columns["Id"].Visible = false;
            dbDataGridView1.Columns[0].Width = 50;
            FormatDataTableColumnHeaders();
        }

        private void FormatDataTableColumnHeaders()
        {
            for (int i = 1; i < dbDataGridView1.Columns.Count; i++)
            {
                dbDataGridView1.Columns[i].ReadOnly = true;
                dbDataGridView1.Columns[i].HeaderText =
                    new TableHeaderFormat()
                    .FormatHeader(dbDataGridView1.Columns[i].HeaderText);
            }
        }

        private void FillComboBoxMjesec()
        {
            DataTable dt = new DbDataExecProcedure
                ().GetTable(
                ProcedureNames.Placa_Distinct_Datum);
            dt.Columns.Add(
                "Datum obračuna",
                typeof(DateTime),
                 "yeardate");
            comboBoxDatumObracunaFilter.DataSource = dt;
            comboBoxDatumObracunaFilter.DisplayMember = "Datum obračuna";
            comboBoxDatumObracunaFilter.SelectedItem = null;
            comboBoxDatumObracunaFilter.Text = "--Odaberi mjesec--";
        }

        private void PostavkeClosing_Event(object sender, FormClosingEventArgs e)
        {
            LoadBookkeepingsettings();
        }

        private void FillListPlacaArhiva()
        {
            _placaArhivaLista = (from Placa placa in _place
                                 where _odabir.Exists(s => s == placa.Oib)
                                 select new PlacaArhiva()
                                 {
                                     Oib = placa.Oib,
                                     Bruto = placa.Bruto,
                                     Mio_1 = placa.Mio_1,
                                     Mio_2 = placa.Mio_2,
                                     Dohodak = placa.Dohodak,
                                     Osobni_Odbitak = placa.Osobni_Odbitak,
                                     Porezna_Osnovica = placa.Porezna_Osnovica,
                                     Porez_1 = placa.Porez_1,
                                     Porez_2 = placa.Porez_2,
                                     Porez_Ukupno = placa.Porez_Ukupno,
                                     Prirez = placa.Prirez,
                                     Ukupno_Porez_i_Prirez = placa.Ukupno_Porez_i_Prirez,
                                     Neto = placa.Neto,
                                     Doprinos_Zdravstvo = placa.Doprinos_Zdravstvo,
                                     Dodaci_Ukupno = 0,
                                     Datum_Od = dateTimePickerDatumOd.Value.ToString("yyyy-MM-dd"),
                                     Datum_Do = dateTimePickerDatumDo.Value.ToString("yyyy-MM-dd"),
                                     Datum_obracuna = dateTimePickerDatumObracuna.Value.ToString("yyyy-MM-dd"),
                                     Knjizen = false
                                 }).ToList();
        }

        private void LoadBookkeepingsettings()
        {
            List<DataRow> dr = new DbDataGet().GetTable(new PostavkeKnjizenja(), $"Knjiga='{_bookName}'").AsEnumerable().ToList();
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

        private void SaveObracunToArhiva()
        {            
            DbDataInsert insert = new DbDataInsert();
            DbDataUpdate update = new DbDataUpdate();

            foreach (PlacaArhiva placaArhiva in _placaArhivaLista)
            {
                if (placaArhiva.Exists())
                {
                    update.UpdateData(placaArhiva);
                    continue;
                }

                insert.InsertData(placaArhiva);
            }

            MessageBox.Show("Obračun izvršen i arhiviran", "Obračun", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FilterByDate()
        {
            string filter = comboBoxDatumObracunaFilter.Text;
            if (!filter.StartsWith("--"))
            {
                List<PlacaArhiva> filtered = _placaArhivaLista.Where(x => x.Datum_obracuna.Split(' ')[0] == filter).ToList();
                _dt = new ListToDataTable().ConvertList(filtered);
                LoadDatagrid();
            }
        }

        private void FilterByName(object sender, KeyEventArgs e)
        {
            string filterCondition = $"Ime_i_prezime LIKE '%{textBoxFilterIme.Text}%'";
            (dbDataGridView1.DataSource as DataTable).DefaultView.RowFilter = filterCondition;
        }

        private void ButtonOpenPostavkeForm(object sender, EventArgs e)
        {
            PostavkeKnjizenjaPregledForm form = new PostavkeKnjizenjaPregledForm(_bookName);
            form.FormClosing += new FormClosingEventHandler(PostavkeClosing_Event);
            form.ShowDialog();
        }

        private void CheckBoxOdaberiSve_CheckStateChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dbDataGridView1.Rows)
            {
                row.Cells["Odabir"].Value = checkBoxOdaberiSve.Checked;
            }
        }

        private void ButtonObracunajPlacu_Click(object sender, EventArgs e)
        {
            _odabir.Clear();
            foreach (DataGridViewRow row in dbDataGridView1.Rows)
            {
                if (row.Cells["Odabir"].Value.ToString() == "True")
                {
                    _odabir.Add(row.Cells["Oib"].Value.ToString());
                }
            }
            FillListPlacaArhiva();
            buttonSpremiArhiva.Enabled = true;

            _dt = new ListToDataTable().ConvertList(_placaArhivaLista);
            _dt.Columns.Add("Ime i prezime", typeof(string)).SetOrdinal(0);
            _dt.Columns["Oib"].SetOrdinal(1);
            _dt.Columns["Datum_Od"].SetOrdinal(_dt.Columns.Count - 3);
            _dt.Columns["Datum_Do"].SetOrdinal(_dt.Columns.Count - 2);
            Zaposlenik z = new Zaposlenik();
            foreach (DataRow row in _dt.Rows)
            {
                z = _zaposlenici.Find(z => z.Oib == row["Oib"].ToString());
                row["Ime i prezime"] = z.Ime + ' ' + z.Prezime;
            }
            dbDataGridView1.DataSource = _dt;
            dbDataGridView1.Columns["Id"].Visible = false;

            FormatDataTableColumnHeaders();
        }

        private void ButtonSpremiArhiva_Click(object sender, EventArgs e)
        {
            SaveObracunToArhiva();
            FillComboBoxMjesec();
            buttonSpremiArhiva.Enabled = false;
            buttonKnjizi.Enabled = true;
        }

        private void ButtonKnjizi_Click(object sender, EventArgs e)
        {
            PlacaArhiva po = new PlacaArhiva();
            foreach(DataGridViewRow row in dbDataGridView1.Rows)
            {
                if(row.Cells["Odabir"].Value.ToString() == "True")
                {
                    string oib = row.Cells["Oib"].Value.ToString();
                    po.Doprinos_Zdravstvo += _placaArhivaLista.Where(p => p.Oib == oib)
                        .FirstOrDefault().Doprinos_Zdravstvo;
                    po.Mio_1 += _placaArhivaLista.Where(p => p.Oib == oib)
                        .FirstOrDefault().Mio_1;
                    po.Mio_2 += _placaArhivaLista.Where(p => p.Oib == oib)
                        .FirstOrDefault().Mio_2;
                    po.Neto += _placaArhivaLista.Where(p => p.Oib == oib)
                        .FirstOrDefault().Neto;
                    po.Porezna_Osnovica += _placaArhivaLista.Where(p => p.Oib == oib)
                        .FirstOrDefault().Porezna_Osnovica;
                    po.Prirez += _placaArhivaLista.Where(p => p.Oib == oib)
                        .FirstOrDefault().Prirez;
                    po.Porez_Ukupno += _placaArhivaLista.Where(p => p.Oib == oib)
                        .FirstOrDefault().Porez_Ukupno;
                    po.Ukupno_Porez_i_Prirez += _placaArhivaLista.Where(p => p.Oib == oib)
                        .FirstOrDefault().Ukupno_Porez_i_Prirez;
                }
            }
            po.Datum_obracuna = dbDataGridView1.Rows[0].Cells["Datum_obracuna"].Value.ToString().Split(' ')[0];
            TemeljnicaPripremaForm form = new TemeljnicaPripremaForm(po, _postavkeKnjizenja);
            form.ShowDialog();
        }

        private void ButtonDohvatArhiva_Click(object sender, EventArgs e)
        {
            _placaArhivaLista = new PlacaArhiva().GetListFromArhiva();
            _dt = new DbDataGet().GetTable(_placaArhiva);
            buttonBrisiOdabrane.Enabled = true;
            buttonKnjizi.Enabled = true;
            LoadDatagrid();
        }

        private void ButtonPocetniPrikaz_Click(object sender, EventArgs e)
        {
            _dt = new DbDataGet().GetTable(new Placa());
            buttonBrisiOdabrane.Enabled = false;
            buttonSpremiArhiva.Enabled = false;
            LoadDatagrid();
        }

        private void ButtonFiltrirajDatum_Click(object sender, EventArgs e)
        {
            FilterByDate();
        }

        private void ButtonBrisiOdabrane_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dbDataGridView1.Rows)
            {
                if (row.Cells["Odabir"].Value.ToString() == "True")
                {
                    int id = int.Parse(row.Cells["Id"].Value.ToString());
                    _placaArhiva = new PlacaArhiva() { Id = id };
                    _placaArhiva.DeleteRow();
                }
            }
            ButtonDohvatArhiva_Click(null, null);
        }

        private List<PlacaArhiva> _placaArhivaLista = new List<PlacaArhiva>();
        private PlacaArhiva _placaArhiva = new PlacaArhiva();
        private readonly List<Placa> _place;
        private readonly List<Zaposlenik> _zaposlenici;
        private readonly BookNames _bookName;
        private List<PostavkeKnjizenja> _postavkeKnjizenja;
        private DataTable _dt = new DataTable();
        private readonly List<string> _odabir = new List<string>();
    }
}
