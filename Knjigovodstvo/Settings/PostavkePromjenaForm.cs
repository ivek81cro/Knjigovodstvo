using Knjigovodstvo.Code.Validators;
using Knjigovodstvo.Models;
using System;
using System.Windows.Forms;

namespace Knjigovodstvo.Settings
{
    public partial class PostavkePromjenaForm : Form
    {
        public PostavkePromjenaForm()
        {
            InitializeComponent();
            labelMessage.Text = "";
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Postavke postavka = new Postavke
            {
                Id = _id,
                Naziv = textBoxNaziv.Text,
                Vrsta = textBoxVrsta.Text,
                Vrijednost = float.Parse(textBoxVrijednost.Text)
            };

            FormError validateResult = postavka.ValidateData();
            if (postavka.ValidateData() == FormError.None)
            {
                if (postavka.UpdateData(_id))
                {
                    MessageBox.Show("Izmjena uspješna.", "Izmjena podataka partnera", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    SetMessageLabel(validateResult);
                }
            }
        }
        private void SetMessageLabel(FormError errorType)
        {
            labelMessage.Text = new ProcessFormErrors().FormErrorMessage(errorType);
        }

        internal void EditPostavka(Postavke postavka)
        {
            _id = postavka.Id;
            textBoxId.Text = _id.ToString();
            textBoxNaziv.Text = postavka.Naziv;
            textBoxVrsta.Text = postavka.Vrsta;
            textBoxVrijednost.Text = postavka.Vrijednost.ToString();

            ShowDialog();
        }

        int _id = 0;
    }
}
