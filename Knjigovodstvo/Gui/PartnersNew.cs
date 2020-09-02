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
                Kupac = checkBoxBuyer.Checked ? 'k' : 'n',
                Dobavljac = checkBoxSeller.Checked ? 'd' : 'n'
            };

            if (partner.ValidateData())
            {
                if (partner.InsertNew())
                {
                    MessageBox.Show("Unos uspješan.", "Novi Partner Unešen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
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
