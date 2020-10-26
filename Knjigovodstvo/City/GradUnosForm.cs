using Knjigovodstvo.Code.Validators;
using Knjigovodstvo.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace Knjigovodstvo.City
{
    //TODO change textBoxPost to Combo box and load post numbers from database for selected city
    public partial class GradUnosForm : Form
    {
        public GradUnosForm(Grad grad = null)
        {
            InitializeComponent();
            _grad = grad;
            FillComboCounty();
            labelUpozorenja.Text = "";
            if (_grad != null)
            {
                FillComboCity();
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
                comboBoxGrad.DisplayMember = "Naziv";
                comboBoxGrad.ValueMember = "Id";
            }
            int index = comboBoxGrad.FindStringExact(_grad.Naziv);
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
            _grad = _grad.GetGradById(int.Parse(comboBoxGrad.SelectedValue.ToString()));
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
            FormError validateResult = _grad.ValidateData();
            if (validateResult == FormError.None)
            {
                if (!_editMode && _grad.InsertNew())
                {
                    MessageBox.Show("Unos uspješan.", "Novi partner unešen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }

                if (_editMode && _grad.UpdateData(_id))
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

        internal void EditGrad(Grad grad)
        {
            _id = grad.Id;
            comboBoxGrad.Text = grad.Naziv;
            comboBoxZupanija.Text = grad.Zupanija;
            comboBoxPosta.Text = grad.Posta;
            textBoxPrirez.Text = grad.Prirez.ToString();
            textBoxSifra.Text = grad.Sifra;

            _editMode = true;

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

        private Grad _grad;
        private int _id;
        private bool _editMode;
    }
}
