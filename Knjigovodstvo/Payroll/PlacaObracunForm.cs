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
            FillListPlaca();
            FillComboBoxMjesec();
            FillComboBoxZaposlenik();
            LoadBookkeepingsettings();
            //TODO: remove after testing
            buttonKnjizi.Enabled = true;
        }

        private void FillListPlaca()
        {
            DataTable dt = new DbDataGet().GetTable(new Placa());

            List<DataRow> rows = dt.AsEnumerable().ToList();
            _place = (from DataRow data in rows
                      select new Placa()
                      {
                          Id = int.Parse(data["Id"].ToString()),
                          Oib = data["Oib"].ToString(),
                          Bruto = decimal.Parse(data["Bruto"].ToString()),
                          Mio_1 = decimal.Parse(data["Mio_1"].ToString()),
                          Mio_2 = decimal.Parse(data["Mio_2"].ToString()),
                          Dohodak = decimal.Parse(data["Dohodak"].ToString()),
                          Osobni_Odbitak = decimal.Parse(data["Osobni_Odbitak"].ToString()),
                          Porezna_Osnovica = decimal.Parse(data["Porezna_Osnovica"].ToString()),
                          Porez_1 = decimal.Parse(data["Porez_1"].ToString()),
                          Porez_2 = decimal.Parse(data["Porez_2"].ToString()),
                          Porez_Ukupno = decimal.Parse(data["Porez_Ukupno"].ToString()),
                          Prirez = decimal.Parse(data["Prirez"].ToString()),
                          Ukupno_Porez_i_Prirez = decimal.Parse(data["Ukupno_Porez_i_Prirez"].ToString()),
                          Neto = decimal.Parse(data["Neto"].ToString()),
                          Doprinos_Zdravstvo = decimal.Parse(data["Doprinos_Zdravstvo"].ToString()),
                          Dodaci_Ukupno = decimal.Parse(data["Dodaci_Ukupno"].ToString())
                      }).ToList();
        }

        private void LoadDatagrid()
        {
            string selected = this.comboBoxFilterDjelatnik.GetItemText(this.comboBoxFilterDjelatnik.SelectedItem);
            string oib = selected.Split(' ')[0];
            string condition = "";
            if (oib.Length == 11)
                condition = $"Oib='{oib}'";

            selected = this.comboBoxFilterPoMjesecu.GetItemText(this.comboBoxFilterPoMjesecu.SelectedItem);
            string mjesec = "";
            string godina = "";
            if (selected != "")
            {
                mjesec = selected.Split('/')[0];
                godina = selected.Split('/')[1];
            }
            if(mjesec.Length >= 1 && godina.Length == 4)
            {
                if (condition.Length == 17)
                    condition += " AND ";
                condition += $"DATEPART(month, Datum_Od)={mjesec} AND DATEPART(year, Datum_Od) = {godina};";
            }

            if (condition == "")
                condition = null;

            dataGridView1.DataSource = _dbDataGet.GetTable(new PlacaArhiva(), condition);
            for (int i = 3; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].DefaultCellStyle.Format = "0.00";
            }

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].HeaderText =
                     new TableHeaderFormat().FormatHeader(dataGridView1.Columns[i].HeaderText);
            }
        }

        private void FillComboBoxZaposlenik()
        {
            DataTable dt = new DbDataGet().GetTable(new Zaposlenik());
            dt.Columns.Add(
                "Ime i prezime",
                typeof(string),
                "oib + '   ' + Ime + ' ' + Prezime");
            comboBoxFilterDjelatnik.DataSource = dt;
            comboBoxFilterDjelatnik.DisplayMember = "Ime i prezime";
            comboBoxFilterDjelatnik.SelectedItem = null;
            comboBoxFilterDjelatnik.Text = "--Odaberi zaposlenika--";
        }

        private void FillComboBoxMjesec()
        {
            DataTable dt = new DbDataExecProcedure
                ().GetTable(
                ProcedureNames.Placa_Distinct_Datum);
            dt.Columns.Add(
                "Mjesec",
                typeof(string),
                "monthdate + '/' + yeardate");
            comboBoxFilterPoMjesecu.DataSource = dt;
            comboBoxFilterPoMjesecu.DisplayMember = "Mjesec";
            comboBoxFilterPoMjesecu.SelectedItem = null;
            comboBoxFilterPoMjesecu.Text = "--Odaberi mjesec--";
        }

        private void ComboBoxFilter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadDatagrid();
        }

        private void PostavkeClosing_Event(object sender, FormClosingEventArgs e)
        {
            LoadBookkeepingsettings();
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

        private void SaveObracun()
        {            
            DbDataInsert insert = new DbDataInsert();
            DbDataUpdate update = new DbDataUpdate();

            foreach (PlacaArhiva placaArhiva in _placaArhiva)
            {
                if (placaArhiva.Exists())
                {
                    update.UpdateData(placaArhiva);
                    continue;
                }

                insert.InsertData(placaArhiva);
            }

            MessageBox.Show("Obračun izvršen", "Obračun", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDatagrid();
        }

        private void ButtonOpenPostavkeForm(object sender, EventArgs e)
        {
            PostavkeKnjizenjaPregledForm form = new PostavkeKnjizenjaPregledForm(_bookName);
            form.FormClosing += new FormClosingEventHandler(PostavkeClosing_Event);
            form.ShowDialog();
        }

        private void ButtonPonisti_Click(object sender, EventArgs e)
        {
            comboBoxFilterDjelatnik.SelectedItem = null;
            comboBoxFilterDjelatnik.Text = "--Odaberi zaposlenika--";
            comboBoxFilterPoMjesecu.SelectedItem = null;
            comboBoxFilterPoMjesecu.Text = "--Odaberi mjesec--";
            LoadDatagrid();
        }

        private void ButtonObracunajPlacu_Click(object sender, EventArgs e)
        {
            _placaArhiva = (from Placa placa in _place
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
                                 Datum_Do = dateTimePickerDatumDo.Value.ToString("yyyy-MM-dd")
                             }).ToList();
            SaveObracun();
        }

        private void ButtonKnjizi_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count == 0 || comboBoxFilterPoMjesecu.Text.Contains("--"))
            {
                MessageBox.Show("Niste odabrali mjesec obračuna", "Obračun", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PlacaArhiva po = new PlacaArhiva();
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                po.Bruto += decimal.Parse(row.Cells["Bruto"].Value.ToString());
                po.Mio_1 += decimal.Parse(row.Cells["Mio_1"].Value.ToString());
                po.Mio_2 += decimal.Parse(row.Cells["Mio_2"].Value.ToString());
                po.Dohodak += decimal.Parse(row.Cells["Dohodak"].Value.ToString());
                po.Osobni_Odbitak += decimal.Parse(row.Cells["Osobni_Odbitak"].Value.ToString());
                po.Porezna_Osnovica += decimal.Parse(row.Cells["Porezna_Osnovica"].Value.ToString());
                po.Porez_1 += decimal.Parse(row.Cells["Porez_1"].Value.ToString());
                po.Porez_2 += decimal.Parse(row.Cells["Porez_2"].Value.ToString());
                po.Porez_Ukupno += decimal.Parse(row.Cells["Porez_Ukupno"].Value.ToString());
                po.Prirez += decimal.Parse(row.Cells["Prirez"].Value.ToString());
                po.Ukupno_Porez_i_Prirez += decimal.Parse(row.Cells["Ukupno_Porez_i_Prirez"].Value.ToString());
                po.Neto += decimal.Parse(row.Cells["Neto"].Value.ToString());
                po.Doprinos_Zdravstvo += decimal.Parse(row.Cells["Doprinos_Zdravstvo"].Value.ToString());
                po.Dodaci_Ukupno += decimal.Parse(row.Cells["Dodaci_Ukupno"].Value.ToString());
            }
            po.Datum_Do = comboBoxFilterPoMjesecu.Text;//use this string for description date in next step
            TemeljnicaPripremaForm form = new TemeljnicaPripremaForm(po, _postavkeKnjizenja);
            form.ShowDialog();
        }

        private List<PlacaArhiva> _placaArhiva = new List<PlacaArhiva>();
        private List<Placa> _place = new List<Placa>();
        private readonly DbDataGet _dbDataGet = new DbDataGet();
        private readonly BookNames _bookName;
        private List<PostavkeKnjizenja> _postavkeKnjizenja;
    }
}
