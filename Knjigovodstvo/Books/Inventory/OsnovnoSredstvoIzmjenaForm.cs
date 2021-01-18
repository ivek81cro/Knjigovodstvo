using System;
using System.Windows.Forms;

namespace Knjigovodstvo.Books.Inventory
{
    public partial class OsnovnoSredstvoIzmjenaForm : Form
    {
        public OsnovnoSredstvoIzmjenaForm()
        {
            InitializeComponent();
        }

        public void FillControls()
        {
            textBoxNaziv.Text = OsnovnoSredstvo.Naziv;
            textBoxDobavljac.Text = OsnovnoSredstvo.Dobavljac;
            dateTimePickerDatumNabave.Value = DateTime.Parse(OsnovnoSredstvo.Datum_nabave);
            dateTimePickerDatumUporabe.Value = DateTime.Parse(OsnovnoSredstvo.Datum_uporabe);
            textBoxDokument.Text = OsnovnoSredstvo.Dokument;
            textBoxKolicina.Text = OsnovnoSredstvo.Kolicina.ToString();
            textBoxNabavnaVrijednost.Text = OsnovnoSredstvo.Nabavna_vrijednost.ToString();
            textBoxTrenutnaVrijednost.Text = OsnovnoSredstvo.Sadasnja_vrijednost.ToString();
            textBoxOtpisanaVrijednost.Text = OsnovnoSredstvo.Otpisano.ToString();
            textBoxVijekTrajanja.Text = OsnovnoSredstvo.Vijek_trajanja.ToString();
            textBoxStopaOtpisa.Text = OsnovnoSredstvo.Stopa_otpisa.ToString();
        }

        private void SaveValues()
        {
            OsnovnoSredstvo.Naziv = textBoxNaziv.Text;
            OsnovnoSredstvo.Datum_nabave = dateTimePickerDatumNabave.Value.ToString("yyyy-MM-dd");
            OsnovnoSredstvo.Datum_uporabe = dateTimePickerDatumUporabe.Value.ToString("yyyy-MM-dd");
            OsnovnoSredstvo.Dobavljac = textBoxDobavljac.Text;
            OsnovnoSredstvo.Dokument = textBoxDokument.Text;
            OsnovnoSredstvo.Kolicina = decimal.Parse(textBoxKolicina.Text);
            OsnovnoSredstvo.Nabavna_vrijednost = decimal.Parse(textBoxNabavnaVrijednost.Text);
            OsnovnoSredstvo.Vijek_trajanja = decimal.Parse(textBoxVijekTrajanja.Text);
            OsnovnoSredstvo.Stopa_otpisa = decimal.Parse(textBoxStopaOtpisa.Text);
            OsnovnoSredstvo.Sadasnja_vrijednost = decimal.Parse(textBoxTrenutnaVrijednost.Text);
            OsnovnoSredstvo.Otpisano = decimal.Parse(textBoxOtpisanaVrijednost.Text);
        }

        private void ButtonIzmjeni_Click(object sender, EventArgs e)
        {
            SaveValues();
            if(OsnovnoSredstvo.UpdateData())
            {
                MessageBox.Show("Izmjena uspješna","Informacija");
            }
        }

        public OsnovnoSredstvo OsnovnoSredstvo { get; set; } = new OsnovnoSredstvo();
    }
}
