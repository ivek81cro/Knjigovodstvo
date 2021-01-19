using Knjigovodstvo.City;
using Knjigovodstvo.Code.Validators;
using Knjigovodstvo.Interface;
using Knjigovodstvo.Payroll;
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

        public void EditZaposlenik(Zaposlenik zaposlenik)
        {
            _zaposlenik = zaposlenik;

            textBoxOib.Text = _zaposlenik.Oib;
            textBoxIme.Text = _zaposlenik.Ime;
            textBoxPrezime.Text = _zaposlenik.Prezime;
            dateTimePickerDatumRodenja.Text = _zaposlenik.Datum_Rodenja;
            textBoxUlica.Text = _zaposlenik.Adresa.Ulica;
            textBoxUlicaBroj.Text = _zaposlenik.Adresa.Ulica;
            textBoxGrad.Text = _zaposlenik.Adresa.Grad.Mjesto;
            textBoxDrzava.Text = _zaposlenik.Adresa.Grad.Drzava;
            textBoxTelefon.Text = _zaposlenik.Kontakt.Telefon;
            textBoxStrucnaSprema.Text = _zaposlenik.Stručna_Sprema;
            textBoxOlaksica.Text = _zaposlenik.Olaksica.ToString();
            dateTimePickerDatumDolaska.Text = _zaposlenik.Datum_Dolaska;
            if (_zaposlenik.Datum_Odlaska == "")
            {
                dateTimePickerDatumOdlaska.Visible = false;
                labelOdlazak.Visible = false;
            }
            else
            {
                dateTimePickerDatumOdlaska.Visible = true;
                labelOdlazak.Visible = true;
                dateTimePickerDatumOdlaska.Text = _zaposlenik.Datum_Odlaska;
            }

            ShowDialog();
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

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            string odlazak = "Null";
            if (dateTimePickerDatumOdlaska.Visible == true)
                odlazak = dateTimePickerDatumOdlaska.Value.ToString("yyyy-MM-dd");


            _zaposlenik.Oib = textBoxOib.Text;
            _zaposlenik.Ime = textBoxIme.Text;
            _zaposlenik.Prezime = textBoxPrezime.Text;
            _zaposlenik.Datum_Rodenja = dateTimePickerDatumRodenja.Value.ToString("yyyy-MM-dd");
            _zaposlenik.Adresa.Ulica = textBoxUlica.Text;
            _zaposlenik.Adresa.Broj = textBoxUlicaBroj.Text;
            _zaposlenik.Adresa.Grad.Mjesto = textBoxGrad.Text;
            _zaposlenik.Adresa.Grad.Drzava = textBoxDrzava.Text;
            _zaposlenik.Kontakt.Telefon = textBoxTelefon.Text;
            _zaposlenik.Stručna_Sprema = textBoxStrucnaSprema.Text;
            _zaposlenik.Olaksica = decimal.Parse(textBoxOlaksica.Text);
            _zaposlenik.Datum_Dolaska = dateTimePickerDatumDolaska.Value.ToString("yyyy-MM-dd");
            _zaposlenik.Datum_Odlaska = odlazak;

            FormError validateResult = _zaposlenik.ValidateData();
            if (validateResult == FormError.None)
            {
                if (_zaposlenik.Id == 0 && _zaposlenik.InsertNew())
                {
                    MessageBox.Show("Unos uspješan.", "Novi partner unešen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }

                else if (_zaposlenik.UpdateData())
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

        private void ButtonOdaberiGrad_Click(object sender, EventArgs e)
        {
            GradoviTableForm form = new GradoviTableForm();
            Grad grad = form.OdabirGrada();

            if (grad != null && grad.ValidateData() == FormError.None)
                textBoxGrad.Text = grad.Mjesto;
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        Zaposlenik _zaposlenik = new Zaposlenik();
    }
}
