using Knjigovodstvo.Code.Validators;
using Knjigovodstvo.Models;
using Knjigovodstvo.Validators;
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
            if (!new FloatValidator().Check(textBoxVrijednost.Text))
            {
                MessageBox.Show("Vrijednost nije ispravno unešena.", "Izmjena vrijednosti postavke", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                decimal vrijednost = decimal.Parse(textBoxVrijednost.Text);
                if (vrijednost > 1)
                    vrijednost = vrijednost / 100.0m;

                Postavke postavka = new Postavke
                {                    
                    Id = _id,
                    Naziv = textBoxNaziv.Text,
                    Vrsta = textBoxVrsta.Text,
                    Vrijednost = vrijednost
                };

                FormError validateResult = postavka.ValidateData();
                if (postavka.ValidateData() == FormError.None)
                {
                    if (postavka.UpdateData(_id))
                    {
                        MessageBox.Show("Izmjena uspješna.", "Izmjena vrijednosti postavke", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else
                    {
                        SetMessageLabel(validateResult);
                    }
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

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        int _id = 0;
    }
}
