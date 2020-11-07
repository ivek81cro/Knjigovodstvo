using Knjigovodstvo.Code.Validators;
using Knjigovodstvo.Interface;
using Knjigovodstvo.Validators;
using System;
using System.Windows.Forms;

namespace Knjigovodstvo.Settings
{
    public partial class PostavkePromjenaForm : Form
    {
        public PostavkePromjenaForm(Postavke postavke)
        {
            _postavke = postavke;
            InitializeComponent();
            labelMessage.Text = "";
            EditPostavka();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (!new FloatValidator().Check(textBoxVrijednost.Text))
            {
                MessageBox.Show("Vrijednost nije ispravno unešena.", "Izmjena vrijednosti postavke", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                decimal vrijednost = decimal.Parse(textBoxVrijednost.Text);
                if (vrijednost > 1)
                    vrijednost /= 100.0m;

                _postavke.Vrijednost = vrijednost;

                FormError validateResult = _postavke.ValidateData();
                if (_postavke.ValidateData() == FormError.None)
                {
                    if (_postavke.UpdateData())
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

        internal void EditPostavka()
        {
            textBoxId.Text = _postavke.Id.ToString();
            textBoxNaziv.Text = _postavke.Naziv;
            textBoxVrsta.Text = _postavke.Vrsta;
            textBoxVrijednost.Text = _postavke.Vrijednost.ToString();

            ShowDialog();
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
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

        private Postavke _postavke = new Postavke();
    }
}
