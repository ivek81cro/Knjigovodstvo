using Knjigovodstvo.Code.Validators;
using Knjigovodstvo.Helpers;
using Knjigovodstvo.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace Knjigovodstvo.Gui
{
    public partial class KomitentNew : Form
    {
        public KomitentNew()
        {
            InitializeComponent();
            InitialFormLoad();
        }

        private void InitialFormLoad()
        {
            DataTable dt = new DbDataGet().GetTable(new Komitent());
            if (dt.Rows.Count != 0)
                EditKomitent(new Komitent
                {
                    Id = int.Parse(dt.Rows[0][0].ToString()),
                    Oib = dt.Rows[0][1].ToString(),
                    Naziv = dt.Rows[0][2].ToString(),
                    Adresa = dt.Rows[0][3].ToString(),
                    Posta = dt.Rows[0][4].ToString(),
                    Grad = dt.Rows[0][5].ToString(),
                    Telefon = dt.Rows[0][6].ToString(),
                    Fax = dt.Rows[0][7].ToString(),
                    Mail = dt.Rows[0][8].ToString(),
                    Iban = dt.Rows[0][9].ToString(),
                    Vrsta_djelatnosti = dt.Rows[0][10].ToString(),
                    Sifra_djelatnosti = dt.Rows[0][11].ToString(),
                    Naziv_djelatnosti = dt.Rows[0][12].ToString(),
                    Mbo = dt.Rows[0][13].ToString()
                });
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            labelMessage.Text = "";

            Komitent komitent = new Komitent
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
                Naziv_djelatnosti = textBoxTypeName.Text,
                Sifra_djelatnosti = textBoxCode.Text,
                Vrsta_djelatnosti = textBoxType.Text

            };

            FormError validateResult = komitent.ValidateData();
            if (validateResult == FormError.None)
            {
                if (!_editMode && komitent.InsertNew())
                {
                    MessageBox.Show("Unos uspješan.", "Novi partner unešen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (_editMode && komitent.UpdateData(_id))
                {
                    MessageBox.Show("Izmjena uspješna.", "Izmjena podataka partnera", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public void EditKomitent(Komitent komitent)
        {
            _id = komitent.Id;
            textBoxOib.Text = komitent.Oib;
            textBoxName.Text = komitent.Naziv;
            textBoxStreet.Text = komitent.Adresa;
            textBoxPost.Text = komitent.Posta;
            textBoxCity.Text = komitent.Grad;
            textBoxPhone.Text = komitent.Telefon;
            textBoxFax.Text = komitent.Fax;
            textBoxEmail.Text = komitent.Mail;
            textBoxIban.Text = komitent.Iban;
            textBoxMbo.Text = komitent.Mbo;
            textBoxTypeName.Text = komitent.Naziv_djelatnosti;
            textBoxType.Text = komitent.Vrsta_djelatnosti;
            textBoxCode.Text = komitent.Sifra_djelatnosti;

            _editMode = true;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSelectCity_Click(object sender, EventArgs e)
        {
            CityNew city = new CityNew();
            Opcina c = city.ShowDialogValue();

            if (c != null && c.ValidateData() == FormError.None)
            {
                textBoxCity.Text = c.Naziv;
                textBoxPost.Text = c.Posta;
            }
        }

        bool _editMode = false;
        int _id = 0;
    }
}
