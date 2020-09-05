using Knjigovodstvo.Code.Validators;
using Knjigovodstvo.Models;
using System;
using System.Windows.Forms;

namespace Knjigovodstvo.Gui
{
    public partial class PartnersNew : Form
    {
        public PartnersNew()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            labelMessage.Text = "";

            Partneri partner = new Partneri
            {
                Oib = textBoxOib.Text,
                Naziv = textBoxName.Text,
                Adresa = textBoxStreet.Text,
                Posta = textBoxPost.Text,
                Grad = textBoxCity.Text,
                Telefon = textBoxPhone.Text,
                Fax = textBoxFax.Text,
                Email = textBoxEmail.Text,
                Iban = textBoxIban.Text,
                Mbo = textBoxMbo.Text,
                Kupac = checkBoxBuyer.Checked ? 'k' : 'n',
                Dobavljac = checkBoxSeller.Checked ? 'd' : 'n'
            };

            FormError validateResult = partner.ValidateData();
            if ( validateResult == FormError.None)
            {
                if (!_editMode && partner.InsertNew())
                {
                    MessageBox.Show("Unos uspješan.", "Novi partner unešen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }

                if (_editMode && partner.EditPartner(_id))
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

        private void SetMessageLabel(FormError errorType)
        {
            labelMessage.Text = new ProcessFormErrors().FormErrorMessage(errorType);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSelectCity_Click(object sender, EventArgs e)
        {
            CityNew city = new CityNew();
            Opcina c = city.ShowDialogValue();

            if (c != null && c.ValidateData() == FormError.None)
            {
                textBoxCity.Text = c.Naziv;
                textBoxPost.Text = c.Posta;
            }
        }

        /// <summary>
        /// Custom show dialog implementation, table row to object for sending to dialog.
        /// </summary>
        /// <param name="partner">Selected row from datatagrid</param>
        public void EditPartner(Partneri partner)
        {
            _id = partner.Id;
            textBoxOib.Text = partner.Oib;
            textBoxName.Text = partner.Naziv;
            textBoxStreet.Text = partner.Adresa;
            textBoxPost.Text = partner.Posta;
            textBoxCity.Text = partner.Grad;
            textBoxPhone.Text = partner.Telefon;
            textBoxFax.Text = partner.Fax;
            textBoxEmail.Text = partner.Email;
            textBoxIban.Text = partner.Iban;
            textBoxMbo.Text = partner.Mbo;
            if (partner.Kupac == 'k')
                checkBoxBuyer.Checked = true;
            if (partner.Dobavljac == 'd')
                checkBoxSeller.Checked = true;
            
            _editMode = true;

            ShowDialog();
        }

        bool _editMode = false;
        int _id = 0;
    }
}
