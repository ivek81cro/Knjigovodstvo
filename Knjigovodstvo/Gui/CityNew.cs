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
            DataTable dt = new CountySelectAll().GetAllCounty();
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
            DataTable dt = new CitySelectByCounty().GetCityByCounty(comboBoxCounty.Text);

            //Assign DataTable as DataSource.
            if (dt.Rows.Count > 0)
            {
                comboBoxCity.DataSource = dt;
                comboBoxCity.DisplayMember = "Naziv";
                comboBoxCity.ValueMember = "Id";
            }
        }

        private void comboBoxCounty_SelectedValueChanged(object sender, EventArgs e)
        {
            FillComboCity();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public City ShowDialogValue()
        {
            ShowDialog();

            return new City {
                Country = textBoxCountry.Text,
                County = comboBoxCounty.Text,
                Name = comboBoxCity.Text,
                Post = textBoxPost.Text
            };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //TODO Save new city in db if doesn't exist and send back result
        }
    }
}
