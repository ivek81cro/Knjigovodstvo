using Knjigovodstvo.City;
using Knjigovodstvo.Employee;
using Knjigovodstvo.Helpers;
using System;
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
                "oib + '   ' + Ime + ' ' + Prezime");
            comboBoxZaposlenik.DataSource = dt;
            comboBoxZaposlenik.DisplayMember = "Ime i prezime";
        }

        private void buttonClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void buttonIzracunaj_Click(object sender, System.EventArgs e)
        {
            Zaposlenik zaposlenik = new Zaposlenik().GetZaposlenikByOib(_oib);
            float prirez = float.Parse(new DbDataGet().GetTable(new Grad(), $"Naziv='{zaposlenik.Grad}';").Rows[0][5].ToString()) / 100.0f;
            Placa placa = new Placa();
            float iznosBruto = float.Parse(textBoxBruto.Text);
            placa.Izracun(iznosBruto, prirez, zaposlenik.Olaksica, checkBoxSamoMio1.Checked);

            textBoxMio1.Text = Math.Round(placa.Mio1,2).ToString();
            textBoxMio2.Text = Math.Round(placa.Mio2,2).ToString();
            textBoxDohodak.Text = Math.Round(placa.Dohodak,2).ToString();
            textBoxOdbitak.Text = Math.Round(placa.OsobniOdbitak, 2).ToString();
            textBoxPoreznaOsnovica.Text = Math.Round(placa.PoreznaOsnovica, 2).ToString();
            textBoxPorez24.Text = Math.Round(placa.Porez24, 2).ToString();
            textBoxPorez36.Text = Math.Round(placa.Porez36, 2).ToString();
            textBoxPorezUkupno.Text = Math.Round(placa.PorezUkupno, 2).ToString();
            textBoxPrirez.Text = Math.Round(placa.Prirez, 2).ToString();
            textBoxUkupnoPorezPrirez.Text = Math.Round(placa.UkupnoPorezPrirez, 2).ToString();
            textBoxNetto.Text = Math.Round(placa.Neto, 2).ToString();
            textBoxDoprinosZdravstvo.Text = Math.Round(placa.DoprinosZdravstvo, 2).ToString();
        }

        private void comboBoxZaposlenik_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            string selected = this.comboBoxZaposlenik.GetItemText(this.comboBoxZaposlenik.SelectedItem);
            _oib = selected.Split(' ')[0];
        }

        string _oib = "";
    }
}
