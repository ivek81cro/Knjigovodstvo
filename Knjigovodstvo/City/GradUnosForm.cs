using Knjigovodstvo.Code.Validators;
using Knjigovodstvo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Knjigovodstvo.City
{
    //TODO change textBoxPost to Combo box and load post numbers from database for selected city
    public partial class GradUnosForm : Form
    {
        public GradUnosForm()
        {
            InitializeComponent();
            FillComboCounty();
            labelUpozorenja.Text = "";
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
            DataTable dt = new Grad().GetGradByZupanija(comboBoxZupanija.Text);

            //Assign DataTable as DataSource.
            if (dt.Rows.Count > 0)
            {
                comboBoxNaziv.DataSource = dt;
                comboBoxNaziv.DisplayMember = "Naziv";
                comboBoxNaziv.ValueMember = "Id";
            }
        }

        private void ComboBoxCounty_SelectedValueChanged(object sender, EventArgs e)
        {
            FillComboCity();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            _grad = new Grad()
            {
                Drzava = textBoxDrzava.Text,
                Zupanija = comboBoxZupanija.Text,
                Naziv = comboBoxNaziv.Text,
                Posta = textBoxPosta.Text
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
                Naziv = comboBoxNaziv.Text,
                Zupanija = comboBoxZupanija.Text,
                Posta = textBoxPosta.Text,
                Prirez = float.Parse(textBoxPrirez.Text),
                Drzava =textBoxDrzava.Text
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
            comboBoxNaziv.Text = grad.Naziv;//TODO: NE sprema naziv odabranog grada
            comboBoxZupanija.Text = grad.Zupanija;
            textBoxPosta.Text = grad.Posta;
            textBoxPrirez.Text = grad.Prirez.ToString();

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
