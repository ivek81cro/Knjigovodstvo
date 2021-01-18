using Knjigovodstvo.Validators;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace Knjigovodstvo.Books.Inventory
{
    public partial class OsnovnoSredstvoDodajForm : Form
    {
        public OsnovnoSredstvoDodajForm()
        {
            InitializeComponent();
        }

        private bool ValidateDecimalData()
        {
            return _decimalValidate.Check(textBoxKolicina.Text) &&
                _decimalValidate.Check(textBoxNabavnaVrijednost.Text) &&
                _decimalValidate.Check(textBoxVijekTrajanja.Text) &&
                _decimalValidate.Check(textBoxStopaOtpisa.Text);
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

        private void ButtonSpremi_Click(object sender, EventArgs e)
        {
            if (ValidateDecimalData())
            {
                _osnovnoSredstvo.Naziv = textBoxNaziv.Text;
                _osnovnoSredstvo.Datum_nabave = dateTimePickerDatumNabave.Value.ToString("yyyy-MM-dd");
                _osnovnoSredstvo.Datum_uporabe = dateTimePickerDatumUporabe.Value.ToString("yyyy-MM-dd");
                _osnovnoSredstvo.Dobavljac = textBoxDobavljac.Text;
                _osnovnoSredstvo.Dokument = textBoxDokument.Text;
                _osnovnoSredstvo.Kolicina = decimal.Parse(textBoxKolicina.Text);
                _osnovnoSredstvo.Nabavna_vrijednost = decimal.Parse(textBoxNabavnaVrijednost.Text);
                _osnovnoSredstvo.Vijek_trajanja = decimal.Parse(textBoxVijekTrajanja.Text);
                _osnovnoSredstvo.Stopa_otpisa = decimal.Parse(textBoxStopaOtpisa.Text);
                _osnovnoSredstvo.Sadasnja_vrijednost = decimal.Parse(textBoxNabavnaVrijednost.Text);

                if (!_osnovnoSredstvo.SaveData())
                {
                    MessageBox.Show("Greška u spremanju podataka", "Upozorenje");
                }
            }
            else
            {
                MessageBox.Show("Provjerite format podataka","Upozorenje");
            }
        }

        private readonly OsnovnoSredstvo _osnovnoSredstvo = new OsnovnoSredstvo();
        private readonly DecimalValidate _decimalValidate = new DecimalValidate();
    }
}
