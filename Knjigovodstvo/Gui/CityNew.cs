using Knjigovodstvo.Code.Cities;
using Knjigovodstvo.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace Knjigovodstvo.Gui
{
    public partial class CityNew : Form
    {
        public CityNew()
        {
            InitializeComponent();
            FillComboCounty();
        }

        void FillComboCounty()
        {
            DataTable dt = new CountySelect().GetAllCounty();
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
            DataTable dt = new CitySelect().GetCityByCounty(comboBoxCounty.Text);

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
            _city = new City()
            {
                Country = textBoxCountry.Text,
                County = comboBoxCounty.Text,
                Name = comboBoxCity.Text,
                Post = textBoxPost.Text
            };

            if (!_city.ValidateData())
            {
                labelWarning.Text = "Provjerite valjanost podataka.";
                return;
            }
            Close();
        }

        public City ShowDialogValue()
        {
            ShowDialog();

            return _city;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //TODO Save new city in db if doesn't exist and send back result
        }

        private City _city;
    }
}
