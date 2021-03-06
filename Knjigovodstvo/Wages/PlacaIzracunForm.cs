﻿using Knjigovodstvo.Database;
using Knjigovodstvo.Employee;
using Knjigovodstvo.JoppdDocument;
using Knjigovodstvo.Settings;
using Knjigovodstvo.Validators;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Knjigovodstvo.Wages
{
    public partial class PlacaIzracunForm : Form
    {
        public PlacaIzracunForm()
        {
            InitializeComponent();
            FillComboBoxZaposlenik();
            FillComboBoxJoppd();
            SetLabelsText();
        }

        public PlacaIzracunForm(Placa placa)
        {
            _placa = placa;
            InitializeComponent();
            FillComboBoxZaposlenik();
            FillComboBoxJoppd();
            int index = comboBoxZaposlenik.FindString(_placa.Oib);
            comboBoxZaposlenik.SelectedIndex = index;
            InitPrivateMembers();
            SetLabelsText();
        }

        private void SetLabelsText()
        {
            _postavkePlace = new PostavkePlace().GetpostavkePlaceList();

            labelPorez1.Text += (_postavkePlace.Where(p => p.Naziv == "Porez_Dohodak_1")
                .FirstOrDefault().Vrijednost * 100).ToString() + "%";
            labelPorez2.Text += (_postavkePlace.Where(p => p.Naziv == "Porez_Dohodak_2")
                 .FirstOrDefault().Vrijednost * 100).ToString() + "%";
        }

        private void InitPrivateMembers()
        {
            string selected = comboBoxZaposlenik.GetItemText(this.comboBoxZaposlenik.SelectedItem);
            string oib = selected.Split(' ')[0];
            _zaposlenik.GetZaposlenikByOib(oib);
            _placa.GetPlacaByOib(_zaposlenik.Oib);
            _zaposlenikJoppd.Oib = _zaposlenik.Oib;
            _zaposlenikJoppd.GetZaposlenikByOib();
            if (_zaposlenik.Oib != "0")
            {
                _prirez = _zaposlenik.Adresa.Grad.Prirez;
                PopuniKontrole(_placa);
            }

            if (_zaposlenikJoppd.GetZaposlenikByOib(_zaposlenik.Oib).Oib != "")
            {
                PopuniJoppd();
                PopuniDodaci();
            }
        }

        private void FillComboBoxZaposlenik()
        {
            DataTable dt = _dbGet.GetTable(_zaposlenik);
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
            //TODO: shorten this and simplify
            DataTable dt = _dbGet.GetTable(new JoppdSifre(), $"Skupina='Nacin_Isplate';");
            dt.Columns.Add(
                "Sifra i opis",
                typeof(string),
                "Sifra + '   ' + Opis");
            comboBoxNacinIsplate.DataSource = dt;
            comboBoxNacinIsplate.ValueMember = "Sifra";
            comboBoxNacinIsplate.DisplayMember = "Sifra i Opis";

            dt = _dbGet.GetTable(new JoppdSifre(), $"Skupina='Stjecatelj';");
            dt.Columns.Add(
                "Sifra i opis",
                typeof(string),
                "Sifra + '   ' + Opis");
            comboBoxStjecatelj.DataSource = dt;
            comboBoxStjecatelj.ValueMember = "Sifra";
            comboBoxStjecatelj.DisplayMember = "Sifra i Opis";

            dt = _dbGet.GetTable(new JoppdSifre(), $"Skupina='Primici';");
            dt.Columns.Add(
                "Sifra i opis",
                typeof(string),
                "Sifra + '   ' + Opis");
            comboBoxPrimitak.DataSource = dt;
            comboBoxPrimitak.ValueMember = "Sifra";
            comboBoxPrimitak.DisplayMember = "Sifra i opis";

            dt = _dbGet.GetTable(new JoppdSifre(), $"Skupina='Beneficirani';");
            dt.Columns.Add(
                "Sifra i opis",
                typeof(string),
                "Sifra + '   ' + Opis");
            comboBoxDodatniMio.DataSource = dt;
            comboBoxDodatniMio.ValueMember = "Sifra";
            comboBoxDodatniMio.DisplayMember = "Sifra i opis";

            dt = _dbGet.GetTable(new JoppdSifre(), $"Skupina='Invaliditet';");
            dt.Columns.Add(
                "Sifra i opis",
                typeof(string),
                "Sifra + '   ' + Opis");
            comboBoxInvaliditet.DataSource = dt;
            comboBoxInvaliditet.ValueMember = "Sifra";
            comboBoxInvaliditet.DisplayMember = "Sifra i opis";

            dt = _dbGet.GetTable(new JoppdSifre(), $"Skupina='Mjesec';");
            dt.Columns.Add(
                "Sifra i opis",
                typeof(string),
                "Sifra + '   ' + Opis");
            comboBoxMjesecPrviZadnji.DataSource = dt;
            comboBoxMjesecPrviZadnji.ValueMember = "Sifra";
            comboBoxMjesecPrviZadnji.DisplayMember = "Sifra i opis";

            dt = _dbGet.GetTable(new JoppdSifre(), $"Skupina='Vrijeme';");
            dt.Columns.Add(
                "Sifra i opis",
                typeof(string),
                "Sifra + '   ' + Opis");
            comboBoxRadnoVrijeme.DataSource = dt;
            comboBoxRadnoVrijeme.ValueMember = "Sifra";
            comboBoxRadnoVrijeme.DisplayMember = "Sifra i opis";
        }

        private void ComboBoxZaposlenik_SelectionChangeCommitted(object sender, EventArgs e)
        {
            InitPrivateMembers();
            PopuniJoppd();
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
            textBoxPorez1.Text = Math.Round(placa.Porez_1, 2).ToString("0.00");
            textBoxPorez2.Text = Math.Round(placa.Porez_2, 2).ToString("0.00");
            textBoxPorezUkupno.Text = Math.Round(placa.Porez_Ukupno, 2).ToString("0.00");
            textBoxPrirez.Text = Math.Round(placa.Prirez, 2).ToString("0.00");
            textBoxUkupnoPorezPrirez.Text = Math.Round(placa.Ukupno_Porez_i_Prirez, 2).ToString("0.00");
            textBoxNetto.Text = Math.Round(placa.Neto, 2).ToString("0.00");
            textBoxDoprinosZdravstvo.Text = Math.Round(placa.Doprinos_Zdravstvo, 2).ToString("0.00");
            textBoxDodaci.Text = Math.Round(placa.Dodaci_Ukupno, 2).ToString("0.00");
            labelPrirez.Text = "Prirez " + _prirez.ToString() + "%";
        }

        private void PopuniJoppd()
        {
            comboBoxNacinIsplate.SelectedValue = _zaposlenikJoppd.Nacin_Isplate;
            comboBoxStjecatelj.SelectedValue = _zaposlenikJoppd.Stjecatelj;
            comboBoxPrimitak.SelectedValue = _zaposlenikJoppd.Primitak;
            comboBoxDodatniMio.SelectedValue = _zaposlenikJoppd.Beneficirani;
            comboBoxInvaliditet.SelectedValue = _zaposlenikJoppd.Invaliditet;
            comboBoxMjesecPrviZadnji.SelectedValue = _zaposlenikJoppd.Mjesec;
            comboBoxRadnoVrijeme.SelectedValue = _zaposlenikJoppd.Vrijeme;
        }

        private void PopuniDodaci()
        {
            DataTable dt = new Dodatak().GetDodaciByOib(_zaposlenik.Oib);
            List<DataRow> rows = dt.AsEnumerable().ToList();
            _placa.AddDodaci((from DataRow row in rows
                              select new Dodatak()
                              {
                                  Id = int.Parse(row["Id"].ToString()),
                                  Oib = row["Oib"].ToString(),
                                  Sifra = row["Sifra"].ToString(),
                                  Iznos = decimal.Parse(row["Iznos"].ToString())
                              }).ToList());
            textBoxDodaci.Text = _placa.Dodaci_Ukupno.ToString();
        }

        private void PromjenaZaposlenikJoppd_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetZaposlenikJoppd();
        }

        private void DodaciFormClosed()
        {
            PopuniDodaci();
            PopuniKontrole(_placa);
            PopuniJoppd();
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
                DodatakUnosForm dodaci = new DodatakUnosForm(_zaposlenik, _placa);
                _placa = dodaci.ShowDialogValue();
                DodaciFormClosed();
            }
            else
            {
                MessageBox.Show("Niste odabrali zaposlenika.", "Izračun", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            DataTable dt = new DbDataGet().GetTable(_placa, $"Oib='{_zaposlenik.Oib}'");

            if (comboBoxZaposlenik.SelectedItem != null && _placa.Oib != "" && _placa.Oib != "0")
            {
                if (dt.Rows.Count == 0 && new DbDataInsert().InsertData(_placa))
                {     
                    MessageBox.Show("Unos uspješan.", "Novi izračun unešen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(dt.Rows.Count != 0 && new DbDataUpdate().UpdateData(_placa))
                {
                    MessageBox.Show("Izmjena Podataka uspješna.", "Izmjena izračuna", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ButtonIzracunaj_Click(object sender, EventArgs e)
        {
            SetZaposlenikJoppd();

            if (new DecimalValidate().Check(textBoxBruto.Text))
            {
                if (comboBoxZaposlenik.SelectedItem != null)
                {
                    PopuniDodaci();
                    _placa.Bruto = decimal.Parse(textBoxBruto.Text);
                    labelPrirez.Text = "Prirez " + _prirez.ToString() + '%';
                    new PlacaIzracun().Calculate(_placa, _prirez, _zaposlenik.Olaksica, checkBoxSamoMio1.Checked);
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

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private ZaposlenikJoppd _zaposlenikJoppd = new ZaposlenikJoppd();
        private Placa _placa = new Placa();
        private readonly Zaposlenik _zaposlenik = new Zaposlenik();
        private decimal _prirez = 0;
        private readonly DbDataGet _dbGet = new DbDataGet();
        private List<PostavkePlace> _postavkePlace;
    }
}
