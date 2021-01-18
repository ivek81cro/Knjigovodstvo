using Knjigovodstvo.Database;
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

        private void ButtonIzmjeni_Click(object sender, EventArgs e)
        {
            if(new DbDataUpdate().UpdateData(OsnovnoSredstvo))
            {
                MessageBox.Show("Izmjena uspješma","Informacija");
            }
        }

        public OsnovnoSredstvo OsnovnoSredstvo { get; set; } = new OsnovnoSredstvo();
    }
}
