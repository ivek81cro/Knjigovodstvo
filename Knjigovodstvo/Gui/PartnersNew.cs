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
            PartnerDataValidate valiateData = new PartnerDataValidate();

            if (valiateData.ValidateData(partner))
            {
                PartnerInsert partnerInsert = new PartnerInsert(partner);
                bool success = partnerInsert.Insert();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
