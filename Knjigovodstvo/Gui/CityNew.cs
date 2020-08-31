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
            using (SqlConnection conn = new SqlConnection(ConnHelper.ConnStr("KnjigovodstvoDb")))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT Id, Naziv FROM Zupanije", conn))
                {
                    //Fill the DataTable with records from Table.
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    //Insert the Default Item to DataTable.
                    DataRow row = dt.NewRow();
                    row[0] = 0;
                    row[1] = "Odaberite županiju";
                    dt.Rows.InsertAt(row, 0);

                    //Assign DataTable as DataSource.
                    comboBoxCounty.DataSource = dt;
                    comboBoxCounty.DisplayMember = "Naziv";
                    comboBoxCounty.ValueMember = "Id";
                }
            }
        }

        void FillComboCity()
        {
            using (SqlConnection conn = new SqlConnection(ConnHelper.ConnStr("KnjigovodstvoDb")))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(String.Format("SELECT Id, Naziv FROM Opcina where Zupanija='{0}';", comboBoxCounty.Text), conn))
                {
                    //Fill the DataTable with records from Table.
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    //Insert the Default Item to DataTable.
                    DataRow row = dt.NewRow();
                    row[0] = 0;
                    row[1] = "Odaberite grad";
                    dt.Rows.InsertAt(row, 0);

                    //Assign DataTable as DataSource.
                    comboBoxCity.DataSource = dt;
                    comboBoxCity.DisplayMember = "Naziv";
                    comboBoxCity.ValueMember = "Id";
                }
            }
        }

        private void comboBoxCounty_SelectedValueChanged(object sender, EventArgs e)
        {
            FillComboCity();
        }
    }
}
