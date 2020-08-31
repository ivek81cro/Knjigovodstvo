using Knjigovodstvo.Code.Cities;
using System;
using System.Data;
using System.Data.SqlClient;
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
        //TODO Finish City part and connest to county
        void FillComboCounty()
        {
            DataTable dt = new CountySelectAll().GetAllCounty();
            //Assign DataTable as DataSource.
            comboBoxCounty.DataSource = dt;
            comboBoxCounty.DisplayMember = "Naziv";
            comboBoxCounty.ValueMember = "Id";
        }

        void FillComboCity()
        {
            DataTable dt = new CitySelectByCounty().GetCityByCounty(comboBoxCounty.Text);

            //Assign DataTable as DataSource.
            comboBoxCity.DataSource = dt;
            comboBoxCity.DisplayMember = "Naziv";
            comboBoxCity.ValueMember = "Id";
        }

        private void comboBoxCounty_SelectedValueChanged(object sender, EventArgs e)
        {
            FillComboCity();
        }
    }
}
