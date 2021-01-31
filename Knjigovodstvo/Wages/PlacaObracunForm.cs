using Knjigovodstvo.Books.PrepareForBalanceSheet;
using Knjigovodstvo.Database;
using Knjigovodstvo.Employee;
using Knjigovodstvo.Helpers;
using Knjigovodstvo.Settings;
using Knjigovodstvo.Settings.SettingsBookkeeping;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Knjigovodstvo.Wages
{
    public partial class PlacaObracunForm : Form
    {
        public PlacaObracunForm()
        {
            InitializeComponent();
            InitializeControls();
            LoadComboBoxMjesec();
            LoadBookkeepingsettings();
            LoadDatagrid();
        }

        #region Loaders
        private void InitializeControls()
        {
            DateTime date = DateTime.Now.AddMonths(-1);
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            dateTimePickerDatumOd.Value = firstDayOfMonth;
            dateTimePickerDatumDo.Value = lastDayOfMonth;
            _zaposlenici = new Zaposlenik().GetListZaposlenik();
            _dt = _placa.GetPlacaDataTable();
        }

        private void LoadDatagrid()
        {            
            _dt.Columns.Add("Ime_i_prezime", typeof(string)).SetOrdinal(0);
            _dt.Columns.Add("Odabir", typeof(bool)).SetOrdinal(0);

            LoadNameColumn();

            dbDataGridView1.DataSource = _dt;
            dbDataGridView1.Columns["Id"].Visible = false;
            dbDataGridView1.Columns[0].Width = 50;

            checkBoxOdaberiSve.Checked = false;

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

        private void LoadComboBoxMjesec()
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

        private void LoadListPlacaArhiva()
        {
            _placaArhivaLista.Clear();
            foreach(DataGridViewRow row in dbDataGridView1.Rows)
            {
                if (row.Cells["Odabir"].Value.ToString() == "True")
                {
                    PlacaArhiva p =_placaArhiva.ConvertDataRow(row);
                    p.Datum_Od = dateTimePickerDatumOd.Value.ToString("yyyy-MM-dd");
                    p.Datum_Do = dateTimePickerDatumDo.Value.ToString("yyyy-MM-dd");
                    p.Datum_obracuna = dateTimePickerDatumObracuna.Value.ToString("yyyy-MM-dd");
                    
                    _placaArhivaLista.Add(p);
                }
            }
        }

        private void LoadNameColumn()
        {
            Zaposlenik z = new Zaposlenik();
            foreach (DataRow row in _dt.Rows)
            {
                z = _zaposlenici.Find(z => z.Oib == row["Oib"].ToString());
                row["Ime_i_prezime"] = z.Ime + ' ' + z.Prezime;
            }
        }

        private void LoadBookkeepingsettings()
        {
            _postavkeKnjizenja = new PostavkeKnjizenja()
                .GetPostavkeKnjizenjaList(BookNames.Place);
        }
        #endregion

        #region Filters
        private void FilterByDate()
        {
            string datumObracuna = DateTime.Parse(comboBoxDatumObracunaFilter.Text).ToString("yyyy-MM-dd");
            if (!datumObracuna.StartsWith("--"))
            {
                _dt = _placaArhiva.GetPlacaArhivaDataTable($"Datum_obracuna='{datumObracuna}'");
                LoadDatagrid();
            }
        }

        private void FilterByName(object sender, KeyEventArgs e)
        {
            string filterCondition = $"Ime_i_prezime LIKE '%{textBoxFilterIme.Text}%'";
            (dbDataGridView1.DataSource as DataTable).DefaultView.RowFilter = filterCondition;
        }
        #endregion

        private void CheckBoxOdaberiSve_CheckStateChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dbDataGridView1.Rows)
            {
                row.Cells["Odabir"].Value = checkBoxOdaberiSve.Checked;
            }
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
            LoadComboBoxMjesec();
        }

        #region Buttons
        private void ButtonOpenPostavkeForm(object sender, EventArgs e)
        {
            PostavkeKnjizenjaPregledForm form = new PostavkeKnjizenjaPregledForm(BookNames.Place);
            form.ShowDialog();
            LoadBookkeepingsettings();
        }

        private void ButtonObracunajPlacu_Click(object sender, EventArgs e)
        {
            LoadListPlacaArhiva();
            SaveObracunToArhiva();

            _dt = _placaArhiva.GetPlacaArhivaDataTable();
            LoadDatagrid();
        }

        private void ButtonKnjizi_Click(object sender, EventArgs e)
        {
            PlacaArhiva po = new PlacaArhiva();
            foreach(DataGridViewRow row in dbDataGridView1.Rows)
            {
                if(row.Cells["Odabir"].Value.ToString() == "True")
                {
                    //Sum all individual item for each selected wage
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
            _dt = _placaArhiva.GetPlacaArhivaDataTable();
            _placaArhivaLista = _placaArhiva.DataTableToList(_dt);
            buttonBrisiOdabrane.Enabled = true;
            buttonKnjizi.Enabled = true;
            LoadDatagrid();
        }

        private void ButtonPocetniPrikaz_Click(object sender, EventArgs e)
        {
            _dt = _placa.GetPlacaDataTable();
            buttonBrisiOdabrane.Enabled = false;
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
        #endregion

        private List<PlacaArhiva> _placaArhivaLista = new List<PlacaArhiva>();
        private PlacaArhiva _placaArhiva = new PlacaArhiva();
        private readonly Placa _placa = new Placa();
        private List<Zaposlenik> _zaposlenici;
        private List<PostavkeKnjizenja> _postavkeKnjizenja;
        private DataTable _dt = new DataTable();
    }
}