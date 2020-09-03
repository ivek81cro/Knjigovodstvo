﻿using Knjigovodstvo.Models;
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

        public void EditPartner(Partner partner)
        {
            _id = partner.Id;
            textBoxOib.Text = partner.Oib;
            textBoxName.Text = partner.Naziv;
            textBoxStreet.Text = partner.Adresa;
            textBoxPost.Text = partner.Posta;
            textBoxCity.Text = partner.Grad;
            textBoxPhone.Text = partner.Telefon;
            textBoxFax.Text = partner.Fax;
            textBoxEmail.Text = partner.Mail;
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
