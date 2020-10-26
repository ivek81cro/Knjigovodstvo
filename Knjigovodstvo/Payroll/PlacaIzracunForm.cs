﻿using Knjigovodstvo.City;
using Knjigovodstvo.Database;
using Knjigovodstvo.Employee;
using Knjigovodstvo.Validators;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Knjigovodstvo.Payroll
{
    public partial class PlacaIzracunForm : Form
    {
        public PlacaIzracunForm()
        {
            InitializeComponent();
            FillComboBoxZaposlenik();
            FillJoppdCombo();
        }

        public PlacaIzracunForm(string oib)
        {
            InitializeComponent();
            FillComboBoxZaposlenik();
            int index = comboBoxZaposlenik.FindString(oib);
            comboBoxZaposlenik.SelectedIndex = index;
            InitPrivateMembers();
        }

        private void InitPrivateMembers()
        {
            string selected = this.comboBoxZaposlenik.GetItemText(this.comboBoxZaposlenik.SelectedItem);
            string oib = selected.Split(' ')[0];
            _zaposlenik = _zaposlenik.GetZaposlenikByOib(oib);
            if (_placa.GetPlacaByOib(_zaposlenik.Oib).Oib != "0")
                PopuniKontrole(_placa);
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

        private void FillJoppdCombo()
        {
            DbDataGet data = new DbDataGet();
            //TODO: shorten this and simplify
            DataTable dt = data.GetTable(new Joppd(), $"Skupina='Stjecatelj';");
            dt.Columns.Add(
                "Sifra i opis",
                typeof(string),
                "Sifra + '   ' + Opis");
            comboBoxStjecatelj.DataSource = dt;
            comboBoxStjecatelj.DisplayMember = "Sifra i Opis";

            dt = data.GetTable(new Joppd(), $"Skupina='Primici';");
            dt.Columns.Add(
                "Sifra i opis",
                typeof(string),
                "Sifra + '   ' + Opis");
            comboBoxPrimitak.DataSource = dt;
            comboBoxPrimitak.DisplayMember = "Sifra i opis";

            dt = data.GetTable(new Joppd(), $"Skupina='Beneficirani';");
            dt.Columns.Add(
                "Sifra i opis",
                typeof(string),
                "Sifra + '   ' + Opis");
            comboBoxDodatniMio.DataSource = dt;
            comboBoxDodatniMio.DisplayMember = "Sifra i opis";

            dt = data.GetTable(new Joppd(), $"Skupina='Invaliditet';");
            dt.Columns.Add(
                "Sifra i opis",
                typeof(string),
                "Sifra + '   ' + Opis");
            comboBoxInvaliditet.DataSource = dt;
            comboBoxInvaliditet.DisplayMember = "Sifra i opis";

            dt = data.GetTable(new Joppd(), $"Skupina='Mjesec';");
            dt.Columns.Add(
                "Sifra i opis",
                typeof(string),
                "Sifra + '   ' + Opis");
            comboBoxMjesecPrviZadnji.DataSource = dt;
            comboBoxMjesecPrviZadnji.DisplayMember = "Sifra i opis";

            dt = data.GetTable(new Joppd(), $"Skupina='Vrijeme';");
            dt.Columns.Add(
                "Sifra i opis",
                typeof(string),
                "Sifra + '   ' + Opis");
            comboBoxRadnoVrijeme.DataSource = dt;
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

        private void ButtonIzracunaj_Click(object sender, EventArgs e)
        {
            if (new FloatValidator().Check(textBoxBruto.Text))
            {
                if (comboBoxZaposlenik.SelectedItem != null)
                {
                    float prirez = float.Parse(new DbDataGet().GetTable(new Grad(), $"Naziv='{_zaposlenik.Grad}';").Rows[0]["Prirez"].ToString()) / 100.0f;
                    float iznosBruto = float.Parse(textBoxBruto.Text);
                    labelPrirezStopa.Text = (prirez*100).ToString() + '%';
                    _placa.Izracun(iznosBruto, prirez, _zaposlenik.Olaksica, checkBoxSamoMio1.Checked);
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

        private void ComboBoxZaposlenik_SelectionChangeCommitted(object sender, EventArgs e)
        {
            InitPrivateMembers();
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

        private void PopuniKontrole(Placa placa)
        {
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

        private void DodaciNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            PopuniKontrole(_placa);
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

        private Placa _placa = new Placa();
        private Zaposlenik _zaposlenik = new Zaposlenik();
    }
}
