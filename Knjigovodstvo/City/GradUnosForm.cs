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
            FillComboCounty();
            labelUpozorenja.Text = "";
            _grad = grad;
            if (_grad != null)
            {
                SetControls();
            }
        }

        private void SetControls()
        {
            int index = comboBoxZupanija.FindStringExact(_grad.Zupanija);
            comboBoxZupanija.SelectedIndex = index;
            index = comboBoxGrad.FindStringExact(_grad.Naziv);
            comboBoxGrad.SelectedIndex = index;
            textBoxPrirez.Text = _grad.Prirez.ToString();
            textBoxSifra.Text = _grad.Sifra;
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
        }

        private void ComboBoxCounty_SelectedValueChanged(object sender, EventArgs e)
        {
            FillComboCity();
        }

        private void comboBoxGrad_SelectedValueChanged(object sender, EventArgs e)
        {
            FillComboPosta();
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

        private void BtnClose_Click(object sender, EventArgs e)
        {
            _grad = new Grad()
            {
                Drzava = textBoxDrzava.Text,
                Zupanija = comboBoxZupanija.Text,
                Naziv = comboBoxGrad.Text,
                Posta = comboBoxPosta.Text,
                Sifra = textBoxSifra.Text
            };

            FormError validateResult = _grad.ValidateData();
            if (validateResult != FormError.None)
            {
                labelUpozorenja.Text = new ProcessFormErrors().FormErrorMessage(validateResult);
                return;
            }
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
            Grad grad = new Grad
            {
                Naziv = comboBoxGrad.Text,
                Zupanija = comboBoxZupanija.Text,
                Posta = comboBoxPosta.Text,
                Prirez = float.Parse(textBoxPrirez.Text),
                Drzava = textBoxDrzava.Text,
                Sifra = textBoxSifra.Text
            };

            FormError validateResult = grad.ValidateData();
            if (validateResult == FormError.None)
            {
                if (!_editMode && grad.InsertNew())
                {
                    MessageBox.Show("Unos uspješan.", "Novi partner unešen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }

                if (_editMode && grad.UpdateData(_id))
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
            comboBoxGrad.Text = grad.Naziv;//TODO: NE sprema naziv odabranog grada
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

        private Grad _grad;
        private int _id;
        private bool _editMode;
    }
}
