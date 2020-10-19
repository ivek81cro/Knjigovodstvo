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
            comboBoxZaposlenik.SelectedItem = null;
            comboBoxZaposlenik.Text = "--Odaberi zaposlenika--";
        }

        internal void EditPlaca(Placa placa)
        {
            PopuniKontrole(placa);
            int index = comboBoxZaposlenik.FindString(placa.Oib);
            comboBoxZaposlenik.SelectedIndex = index;

            ShowDialog();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonIzracunaj_Click(object sender, EventArgs e)
        {
            if (comboBoxZaposlenik.SelectedItem != null)
            {
                Zaposlenik zaposlenik = new Zaposlenik().GetZaposlenikByOib(_oib);
                float prirez = float.Parse(new DbDataGet().GetTable(new Grad(), $"Naziv='{zaposlenik.Grad}';").Rows[0][5].ToString()) / 100.0f;
                float iznosBruto = float.Parse(textBoxBruto.Text);
                placa.Izracun(iznosBruto, prirez, zaposlenik.Olaksica, checkBoxSamoMio1.Checked);
                placa.Oib = _oib;

                PopuniKontrole(placa);
            }
        }

        private void comboBoxZaposlenik_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string selected = this.comboBoxZaposlenik.GetItemText(this.comboBoxZaposlenik.SelectedItem);
            _oib = selected.Split(' ')[0];
            if (placa.GetPlacaByOib(_oib).Oib != "0")
                PopuniKontrole(placa);

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxZaposlenik.SelectedItem != null && placa.Oib != "" && placa.Oib != "0")
            {
                if (new Placa().GetPlacaByOib(_oib).Oib == "0")
                {
                    if (new DbDataInsert().InsertData(placa))
                    {
                        FillComboBox();
                        MessageBox.Show("Unos uspješan.", "Novi izračun unešen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (new DbDataUpdate().UpdateData(placa))
                    {
                        FillComboBox();
                        MessageBox.Show("Unos uspješan.", "Izmjena unešena", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void PopuniKontrole(Placa placa)
        {
            textBoxMio1.Text = Math.Round(placa.Mio1, 2).ToString("0.00");
            textBoxMio2.Text = Math.Round(placa.Mio2, 2).ToString("0.00");
            textBoxDohodak.Text = Math.Round(placa.Dohodak, 2).ToString("0.00");
            textBoxOdbitak.Text = Math.Round(placa.OsobniOdbitak, 2).ToString("0.00");
            textBoxPoreznaOsnovica.Text = Math.Round(placa.PoreznaOsnovica, 2).ToString("0.00");
            textBoxPorez24.Text = Math.Round(placa.Porez24, 2).ToString("0.00");
            textBoxPorez36.Text = Math.Round(placa.Porez36, 2).ToString("0.00");
            textBoxPorezUkupno.Text = Math.Round(placa.PorezUkupno, 2).ToString("0.00");
            textBoxPrirez.Text = Math.Round(placa.Prirez, 2).ToString("0.00");
            textBoxUkupnoPorezPrirez.Text = Math.Round(placa.UkupnoPorezPrirez, 2).ToString("0.00");
            textBoxNetto.Text = Math.Round(placa.Neto, 2).ToString("0.00");
            textBoxDoprinosZdravstvo.Text = Math.Round(placa.DoprinosZdravstvo, 2).ToString("0.00");
        }

        string _oib = "";
        private Placa placa = new Placa();
    }
}
