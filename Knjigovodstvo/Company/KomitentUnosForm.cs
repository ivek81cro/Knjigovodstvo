using Knjigovodstvo.City;
using Knjigovodstvo.Code.Validators;
using Knjigovodstvo.Database;
using Knjigovodstvo.Interface;
using System;
using System.Data;
using System.Windows.Forms;

namespace Knjigovodstvo.Gui
{
    public partial class KomitentUnosForm : Form
    {
        public KomitentUnosForm()
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
                    Id = int.Parse(dt.Rows[0]["Id"].ToString()),
                    Oib = dt.Rows[0]["Oib"].ToString(),
                    Naziv = dt.Rows[0]["Naziv"].ToString(),
                    Adresa = dt.Rows[0]["Adresa"].ToString(),
                    Posta = dt.Rows[0]["Posta"].ToString(),
                    Grad = dt.Rows[0]["Grad"].ToString(),
                    Telefon = dt.Rows[0]["Telefon"].ToString(),
                    Fax = dt.Rows[0]["Fax"].ToString(),
                    Mail = dt.Rows[0]["Mail"].ToString(),
                    Iban = dt.Rows[0]["Iban"].ToString(),
                    Vrsta_djelatnosti = dt.Rows[0]["Vrsta_djelatnosti"].ToString(),
                    Sifra_djelatnosti = dt.Rows[0]["Sifra_djelatnosti"].ToString(),
                    Naziv_djelatnosti = dt.Rows[0]["Naziv_djelatnosti"].ToString(),
                    Mbo = dt.Rows[0]["Mbo"].ToString()
                });
        }

        private void ButtonSave_Click(object sender, EventArgs e)
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

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonSelectCity_Click(object sender, EventArgs e)
        {
            CityTableForm form = new CityTableForm();
            Grad grad = form.ShowDialogValue(1);

            if (grad != null && grad.ValidateData() == FormError.None)
            {
                textBoxCity.Text = grad.Naziv;
                textBoxPost.Text = grad.Posta;
            }
        }

        bool _editMode = false;
        int _id = 0;
    }
}
