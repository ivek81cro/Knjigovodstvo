using Knjigovodstvo.Code.Validators;
using Knjigovodstvo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Knjigovodstvo.Gui
{
    //TODO change textBoxPost to Combo box and load post numbers from database for selected city
    public partial class GradUnosForm : Form
    {
        public GradUnosForm()
        {
            InitializeComponent();
            FillComboCounty();
            labelWarning.Text = "";
        }

        void FillComboCounty()
        {
            DataTable dt = new Zupanije().GetAllCounty();
            //Assign DataTable as DataSource.
            if (dt.Rows.Count > 0)
            {
                comboBoxCounty.DataSource = dt;
                comboBoxCounty.DisplayMember = "Naziv";
                comboBoxCounty.ValueMember = "Id";
            }
        }

        void FillComboCity()
        {
            DataTable dt = new Opcina().GetCityByCounty(comboBoxCounty.Text);

            //Assign DataTable as DataSource.
            if (dt.Rows.Count > 0)
            {
                comboBoxCity.DataSource = dt;
                comboBoxCity.DisplayMember = "Naziv";
                comboBoxCity.ValueMember = "Id";
            }
        }

        private void ComboBoxCounty_SelectedValueChanged(object sender, EventArgs e)
        {
            FillComboCity();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            _city = new Opcina()
            {
                Drzava = textBoxCountry.Text,
                Zupanija = comboBoxCounty.Text,
                Naziv = comboBoxCity.Text,
                Posta = textBoxPost.Text
            };

            FormError validateResult = _city.ValidateData();
            if (validateResult != FormError.None)
            {
                labelWarning.Text = new ProcessFormErrors().FormErrorMessage(validateResult);
                return;
            }
            Close();
        }

        /// <summary>
        /// Custom ShowDialog
        /// </summary>
        /// <returns>City selected from dialog.</returns>
        public Opcina ShowDialogValue()
        {
            ShowDialog();

            return _city;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            float prirez = 1;
            if (textBoxPrirez.Text != "")
            {
                bool isPrirez = float.TryParse(textBoxPrirez.Text, out prirez);

                if (!isPrirez)
                    labelWarning.Text = "Unešena vrijednost u polje Prirez nije \ndecimalan broj";
            }

            Opcina city = new Opcina
            {
                Naziv=comboBoxCity.Text,
                Drzava=textBoxCountry.Text,
                Posta = textBoxPost.Text,
                Zupanija = comboBoxCounty.Text,
                Prirez = prirez
            };
            List<Opcina> cities = new Opcina().GetAllCities();
            bool isInList = cities.Any(x=> x.Posta==city.Posta && x.Naziv==city.Naziv);

            if (!isInList)
            {
                //TODO Save new city to database
            }
        }

        private Opcina _city;
    }
}
