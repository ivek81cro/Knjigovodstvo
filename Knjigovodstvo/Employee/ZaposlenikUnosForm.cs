﻿using Knjigovodstvo.City;
using Knjigovodstvo.Code.Validators;
using Knjigovodstvo.Global;
using Knjigovodstvo.Models;
using System;
using System.Windows.Forms;

namespace Knjigovodstvo.Employee
{
    public partial class ZaposlenikUnosForm : Form
    {
        public ZaposlenikUnosForm()
        {
            InitializeComponent();
            labelMessage.Text = "";
        }

        private void SetMessageLabel(FormError errorType)
        {
            labelMessage.Text = new ProcessFormErrors().FormErrorMessage(errorType);
        }

        private void RuttonSave_Click(object sender, EventArgs e)
        {
            string odlazak = "";
            if (dateTimePickerDatumOdlaska.Visible == true)
                odlazak = dateTimePickerDatumOdlaska.Value.ToString("yyyy-MM-dd");

            Zaposlenik zaposlenik = new Zaposlenik {
                Oib = textBoxOib.Text,
                Ime = textBoxIme.Text,
                Prezime = textBoxPrezime.Text,
                Datum_Rodenja = dateTimePickerDatumRodenja.Value.ToString("yyyy-MM-dd"),
                Adresa = new Adresa()
                {
                    Ulica = textBoxUlica.Text,
                    Broj = textBoxUlicaBroj.Text,
                    Grad = new Grad()
                    {
                        Mjesto = textBoxGrad.Text,
                        Drzava = textBoxDrzava.Text,
                    }
                },
                Kontakt = new Kontakt()
                {
                    Telefon = textBoxTelefon.Text,
                },
                Stručna_Sprema = textBoxStrucnaSprema.Text,
                Olaksica = decimal.Parse(textBoxOlaksica.Text),
                Datum_Dolaska = dateTimePickerDatumDolaska.Value.ToString("yyyy-MM-dd"),
                Datum_Odlaska = odlazak
            };

            FormError validateResult = zaposlenik.ValidateData();
            if (validateResult == FormError.None)
            {
                if (!_editMode && zaposlenik.InsertNew())
                {
                    MessageBox.Show("Unos uspješan.", "Novi partner unešen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }

                if (_editMode && zaposlenik.UpdateData(_id))
                {
                    MessageBox.Show("Izmjena uspješna.", "Izmjena podataka partnera", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            else
            {
                SetMessageLabel(validateResult);
            }
        }

        public void EditZaposlenik(Zaposlenik zaposlenik)
        {
            _id = zaposlenik.Id;
            textBoxOib.Text = zaposlenik.Oib;
            textBoxIme.Text = zaposlenik.Ime;
            textBoxPrezime.Text = zaposlenik.Prezime;
            dateTimePickerDatumRodenja.Text = zaposlenik.Datum_Rodenja;
            textBoxUlica.Text = zaposlenik.Adresa.Ulica;
            textBoxUlicaBroj.Text = zaposlenik.Adresa.Ulica;
            textBoxGrad.Text = zaposlenik.Adresa.Grad.Mjesto;
            textBoxDrzava.Text = zaposlenik.Adresa.Grad.Drzava;
            textBoxTelefon.Text = zaposlenik.Kontakt.Telefon;
            textBoxStrucnaSprema.Text = zaposlenik.Stručna_Sprema;
            textBoxOlaksica.Text = zaposlenik.Olaksica.ToString();
            dateTimePickerDatumDolaska.Text = zaposlenik.Datum_Dolaska;
            if (zaposlenik.Datum_Odlaska == "")
            {
                dateTimePickerDatumOdlaska.Visible = false;
                labelOdlazak.Visible = false;
            }
            else
            {
                dateTimePickerDatumOdlaska.Visible = true;
                labelOdlazak.Visible = true;
                dateTimePickerDatumOdlaska.Text = zaposlenik.Datum_Odlaska;
            }

            _editMode = true;

            ShowDialog();
        }

        private void ButtonOdaberiGrad_Click(object sender, EventArgs e)
        {
            GradoviTableForm form = new GradoviTableForm();
            Grad grad = form.ShowDialogValue(1);

            if (grad != null && grad.ValidateData() == FormError.None)
                textBoxGrad.Text = grad.Mjesto;
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CheckBoxOdlazak_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxOdlazak.Checked)
            {
                dateTimePickerDatumOdlaska.Visible = true;
                labelOdlazak.Visible = true;
            }
            else
            {
                dateTimePickerDatumOdlaska.Visible = false;
                labelOdlazak.Visible = false;
            }
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

        bool _editMode = false;
        int _id = 0;
    }
}
