using Knjigovodstvo.Code.Validators;
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Zaposlenik zaposlenik = new Zaposlenik {
                Oib = textBoxOib.Text,
                Ime = textBoxIme.Text,
                Prezime = textBoxPrezime.Text,
                DatumRodenja = dateTimePickerDatumRodenja.Value.ToString("yyyy-MM-dd"),
                Adresa = textBoxAdresa.Text,
                Grad=textBoxGrad.Text,
                Drzava=textBoxDrzava.Text,
                Telefon=textBoxTelefon.Text,
                StručnaSprema=textBoxStrucnaSprema.Text,
                Olaksica = float.Parse(textBoxOlaksica.Text),
                DatumDolaska=dateTimePickerDatumDolaska.Value.ToString("yyyy-MM-dd"),
                DatumOdlaska=dateTimePickerDatumOdlaska.Value.ToString("yyyy-MM-dd")
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

        bool _editMode = false;
        int _id = 0;
    }
}
