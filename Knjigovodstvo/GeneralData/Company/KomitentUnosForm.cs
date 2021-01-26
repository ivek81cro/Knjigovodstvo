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
            DataTable dt = new DbDataGet().GetTable(_komitent);
            if (dt.Rows.Count != 0)
            {
                _komitent.OpciPodaci.Id = int.Parse(dt.Rows[0]["Id"].ToString());
                textBoxOib.Text = _komitent.OpciPodaci.Oib = dt.Rows[0]["Oib"].ToString();
                textBoxName.Text =  _komitent.OpciPodaci.Naziv = dt.Rows[0]["Naziv"].ToString();
                textBoxStreet.Text = _komitent.Adresa.Ulica = dt.Rows[0]["Ulica"].ToString();
                textBoxUlicaBroj.Text = _komitent.Adresa.Broj = dt.Rows[0]["Broj"].ToString();
                textBoxPost.Text = _komitent.Adresa.Grad.Posta = dt.Rows[0]["Posta"].ToString();
                textBoxCity.Text = _komitent.Adresa.Grad.Mjesto = dt.Rows[0]["Mjesto"].ToString();
                textBoxPhone.Text =  _komitent.Kontakt.Telefon = dt.Rows[0]["Telefon"].ToString();
                textBoxFax.Text = _komitent.Kontakt.Fax = dt.Rows[0]["Fax"].ToString();
                textBoxEmail.Text =  _komitent.Kontakt.Email = dt.Rows[0]["Email"].ToString();
                textBoxIban.Text =  _komitent.OpciPodaci.Iban = dt.Rows[0]["Iban"].ToString();
                textBoxType.Text =  _komitent.Vrsta_djelatnosti = dt.Rows[0]["Vrsta_djelatnosti"].ToString();
                textBoxCode.Text =  _komitent.Sifra_djelatnosti = dt.Rows[0]["Sifra_djelatnosti"].ToString();
                textBoxTypeName.Text = _komitent.Naziv_djelatnosti = dt.Rows[0]["Naziv_djelatnosti"].ToString();
                textBoxMbo.Text =  _komitent.OpciPodaci.Mbo = dt.Rows[0]["Mbo"].ToString();
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            labelMessage.Text = "";

            _komitent.OpciPodaci.Oib = textBoxOib.Text;
            _komitent.OpciPodaci.Naziv = textBoxName.Text;
            _komitent.Adresa.Ulica = textBoxStreet.Text;
            _komitent.Adresa.Broj = textBoxUlicaBroj.Text;
            _komitent.Adresa.Grad.Posta = textBoxPost.Text;
            _komitent.Adresa.Grad.Mjesto = textBoxCity.Text;
            _komitent.Kontakt.Telefon = textBoxPhone.Text;
            _komitent.Kontakt.Fax = textBoxFax.Text;
            _komitent.Kontakt.Email = textBoxEmail.Text;
            _komitent.OpciPodaci.Iban = textBoxIban.Text;
            _komitent.Vrsta_djelatnosti = textBoxType.Text;
            _komitent.Sifra_djelatnosti = textBoxCode.Text;
            _komitent.Naziv_djelatnosti = textBoxTypeName.Text;
            _komitent.OpciPodaci.Mbo = textBoxMbo.Text;

            FormError validateResult = _komitent.ValidateData();
            if (validateResult == FormError.None)
            {
                if (_komitent.OpciPodaci.Id == 0 && _komitent.InsertNew())
                {
                    MessageBox.Show("Unos uspješan.", "Novi partner unešen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else if (_komitent.UpdateData())
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

        private Komitent _komitent = new Komitent();
    }
}
