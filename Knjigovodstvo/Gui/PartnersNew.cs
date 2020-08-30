using Knjigovodstvo.Code;
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
            int oib = Int32.Parse(textBoxOib.Text);
            string iban = "";//TODO IBAN validator
            Partner partner = new Partner
            {
                Oib = oib,
                Naziv = textBoxName.Text,
                Adresa = textBoxStreet.Text,
                Posta = Int32.Parse(textBoxPost.Text),
                Grad = textBoxCity.Text,
                Telefon = textBoxPhone.Text,
                Fax = textBoxFax.Text,
                Mail = textBoxEmail.Text,
                Iban = textBoxIban.Text,
                Mbo = Int32.Parse(textBoxMbo.Text),
                Kupac = checkBoxBuyer.Checked,
                Dobavljac = checkBoxSeller.Checked
            };
            PartnerInsert partnerInsert = new PartnerInsert(partner);
            bool success = partnerInsert.Insert();
        }

        private void TextBoxOib_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
