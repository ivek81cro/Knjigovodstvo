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

        public PartnerUnosForm(Partneri partner)
        {
            InitializeComponent();
            _partner = partner;

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

        private void SetMessageLabel(FormError errorType)
        {
            labelMessage.Text = new ProcessFormErrors().FormErrorMessage(errorType);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            labelMessage.Text = "";

            _partner.OpciPodaci.Oib = textBoxOib.Text;
            _partner.OpciPodaci.Naziv = textBoxName.Text;
            _partner.Adresa.Ulica = textBoxStreet.Text;
            _partner.Adresa.Broj = textBoxUlicaBroj.Text;
            _partner.Adresa.Grad.Posta = textBoxPost.Text;
            _partner.Adresa.Grad.Mjesto = textBoxCity.Text;
            _partner.Kontakt.Telefon = textBoxPhone.Text;
            _partner.Kontakt.Fax = textBoxFax.Text;
            _partner.Kontakt.Email = textBoxEmail.Text;
            _partner.OpciPodaci.Iban = textBoxIban.Text;
            _partner.OpciPodaci.Mbo = textBoxMbo.Text;
            _partner.KontoK = checkBoxBuyer.Checked ? "12" : "";
            _partner.KontoD = checkBoxSupplier.Checked ? "22" : "";

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

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSelectCity_Click(object sender, EventArgs e)
        {
            GradoviTableForm form = new GradoviTableForm();
            Grad grad = form.OdabirGrada();

            if (grad != null && grad.ValidateData() == FormError.None)
            {
                textBoxCity.Text = grad.Mjesto;
                textBoxPost.Text = grad.Posta;
            }
        }
        private readonly Partneri _partner = new Partneri();
    }
}
