using Knjigovodstvo.Employee;
using Knjigovodstvo.Helpers;
using System.Data;
using System.Windows.Forms;

namespace Knjigovodstvo.Payroll
{
    public partial class PlacaIzracunForm : Form
    {
        public PlacaIzracunForm()
        {
            InitializeComponent();
            FillComboBox();
        }

        private void FillComboBox()
        {
            DataTable dt = new DbDataGet().GetTable(new Zaposlenik());
            dt.Columns.Add(
                "Ime i prezime", 
                typeof(string),
                "Ime + ' ' + Prezime");
            comboBoxZaposlenik.DataSource = dt;
            comboBoxZaposlenik.DisplayMember = "Ime i prezime";
        }
    }
}
