using Knjigovodstvo.City;
using Knjigovodstvo.Code.Validators;
using Knjigovodstvo.Interface;
using System;
using System.Windows.Forms;

namespace Knjigovodstvo.Partners
{
    public partial class PartnerUnosForm : Form
    {
        public PartnerUnosForm()
        {
            InitializeComponent();
        }

        public void InitPartner(Partneri partner)
        {
            _partner = partner;
            FillControls();
        }

        private void FillControls()
        {
            textBoxOib.Text = _partner.OpciPodaci.Oib;
            textBoxName.Text = _partner.OpciPodaci.Naziv;
            textBoxStreet.Text = _partner.Adresa.Ulica;
            textBoxUlicaBroj.Text = _partner.Adresa.Broj;
            textBoxPost.Text = _partner.Adresa.Grad.Posta;
            textBoxCity.Text = _partner.Adresa.Grad.Mjesto;
            textBoxPhone.Text = _partner.Kontakt.Telefon;
            textBoxFax.Text = _partner.Kontakt.Fax;
            textBoxEmail.Text = _partner.Kontakt.Email;
            textBoxIban.Text = _partner.OpciPodaci.Iban;
            textBoxMbo.Text = _partner.OpciPodaci.Mbo;
            checkBoxBuyer.Checked = _partner.KontoK.StartsWith("12");
            checkBoxSupplier.Checked = _partner.KontoD.StartsWith("22");
        }
        private void CreateNewPartner()
        {
            _partner = new Partneri();
            _partner.OpciPodaci.Oib = textBoxOib.Text;
            _partner.OpciPodaci.Naziv = textBoxName.Text;
            _partner.OpciPodaci.Iban = textBoxIban.Text;
            _partner.OpciPodaci.Mbo = textBoxMbo.Text;
            _partner.Adresa.Ulica = textBoxStreet.Text;
            _partner.Adresa.Broj = textBoxUlicaBroj.Text;
            _partner.Adresa.Grad.Mjesto = textBoxCity.Text;
            _partner.Adresa.Grad.Posta = textBoxPost.Text;
            _partner.Kontakt.Telefon = textBoxPhone.Text;
            _partner.Kontakt.Fax = textBoxFax.Text;
            _partner.Kontakt.Email = textBoxEmail.Text;
            _partner.KontoD = checkBoxSupplier.Checked ? "22" : "";
            _partner.KontoK = checkBoxBuyer.Checked ? "12" : "";
        }

        private void SetMessageLabel(FormError errorType)
        {
            labelMessage.Text = new ProcessFormErrors().FormErrorMessage(errorType);
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonSelectCity_Click(object sender, EventArgs e)
        {
            using (GradoviTableForm form = new GradoviTableForm())
            {
                form.Odabir = true;
                form.ShowDialog();
                if (form.Grad.Id != 0 && form.Grad.ValidateData() == FormError.None)
                {
                    textBoxCity.Text = form.Grad.Mjesto;
                    textBoxPost.Text = form.Grad.Posta;
                }
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            labelMessage.Text = "";
            CreateNewPartner();
            _partner.ExistsInDb();

            FormError validateResult = _partner.ValidateData();
            if ( validateResult == FormError.None)
            {
                if (_partner.OpciPodaci.Id == 0 && _partner.InsertNew())
                {
                    MessageBox.Show("Unos uspješan.", "Novi partner unešen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }

                else if (_partner.UpdateData())
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

        private Partneri _partner = new Partneri();
    }
}
