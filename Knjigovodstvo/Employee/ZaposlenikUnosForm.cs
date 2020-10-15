using System;
using System.Windows.Forms;

namespace Knjigovodstvo.Employee
{
    public partial class ZaposlenikUnosForm : Form
    {
        public ZaposlenikUnosForm()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Zaposlenik zaposlenik = new Zaposlenik {
                Oib = textBoxOib.Text,
                Ime = textBoxIme.Text,
                Prezime = textBoxPrezime.Text,
                DatumRodenja = dateTimePickerDatumRodenja.Value.ToString("yyyyy-MM-dd"),
                Grad=textBoxGrad.Text,
                Drzava=textBoxDrzava.Text,
                Telefon=textBoxTelefon.Text,
                StručnaSprema=textBoxStrucnaSprema.Text,
                DatumDolaska=dateTimePickerDatumDolaska.Value.ToString("yyyyy-MM-dd"),
                DatumOdlaska=dateTimePickerDatumOdlaska.Value.ToString("yyyyy-MM-dd")
            };

            zaposlenik.ValidateData();
        }
    }
}
