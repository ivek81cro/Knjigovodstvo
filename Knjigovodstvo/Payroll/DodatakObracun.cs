using Knjigovodstvo.Books.PrepareForBalanceSheet;
using Knjigovodstvo.Database;
using Knjigovodstvo.Employee;
using Knjigovodstvo.Helpers;
using Knjigovodstvo.JoppdDocument;
using Knjigovodstvo.Settings;
using Knjigovodstvo.Settings.SettingsBookkeeping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Knjigovodstvo.Payroll
{
    public partial class DodatakObracun : Form
    {
        public DodatakObracun()
        {
            InitializeComponent();
            DateTime date = DateTime.Now.AddMonths(-1);
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            dateTimePickerDatumOd.Value = firstDayOfMonth;
            dateTimePickerDatumDo.Value = lastDayOfMonth;
            _bookName = BookNames.Dodaci;
            FillListDodaci();
            FillComboBoxMjesec();
            FillComboBoxZaposlenik();
            LoadBookkeepingsettings();
            FillComboBoxDodaci();
        }

        private void FillListDodaci()
        {
            DataTable dt = new DbDataGet().GetTable(new Dodatak());

            List<DataRow> rows = dt.AsEnumerable().ToList();
            _dodaci = (from DataRow data in rows
                      select new Dodatak()
                      {
                          Id = int.Parse(data["Id"].ToString()),
                          Oib = data["Oib"].ToString(),
                          Sifra = data["Sifra"].ToString(),
                          Iznos = decimal.Parse(data["Iznos"].ToString())
                      }).ToList();
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
                ProcedureNames.Dodatak_Distinct_Datum);
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
            if (mjesec.Length >= 1 && godina.Length == 4)
            {
                if (condition.Length == 17)
                    condition += " AND ";
                condition += $"DATEPART(month, Datum_Od)={mjesec} AND DATEPART(year, Datum_Od) = {godina};";
            }

            if (condition == "")
                condition = null;

            dataGridView1.DataSource = _dbDataGet.GetTable(new DodatakArhiva(), condition);
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

        private void FillComboBoxDodaci()
        {
            DataTable dt = new DbDataGet().GetTable(new JoppdSifre(), $"Skupina='{Joppd_skupine.Neoporezivo}';");
            dt.Columns.Add(
                "Naziv i Opis",
                typeof(string),
                "Sifra + ' - ' + Opis");
            comboBoxOdabirDodatka.DataSource = dt;
            comboBoxOdabirDodatka.DisplayMember = "Naziv i Opis";
            comboBoxOdabirDodatka.SelectedItem = null;
            comboBoxOdabirDodatka.Text = "--Odaberi dodatak--";
        }

        private void ButtonPonisti_Click(object sender, EventArgs e)
        {
            comboBoxFilterDjelatnik.SelectedItem = null;
            comboBoxFilterDjelatnik.Text = "--Odaberi zaposlenika--";
            comboBoxFilterPoMjesecu.SelectedItem = null;
            comboBoxFilterPoMjesecu.Text = "--Odaberi mjesec--";
            LoadDatagrid();
        }

        private void ButtonOpenPostavkeForm(object sender, EventArgs e)
        {
            PostavkeKnjizenjaPregledForm form = new PostavkeKnjizenjaPregledForm(_bookName);
            form.FormClosing += new FormClosingEventHandler(PostavkeClosing_Event);
            form.ShowDialog();
        }

        private void PostavkeClosing_Event(object sender, FormClosingEventArgs e)
        {
            LoadBookkeepingsettings();
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal comma
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void ButtonKnjizi_Click(object sender, EventArgs e)
        {
            DodatakArhiva da = new DodatakArhiva();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                //po.Bruto += decimal.Parse(row.Cells["Bruto"].Value.ToString());
                //po.Mio_1 += decimal.Parse(row.Cells["Mio_1"].Value.ToString());
                //po.Mio_2 += decimal.Parse(row.Cells["Mio_2"].Value.ToString());
                //po.Dohodak += decimal.Parse(row.Cells["Dohodak"].Value.ToString());
                //po.Osobni_Odbitak += decimal.Parse(row.Cells["Osobni_Odbitak"].Value.ToString());
                //po.Porezna_Osnovica += decimal.Parse(row.Cells["Porezna_Osnovica"].Value.ToString());
                //po.Porez_24_per += decimal.Parse(row.Cells["Porez_24_per"].Value.ToString());
                //po.Porez_36_per += decimal.Parse(row.Cells["Porez_36_per"].Value.ToString());
                //po.Porez_Ukupno += decimal.Parse(row.Cells["Porez_Ukupno"].Value.ToString());
                //po.Prirez += decimal.Parse(row.Cells["Prirez"].Value.ToString());
                //po.Ukupno_Porez_i_Prirez += decimal.Parse(row.Cells["Ukupno_Porez_i_Prirez"].Value.ToString());
                //po.Neto += decimal.Parse(row.Cells["Neto"].Value.ToString());
                //po.Doprinos_Zdravstvo += decimal.Parse(row.Cells["Doprinos_Zdravstvo"].Value.ToString());
                //po.Dodaci_Ukupno += decimal.Parse(row.Cells["Dodaci_Ukupno"].Value.ToString());
            }
            TemeljnicaPripremaForm form = new TemeljnicaPripremaForm(da, _postavkeKnjizenja);
            form.ShowDialog();
        }

        private void ButtonObracunajDodatke_Click(object sender, EventArgs e)
        {
            _dodatakArhiva = new BindingList<DodatakArhiva>();
            foreach(var dodatak in _dodaci)
            {
                _dodatakArhiva.Add(new DodatakArhiva() 
                {
                    Oib = dodatak.Oib,
                    Sifra = dodatak.Sifra,
                    Iznos = dodatak.Iznos,
                    Datum_Od = DateTime.ParseExact(dateTimePickerDatumOd.Text, 
                    ("dd.MM.yyyy"),
                    CultureInfo.InvariantCulture).
                    ToString("yyyy-MM-dd"),
                    Datum_Do = DateTime.ParseExact(dateTimePickerDatumDo.Text, 
                    ("dd.MM.yyyy"), 
                    CultureInfo.InvariantCulture)
                    .ToString("yyyy-MM-dd")
                });
            }
            dataGridView1.DataSource = _dodatakArhiva;
        }

        private void ButtonSpremi_Click(object sender, EventArgs e)
        {
            foreach (var dodatakA in _dodatakArhiva) 
            {
                dodatakA.SaveToDatabase();
            }
        }

        private void ButtonNoviDodatak_Click(object sender, EventArgs e)
        {
            _dodaci = new List<Dodatak>();
            List<Zaposlenik> zaposlenik = new Zaposlenik().GetListZaposlenik();

            if (comboBoxOdabirDodatka.Text.Contains("--") || textBoxIznos.Text == "")
            {
                MessageBox.Show("Niste odabrali dodatak ili niste unjeli iznos",
                    "Upozorenje",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (checkBoxSvi.Checked)
            {
                foreach (var osoba in zaposlenik)
                {
                    _dodaci.Add(
                        new Dodatak()
                        {
                            Sifra = comboBoxOdabirDodatka.Text.Split(' ')[0],
                            Oib = osoba.Oib,
                            Iznos = decimal.Parse(textBoxIznos.Text)
                        });
                }
            }
            else
            {
                string oib = comboBoxFilterDjelatnik.Text.Split(' ')[0];
                if (oib.Length != 11)
                {
                    MessageBox.Show("Niste odabrali pojedinačnog djelatnika", 
                        "Upozorenje", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Warning);
                    return;
                }
                Zaposlenik osoba = zaposlenik.FirstOrDefault(z => z.Oib == oib);
                _dodaci.Add(
                        new Dodatak()
                        {
                            Sifra = comboBoxOdabirDodatka.Text.Split(' ')[0],
                            Oib = osoba.Oib,
                            Iznos = decimal.Parse(textBoxIznos.Text)
                        });
            }
            dataGridView1.DataSource = _dodaci;
        }

        private BindingList<DodatakArhiva> _dodatakArhiva = new BindingList<DodatakArhiva>();
        private List<Dodatak> _dodaci = new List<Dodatak>();
        private readonly DbDataGet _dbDataGet = new DbDataGet();
        private readonly BookNames _bookName;
        private List<PostavkeKnjizenja> _postavkeKnjizenja;
    }
}
