using Knjigovodstvo.Code;
using Knjigovodstvo.Code.Validators;
using Knjigovodstvo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
            //TODO Validate form data
            Partner partner = new Partner
            {
                Oib = textBoxOib.Text,
                Naziv = textBoxName.Text,
                Adresa = textBoxStreet.Text,
                Posta = textBoxPost.Text,
                Grad = textBoxCity.Text,
                Telefon = textBoxPhone.Text,
                Fax = textBoxFax.Text,
                Mail = textBoxEmail.Text,
                Iban = textBoxIban.Text,
                Mbo = textBoxMbo.Text,
                Kupac = checkBoxBuyer.Checked,
                Dobavljac = checkBoxSeller.Checked
            };

            if (partner.ValidateData())
            {
                partner.InsertNew();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSelectCity_Click(object sender, EventArgs e)
        {
            CityNew city = new CityNew();
            City c = city.ShowDialogValue();

            if (c != null && c.ValidateData())
            {
                textBoxCity.Text = c.Name;
                textBoxPost.Text = c.Post;
            }
        }
    }
}
