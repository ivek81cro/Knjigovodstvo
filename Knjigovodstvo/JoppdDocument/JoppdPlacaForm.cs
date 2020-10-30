using Knjigovodstvo.Database;
using Knjigovodstvo.Employee;
using Knjigovodstvo.Payroll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Knjigovodstvo.JoppdDocument
{
    public partial class JoppdPlacaForm : Form
    {
        public JoppdPlacaForm()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Today;
            SetJoppdFormNumber();
            FillComboBoxZaposlenik();
            FillComboBoxDodaci();

            //TODO test
            PopuniJoppdEntitete();
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            SetJoppdFormNumber();
        }

        private string SetJoppdFormNumber()
        {
            DateTime date = dateTimePicker1.Value;
            string year = date.Year.ToString();
            string dayOfYear = date.DayOfYear.ToString();
            if (dayOfYear.Length < 3)
            {
                while (dayOfYear.Length != 3)
                {
                    dayOfYear = "0" + dayOfYear;
                }
            }

            if (dayOfYear.Length < 3)
            {
                while (dayOfYear.Length != 3)
                {
                    dayOfYear = "0" + dayOfYear;
                }
            }
            string formNumber = year.Substring(year.Length - 2) + dayOfYear;

            labelBrojObrasca.Text = "Oznaka obrasca: " + formNumber;
            
            return formNumber;
        }

        private void FillComboBoxZaposlenik()
        {
            _dt = new DbDataGet().GetTable(_zaposlenik);
            _dt.Columns.Add(
                "Ime i prezime",
                typeof(string),
                "oib + '   ' + Ime + ' ' + Prezime");
            comboBoxZaposlenik.DataSource = _dt;
            comboBoxZaposlenik.DisplayMember = "Ime i prezime";
            comboBoxZaposlenik.SelectedItem = null;
            comboBoxZaposlenik.Text = "--Odaberi zaposlenika--";
        }

        private void FillComboBoxDodaci()
        {
            _dt = new DbDataGet().GetTable(_joppdSifre, $"Skupina='Neoporezivo';");
            _dt.Columns.Add(
                "Sifra i naziv",
                typeof(string),
                "Sifra + ' ' + Opis");
            comboBoxDodaci.DataSource = _dt;
            comboBoxDodaci.DisplayMember = "Sifra i naziv";
            comboBoxDodaci.SelectedItem = null;
            comboBoxDodaci.Text = "--Odaberi Dodatak--";

        }

        private void PopuniJoppdEntitete()
        {
            _dt = new DbDataExecProcedure().GetTable(ProcedureNames.Joppd_podaci, $"@datumOd='2020-09', @dan='01'");
            List<DataRow> rows = _dt.AsEnumerable().ToList();
            _joppdEntiteti.JoppdEntitet = (from DataRow dr in rows
                              select new JoppdEntitet()
                              {
                                  Opcina_Prebivalista = dr["Opcina_Prebivalista"].ToString(),
                                  Opcina_Rada = dr["Opcina_Rada"].ToString(),
                                  Oib = dr["Oib"].ToString(),
                                  Ime_Prezime = dr["Ime_Prezime"].ToString(),
                                  Stjecatelj = dr["Stjecatelj"].ToString(),
                                  Primitak = dr["Primitak"].ToString(),
                                  Beneficirani = dr["Beneficirani"].ToString(),
                                  Invaliditet = dr["Invaliditet"].ToString(),
                                  Mjesec = dr["Mjesec"].ToString(),
                                  Sati = int.Parse(textBoxSatiRada.Text),
                                  Datum_Od = dr["Datum_Od"].ToString(),
                                  Datum_Do = dr["Datum_Do"].ToString(),
                                  Bruto = float.Parse(dr["Bruto"].ToString()),
                                  Mio_1 = float.Parse(dr["Mio_1"].ToString()),
                                  Mio_2 = float.Parse(dr["Mio_2"].ToString()),
                                  Dohodak = float.Parse(dr["Dohodak"].ToString()),
                                  Osobni_Odbitak = float.Parse(dr["Osobni_Odbitak"].ToString()),
                                  Porezna_Osnovica = float.Parse(dr["Porezna_Osnovica"].ToString()),
                                  Porez_Ukupno = float.Parse(dr["Porez_Ukupno"].ToString()),
                                  Prirez = float.Parse(dr["Prirez"].ToString()),
                                  Nacin_Isplate = dr["Nacin_Isplate"].ToString(),
                                  Iznos_Isplate = float.Parse(dr["Neto"].ToString()),
                                  Primitak_Nesamostalni = float.Parse(dr["Bruto"].ToString())
                              }).ToList();

            foreach (JoppdEntitet ent in _joppdEntiteti.JoppdEntitet)
            {
                ent.PopuniDodatke();
                ent.Iznos_Isplate += ent.Iznos_Neoporezivog;
            }

            System.IO.TextWriter txtWriter = new System.IO.StreamWriter(@"Serialization.xml");
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(_joppdEntiteti.GetType());
            x.Serialize(txtWriter, _joppdEntiteti);
            txtWriter.Close();

            System.IO.StreamReader reader = new System.IO.StreamReader(@"Serialization.xml");
            JoppdEntitetCollection enti = (JoppdEntitetCollection)x.Deserialize(reader);
            enti.JoppdEntitet.ForEach(x => x.PopuniDodatke());
            enti.GetType();
        }

        private void textBoxSatiRada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private Zaposlenik _zaposlenik = new Zaposlenik();
        private DataTable _dt = new DataTable();
        private JoppdSifre _joppdSifre = new JoppdSifre();
        private JoppdEntitetCollection _joppdEntiteti = new JoppdEntitetCollection();
    }
}
