using Knjigovodstvo.Code.Validators;
using Knjigovodstvo.Interface;
using System;
using System.Data;
using System.Windows.Forms;

namespace Knjigovodstvo.City
{
    public partial class GradEditForm : Form
    {
        public GradEditForm(Grad grad = null)
        {
            InitializeComponent();
            FillComboCounty();
            labelUpozorenja.Text = "";
            if (grad != null)
            {
                _grad = grad;
                FillComboCity();
                EditGrad();
            }
        }

        void FillComboCounty()
        {
            DataTable dt = new Zupanije().GetAllCounty();
            //Assign DataTable as DataSource.
            if (dt.Rows.Count > 0)
            {
                comboBoxZupanija.DataSource = dt;
                comboBoxZupanija.DisplayMember = "Naziv";
                comboBoxZupanija.ValueMember = "Id";
            }
            int index = comboBoxZupanija.FindStringExact(_grad.Zupanija);
            comboBoxZupanija.SelectedIndex = index;
        }

        void FillComboCity()
        {
            DataTable dt = new Grad().GetGradoviByZupanija(comboBoxZupanija.Text);

            //Assign DataTable as DataSource.
            if (dt.Rows.Count > 0)
            {
                comboBoxGrad.DataSource = dt;
                comboBoxGrad.DisplayMember = "Mjesto";
                comboBoxGrad.ValueMember = "Id";
            }
            int index = comboBoxGrad.FindStringExact(_grad.Mjesto);
            comboBoxGrad.SelectedIndex = index;
            FillPrirezSifra();
            FillComboPosta();
        }

        private void ComboBoxCounty_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FillComboCity();
        }

        private void ComboBoxGrad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _grad.GetGradById(int.Parse(comboBoxGrad.SelectedValue.ToString()));
            FillPrirezSifra();
            FillComboPosta();
        }

        private void FillPrirezSifra()
        {
            textBoxPrirez.Text = _grad.Prirez.ToString();
            textBoxSifra.Text = _grad.Sifra;
        }

        private void FillComboPosta()
        {
            DataTable dt = new Posta().GetPostaByGrad(comboBoxGrad.Text);

            //Assign DataTable as DataSource.
            if (dt.Rows.Count > 0)
            {
                comboBoxPosta.DataSource = dt;
                comboBoxPosta.DisplayMember = "BrojPu";
                comboBoxPosta.ValueMember = "BrojPu";
            }
        }

        private void BtnOdaberi_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Custom ShowDialog
        /// </summary>
        /// <returns>City selected from dialog.</returns>
        public Grad ShowDialogValue()
        {
            ShowDialog();

            return _grad;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            _grad.Sifra = textBoxSifra.Text;
            _grad.Prirez = decimal.Parse(textBoxPrirez.Text);
            _grad.Posta = comboBoxPosta.Text;
            _grad.Mjesto = comboBoxGrad.Text;
            FormError validateResult = _grad.ValidateData();
            if (checkBoxNoviGrad.Checked)
                _grad.Id = 0;
            if (validateResult == FormError.None)
            {
                if (_grad.Id == 0 && _grad.InsertNew())
                {
                    MessageBox.Show("Unos uspješan.", "Novi partner unešen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }

                else if (_grad.UpdateData())
                {
                    MessageBox.Show("Izmjena uspješna.", "Izmjena podataka partnera", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            else
            {
                SetMessageLabel(validateResult);
            }
        }

        internal void EditGrad()
        {
            comboBoxGrad.Text = _grad.Mjesto;
            comboBoxZupanija.Text = _grad.Zupanija;
            comboBoxPosta.Text = _grad.Posta;
            textBoxPrirez.Text = _grad.Prirez.ToString();
            textBoxSifra.Text = _grad.Sifra;

            ShowDialog();
        }

        private void SetMessageLabel(FormError errorType)
        {
            labelUpozorenja.Text = new ProcessFormErrors().FormErrorMessage(errorType);

        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private Grad _grad = new Grad();
    }
}
