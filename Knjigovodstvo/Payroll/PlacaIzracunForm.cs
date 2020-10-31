using Knjigovodstvo.City;
using Knjigovodstvo.Database;
using Knjigovodstvo.Employee;
using Knjigovodstvo.JoppdDocument;
using Knjigovodstvo.Validators;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Knjigovodstvo.Payroll
{
    public partial class PlacaIzracunForm : Form
    {
        public PlacaIzracunForm()
        {
            InitializeComponent();
            FillComboBoxZaposlenik();
            FillComboBoxJoppd();
        }

        public PlacaIzracunForm(string oib)
        {
            InitializeComponent();
            FillComboBoxZaposlenik();
            int index = comboBoxZaposlenik.FindString(oib);
            comboBoxZaposlenik.SelectedIndex = index;
            InitPrivateMembers();
            FillComboBoxJoppd();
        }

        private void InitPrivateMembers()
        {
            string selected = this.comboBoxZaposlenik.GetItemText(this.comboBoxZaposlenik.SelectedItem);
            string oib = selected.Split(' ')[0];
            _zaposlenik = _zaposlenik.GetZaposlenikByOib(oib);
            _zaposlenikJoppd = _zaposlenikJoppd.GetZaposlenikByOib(oib);
            if (_placa.GetPlacaByOib(_zaposlenik.Oib).Oib != "0")
            {
                PopuniKontrole(_placa);
            }

            if (_zaposlenikJoppd.GetZaposlenikByOib(_zaposlenik.Oib).Oib != "")
            {
                PopuniJoppd(_zaposlenikJoppd);
                PopuniDodaci();
            }
        }

        private void FillComboBoxZaposlenik()
        {
            DataTable dt = new DbDataGet().GetTable(_zaposlenik);
            dt.Columns.Add(
                "Ime i prezime", 
                typeof(string),
                "oib + '   ' + Ime + ' ' + Prezime");
            comboBoxZaposlenik.DataSource = dt;
            comboBoxZaposlenik.DisplayMember = "Ime i prezime";
            comboBoxZaposlenik.SelectedItem = null;
            comboBoxZaposlenik.Text = "--Odaberi zaposlenika--";
        }

        private void FillComboBoxJoppd()
        {
            DbDataGet data = new DbDataGet();
            //TODO: shorten this and simplify
            DataTable dt = data.GetTable(new JoppdSifre(), $"Skupina='Nacin_Isplate';");
            dt.Columns.Add(
                "Sifra i opis",
                typeof(string),
                "Sifra + '   ' + Opis");
            comboBoxNacinIsplate.DataSource = dt;
            comboBoxNacinIsplate.ValueMember = "Sifra";
            comboBoxNacinIsplate.DisplayMember = "Sifra i Opis";

            dt = data.GetTable(new JoppdSifre(), $"Skupina='Stjecatelj';");
            dt.Columns.Add(
                "Sifra i opis",
                typeof(string),
                "Sifra + '   ' + Opis");
            comboBoxStjecatelj.DataSource = dt;
            comboBoxStjecatelj.ValueMember = "Sifra";
            comboBoxStjecatelj.DisplayMember = "Sifra i Opis";

            dt = data.GetTable(new JoppdSifre(), $"Skupina='Primici';");
            dt.Columns.Add(
                "Sifra i opis",
                typeof(string),
                "Sifra + '   ' + Opis");
            comboBoxPrimitak.DataSource = dt;
            comboBoxPrimitak.ValueMember = "Sifra";
            comboBoxPrimitak.DisplayMember = "Sifra i opis";

            dt = data.GetTable(new JoppdSifre(), $"Skupina='Beneficirani';");
            dt.Columns.Add(
                "Sifra i opis",
                typeof(string),
                "Sifra + '   ' + Opis");
            comboBoxDodatniMio.DataSource = dt;
            comboBoxDodatniMio.ValueMember = "Sifra";
            comboBoxDodatniMio.DisplayMember = "Sifra i opis";

            dt = data.GetTable(new JoppdSifre(), $"Skupina='Invaliditet';");
            dt.Columns.Add(
                "Sifra i opis",
                typeof(string),
                "Sifra + '   ' + Opis");
            comboBoxInvaliditet.DataSource = dt;
            comboBoxInvaliditet.ValueMember = "Sifra";
            comboBoxInvaliditet.DisplayMember = "Sifra i opis";

            dt = data.GetTable(new JoppdSifre(), $"Skupina='Mjesec';");
            dt.Columns.Add(
                "Sifra i opis",
                typeof(string),
                "Sifra + '   ' + Opis");
            comboBoxMjesecPrviZadnji.DataSource = dt;
            comboBoxMjesecPrviZadnji.ValueMember = "Sifra";
            comboBoxMjesecPrviZadnji.DisplayMember = "Sifra i opis";

            dt = data.GetTable(new JoppdSifre(), $"Skupina='Vrijeme';");
            dt.Columns.Add(
                "Sifra i opis",
                typeof(string),
                "Sifra + '   ' + Opis");
            comboBoxRadnoVrijeme.DataSource = dt;
            comboBoxRadnoVrijeme.ValueMember = "Sifra";
            comboBoxRadnoVrijeme.DisplayMember = "Sifra i opis";
        }        

        //TODO: not needed, refactor
        internal void EditPlaca(Placa placa)
        {
            PopuniKontrole(placa);
            int index = comboBoxZaposlenik.FindString(placa.Oib);
            comboBoxZaposlenik.SelectedIndex = index;

            ShowDialog();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ComboBoxZaposlenik_SelectionChangeCommitted(object sender, EventArgs e)
        {
            InitPrivateMembers();
        }

        private void SetZaposlenikJoppd()
        {
            _zaposlenikJoppd.Oib = _zaposlenik.Oib;
            _zaposlenikJoppd.Nacin_Isplate = comboBoxNacinIsplate.SelectedValue.ToString();
            _zaposlenikJoppd.Stjecatelj = comboBoxStjecatelj.SelectedValue.ToString();
            _zaposlenikJoppd.Primitak = comboBoxPrimitak.SelectedValue.ToString();
            _zaposlenikJoppd.Beneficirani = comboBoxDodatniMio.SelectedValue.ToString();
            _zaposlenikJoppd.Invaliditet = comboBoxInvaliditet.SelectedValue.ToString();
            _zaposlenikJoppd.Mjesec = comboBoxMjesecPrviZadnji.SelectedValue.ToString();
            _zaposlenikJoppd.Vrijeme = comboBoxRadnoVrijeme.SelectedValue.ToString();
        }

        private void PopuniKontrole(Placa placa)
        {
            textBoxBruto.Text =
            textBoxBrutoRead.Text = Math.Round(placa.Bruto, 2).ToString("0.00");
            textBoxMio1.Text = Math.Round(placa.Mio_1, 2).ToString("0.00");
            textBoxMio2.Text = Math.Round(placa.Mio_2, 2).ToString("0.00");
            textBoxDohodak.Text = Math.Round(placa.Dohodak, 2).ToString("0.00");
            textBoxOdbitak.Text = Math.Round(placa.Osobni_Odbitak, 2).ToString("0.00");
            textBoxPoreznaOsnovica.Text = Math.Round(placa.Porezna_Osnovica, 2).ToString("0.00");
            textBoxPorez24.Text = Math.Round(placa.Porez_24_per, 2).ToString("0.00");
            textBoxPorez36.Text = Math.Round(placa.Porez_36_per, 2).ToString("0.00");
            textBoxPorezUkupno.Text = Math.Round(placa.Porez_Ukupno, 2).ToString("0.00");
            textBoxPrirez.Text = Math.Round(placa.Prirez, 2).ToString("0.00");
            textBoxUkupnoPorezPrirez.Text = Math.Round(placa.Ukupno_Porez_i_Prirez, 2).ToString("0.00");
            textBoxNetto.Text = Math.Round(placa.Neto, 2).ToString("0.00");
            textBoxDoprinosZdravstvo.Text = Math.Round(placa.Doprinos_Zdravstvo, 2).ToString("0.00");
            textBoxDodaci.Text = Math.Round(placa.Dodaci_Ukupno, 2).ToString("0.00");
            labelPrirez.Text ="Prirez " + Math.Round(placa.Prirez / placa.Porez_Ukupno * 100.0m, 0).ToString("0") + '%';
        }

        private void PopuniJoppd(ZaposlenikJoppd zaposlenikJoppd)
        {
            comboBoxNacinIsplate.SelectedValue = zaposlenikJoppd.Nacin_Isplate;
            comboBoxStjecatelj.SelectedValue = zaposlenikJoppd.Stjecatelj;
            comboBoxPrimitak.SelectedValue = zaposlenikJoppd.Primitak;
            comboBoxDodatniMio.SelectedValue = zaposlenikJoppd.Beneficirani;
            comboBoxInvaliditet.SelectedValue = zaposlenikJoppd.Invaliditet;
            comboBoxMjesecPrviZadnji.SelectedValue = zaposlenikJoppd.Mjesec;
            comboBoxRadnoVrijeme.SelectedValue = zaposlenikJoppd.Vrijeme;
        }

        private void PopuniDodaci()
        {
            DataTable dt = new PlacaDodatak().GetDodaciByOib(_zaposlenik.Oib);
            List<DataRow> rows = dt.AsEnumerable().ToList();
            _dodaci = (from DataRow row in rows
                       select new PlacaDodatak()
                       {
                           Id = int.Parse(row["Id"].ToString()),
                           Oib = row["Oib"].ToString(),
                           Sifra = row["Sifra"].ToString(),
                           Iznos = decimal.Parse(row["Iznos"].ToString())
                       }).ToList();
            decimal dodaciUkupno = 0;
            if (_dodaci.Count > 0)
            {
                dodaciUkupno = ZbrojiDodatke();
            }
            textBoxDodaci.Text = dodaciUkupno.ToString();
        }

        private decimal ZbrojiDodatke()
        {
            decimal dodaciUkupno = 0;
            foreach (PlacaDodatak d in _dodaci)
            {
                dodaciUkupno += d.Iznos;
            }

            return dodaciUkupno;
        }

        private void PromjenaZaposlenikJoppd_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetZaposlenikJoppd();
        }

        private void DodaciNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            PopuniKontrole(_placa);
            PopuniJoppd(_zaposlenikJoppd);
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void ButtonSpremiJoppdPostavke_Click(object sender, EventArgs e)
        {
            ZaposlenikJoppd provjera = new ZaposlenikJoppd().GetZaposlenikByOib(_zaposlenik.Oib);
            SetZaposlenikJoppd();
            if (provjera.Id == 0)
            {
                if (new DbDataInsert().InsertData(_zaposlenikJoppd))
                    MessageBox.Show("Podaci za JOPPD ažurirani.", "Izračun", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _zaposlenikJoppd.Id = provjera.Id;
                if(new DbDataUpdate().UpdateData(_zaposlenikJoppd))
                    MessageBox.Show("Podaci za JOPPD ažurirani.", "Izračun", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ButtonDodaci_Click(object sender, EventArgs e)
        {
            if (comboBoxZaposlenik.SelectedItem != null)
            {
                DodaciUnosForm dodaci = new DodaciUnosForm(_zaposlenik, _placa);
                _placa= dodaci.ShowDialogValue();
                dodaci.FormClosing += new FormClosingEventHandler(this.DodaciNew_FormClosing);
            }
            else
            {
                MessageBox.Show("Niste odabrali zaposlenika.", "Izračun", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxZaposlenik.SelectedItem != null && _placa.Oib != "" && _placa.Oib != "0")
            {
                if (new Placa().GetPlacaByOib(_zaposlenik.Oib).Oib == "0")
                {
                    if (new DbDataInsert().InsertData(_placa))
                    {
                        FillComboBoxZaposlenik();
                        MessageBox.Show("Unos uspješan.", "Novi izračun unešen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (new DbDataUpdate().UpdateData(_placa))
                    {
                        FillComboBoxZaposlenik();
                        MessageBox.Show("Unos uspješan.", "Izmjena unešena", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void ButtonIzracunaj_Click(object sender, EventArgs e)
        {
            SetZaposlenikJoppd();

            if (new FloatValidator().Check(textBoxBruto.Text))
            {
                if (comboBoxZaposlenik.SelectedItem != null)
                {
                    PopuniDodaci();
                    decimal prirez = decimal.Parse(new DbDataGet().GetTable(new Grad(), $"Naziv='{_zaposlenik.Grad}';").Rows[0]["Prirez"].ToString()) / 100.0m;
                    decimal iznosBruto = decimal.Parse(textBoxBruto.Text);
                    labelPrirez.Text = "Prirez " + (prirez * 100).ToString() + '%';
                    _placa.Izracun(iznosBruto, prirez, ZbrojiDodatke(), _zaposlenik.Olaksica, checkBoxSamoMio1.Checked);
                    _placa.Oib = _zaposlenik.Oib;

                    PopuniKontrole(_placa);
                }
                else
                {
                    MessageBox.Show("Niste odabrali zaposlenika.", "Izračun", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Neispravan format unešenog broja.", "Izračun", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private ZaposlenikJoppd _zaposlenikJoppd = new ZaposlenikJoppd();
        private Placa _placa = new Placa();
        private Zaposlenik _zaposlenik = new Zaposlenik();
        private List<PlacaDodatak> _dodaci = new List<PlacaDodatak>();
    }
}
