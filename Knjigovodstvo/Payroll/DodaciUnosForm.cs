using Knjigovodstvo.Database;
using Knjigovodstvo.Employee;
using Knjigovodstvo.JoppdDocument;
using Knjigovodstvo.Validators;
using System;
using System.Data;
using System.Windows.Forms;

namespace Knjigovodstvo.Payroll
{
    public partial class DodaciUnosForm : Form
    {
        public DodaciUnosForm(Zaposlenik zaposlenik = null, Placa placa = null)
        {
            InitializeComponent();
            _zaposlenik = zaposlenik;
            _placa = placa;
            FillComboBoxZaposlenici();            
            FillComboBoxDodaci();
            if (_zaposlenik != null)
            {
                int index = comboBoxOdabirZaposlenika.FindString(_zaposlenik.Oib);
                comboBoxOdabirZaposlenika.SelectedIndex = index;
                LoadDatagrid();
            }
            
        }

        private void LoadDatagrid()
        {
            dataGridView1.DataSource = new DbDataGet().GetTable(_dodaci, $"Oib='{_zaposlenik.Oib}';");
        }

        private void FillComboBoxZaposlenici()
        {
            DataTable dt = new DbDataGet().GetTable(new Zaposlenik());
            dt.Columns.Add(
                "Ime i prezime",
                typeof(string),
                "oib + '   ' + Ime + ' ' + Prezime");
            comboBoxOdabirZaposlenika.DataSource = dt;
            comboBoxOdabirZaposlenika.DisplayMember = "Ime i prezime";
            comboBoxOdabirZaposlenika.SelectedItem = null;
            comboBoxOdabirZaposlenika.Text = "--Odaberi zaposlenika--";
        }

        private void FillComboBoxDodaci()
        {
            DataTable dt = new DbDataGet().GetTable(new JoppdSifre(), $"Skupina='Neoporezivo';");
            dt.Columns.Add(
                "Naziv i Opis",
                typeof(string),
                "Sifra + ' - ' + Opis");
            comboBoxOdabirDodatka.DataSource = dt;
            comboBoxOdabirDodatka.DisplayMember = "Naziv i Opis";
            comboBoxOdabirDodatka.SelectedItem = null;
            comboBoxOdabirDodatka.Text = "--Odaberi dodatak--";
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (textBoxIznos.Text != "")
            {
                if (new FloatValidator().Check(textBoxIznos.Text))
                {
                    _dodaci.Oib = _zaposlenik.Oib;
                    _dodaci.Sifra = _sifra;
                    _dodaci.Iznos = decimal.Parse(textBoxIznos.Text);
                    

                    int existsId = CheckDuplicate(_dodaci);

                    if (existsId != 0)
                    {
                        _dodaci.Id = existsId;
                        new DbDataUpdate().UpdateData(_dodaci);
                        _placa = _dodaci.ZbrojiDodatke(_placa, _zaposlenik);
                        new DbDataUpdate().UpdateData(_placa);

                        MessageBox.Show("Izmjena uspješna.", "Dodaci", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if(new DbDataInsert().InsertData(_dodaci))
                    {
                        _placa = _dodaci.ZbrojiDodatke(_placa, _zaposlenik);
                        new DbDataUpdate().UpdateData(_placa);
                        MessageBox.Show("Unos uspješan.", "Dodaci", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDatagrid();
                    }
                }
                else
                {
                    MessageBox.Show("Neispravan format unešenog broja.", "Dodaci", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private int CheckDuplicate(PlacaDodatak dodatak)
        {
            DataTable table = new DbDataGet().GetTable(dodatak, $"Oib='{_zaposlenik.Oib}' AND Sifra={_sifra};");
            foreach(DataRow row in table.Rows)
            {
                if (row["Oib"].ToString() == dodatak.Oib && row["Sifra"].ToString() == dodatak.Sifra)
                    return int.Parse(row["Id"].ToString());
            }
            return 0;
        }

        private void ComboBoxOdabirDodatka_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string sifra = comboBoxOdabirDodatka.GetItemText(comboBoxOdabirDodatka.SelectedItem);
            _sifra = sifra.Split(' ')[0];
        }

        private void ComboBoxOdabirZaposlenika_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string zaposlenik = comboBoxOdabirZaposlenika.GetItemText(comboBoxOdabirZaposlenika.SelectedItem);
            string oib = zaposlenik.Split(' ')[0];
            _zaposlenik.GetZaposlenikByOib(oib);
            _placa.GetPlacaByOib(oib);
            LoadDatagrid();
        }

        public Placa ShowDialogValue()
        {
            ShowDialog();
            
            return _placa;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                _dodaci.Id = int.Parse(dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString());

                if(new DbDataDelete().DeleteItem(_dodaci))
                {
                    MessageBox.Show("Dodatak obrisan.", "Dodaci", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDatagrid();
                }
                else
                {
                    MessageBox.Show("Dodatak nije obrisan.", "Dodaci", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private PlacaDodatak _dodaci = new PlacaDodatak();
        private Zaposlenik _zaposlenik;
        private Placa _placa;
        private string _sifra = "";
    }
}
