using Knjigovodstvo.Database;
using Knjigovodstvo.Employee;
using Knjigovodstvo.Payroll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

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
                                               Vrijeme = dr["Vrijeme"].ToString(),
                                               Sati = int.Parse(textBoxSatiRada.Text),
                                               Datum_Od = Convert.ToDateTime(dr["Datum_Od"].ToString()).ToString("yyyy-MM-dd"),
                                               Datum_Do = Convert.ToDateTime(dr["Datum_Do"].ToString()).ToString("yyyy-MM-dd"),
                                               Bruto = decimal.Parse(dr["Bruto"].ToString()),
                                               Mio_1 = decimal.Parse(dr["Mio_1"].ToString()),
                                               Mio_2 = decimal.Parse(dr["Mio_2"].ToString()),
                                               Dohodak = decimal.Parse(dr["Dohodak"].ToString()),
                                               Osobni_Odbitak = decimal.Parse(dr["Osobni_Odbitak"].ToString()),
                                               Porezna_Osnovica = decimal.Parse(dr["Porezna_Osnovica"].ToString()),
                                               Porez_Ukupno = decimal.Parse(dr["Porez_Ukupno"].ToString()),
                                               Prirez = decimal.Parse(dr["Prirez"].ToString()),
                                               Nacin_Isplate = dr["Nacin_Isplate"].ToString(),
                                               Iznos_Isplate = decimal.Parse(dr["Neto"].ToString()),
                                               Primitak_Nesamostalni = decimal.Parse(dr["Bruto"].ToString())
                                           }).ToList();

            List<sPrimateljiP> pArr = new List<sPrimateljiP>();
            for (int i = 0; i < _joppdEntiteti.JoppdEntitet.Count; i++)
            {
                JoppdEntitet e = _joppdEntiteti.JoppdEntitet[i];
                e.PopuniDodatke(i + 1);
                pArr.Add(new sPrimateljiP()
                {
                    P1 = e.Redni_Broj,
                    P2 = e.Opcina_Prebivalista,
                    P3 = e.Opcina_Rada,
                    P4 = e.Oib,
                    P5 = e.Ime_Prezime,
                    P61 = (tOznakaStjecatelja)Enum.Parse(typeof(tOznakaStjecatelja), e.Stjecatelj),
                    P62 = (tOznakaPrimici)Enum.Parse(typeof(tOznakaPrimici), e.Primitak),
                    P71 = (tOznakaMO)Enum.Parse(typeof(tOznakaMO), e.Beneficirani),
                    P72 = (tOznakaInvaliditet)Enum.Parse(typeof(tOznakaInvaliditet), e.Invaliditet),
                    P8 = (tOznakaMjesec)Enum.Parse(typeof(tOznakaMjesec), e.Mjesec),
                    P9 = (tOznakaRadnoVrijeme)Enum.Parse(typeof(tOznakaRadnoVrijeme), e.Vrijeme),
                    P10 = e.Sati,
                    P101 = Convert.ToDateTime(e.Datum_Od),
                    P102 = Convert.ToDateTime(e.Datum_Do),
                    P11 = e.Bruto,
                    P12 = e.Bruto,
                    P121 = e.Mio_1,
                    P122 = e.Mio_2,
                    P123 = e.Zdravstvo,
                    P124 = e.Zaštita,
                    P125 = e.Zaposljavanje,
                    P126 = e.Povecani_Mio,
                    P127 = e.Povecani_Mio2,
                    P129 = e.Invaliditet_Doprinos,
                    P131 = e.Izdatak,
                    P132 = e.IzdatakUplaceni_Mio,
                    P133 = e.Dohodak,
                    P134 = e.Osobni_Odbitak,
                    P135 = e.Porezna_Osnovica,
                    P141 = e.Porez_Ukupno,
                    P142 = e.Prirez,
                    P151 = (tOznakaNeoporezivogPrimitka)Enum.Parse(typeof(tOznakaNeoporezivogPrimitka), e.Oznaka_Neoporezivog),
                    P152 = e.Iznos_Neoporezivog,
                    P161 = (tOznakaNacinaIsplate)Enum.Parse(typeof(tOznakaNacinaIsplate), e.Nacin_Isplate),
                    P162 = e.Iznos_Isplate,
                    P17 = e.Primitak_Nesamostalni
                });
            }
            sStranaA strA = new sStranaA()
            {
                DatumIzvjesca = dateTimePicker1.Value,
                OznakaIzvjesca = SetJoppdFormNumber(),
                VrstaIzvjesca = tVrstaIzvjesca.Item2,
                BrojOsoba = pArr.Count.ToString(),
                BrojRedaka = pArr.Count.ToString(),
                IzvjesceSastavio = new sIzvjesceSastavio()
                {
                    Ime = textBoxIzvjesceSastavioIme.Text.Split(' ')[0],
                    Prezime = textBoxIzvjesceSastavioIme.Text.Split(' ')[1]
                },
                PodnositeljIzvjesca = new sPodnositeljIzvjesca()
                {
                    OIB = "12345678901",
                    Oznaka = tOznakaPodnositelja.Item2,
                    Adresa = new sAdresa() { Ulica = "Ulica", Broj = "15", Mjesto = "Zagreb" },
                    Email = "mail@domena.hr",
                    ItemsElementName = new[] { ItemsChoiceType.Naziv },
                    Items = new[] { "Firma d.o.o" }
                },
                //TODO continue with member value assigning
            };
            
            sJOPPDmetapodaci meta = new sJOPPDmetapodaci()
            {
                Datum = new sDatumTemeljni() { Value = dateTimePicker1.Value },
                Naslov = new sNaslovTemeljni() { Value = "Izvješće o primicima, porezu na dohodak i prirezu te doprinosima za obvezna osiguranja" },
                Autor = new sAutorTemeljni() { Value = "Ivan Batinić" },
                Format = new sFormatTemeljni() { Value = tFormat.textxml },
                Jezik = new sJezikTemeljni() { Value = tJezik.hrHR },
                Identifikator = new sIdentifikatorTemeljni() { Value = Guid.NewGuid().ToString() },
                Uskladjenost = new sUskladjenost() { Value = "ObrazacJOPPD-v1-1" },
                Tip = new sTipTemeljni() { Value = tTip.Elektroničkiobrazac },
                Adresant = new sAdresantTemeljni() { Value = "Ministarstvo Financija, Porezna uprava, Zagreb" }
            };
            sPrimateljiP[][] prim = { pArr.ToArray() };

            _sObrazacJoppd.StranaA = strA;
            _sObrazacJoppd.StranaB = prim;
            _sObrazacJoppd.Metapodaci = meta;

            System.IO.TextWriter txtWriter = new System.IO.StreamWriter(@"Serialization.xml");
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(_sObrazacJoppd.GetType());
            x.Serialize(txtWriter, _sObrazacJoppd);
            txtWriter.Close();

            System.IO.StreamReader reader = new System.IO.StreamReader(@"Serialization.xml");
            sObrazacJOPPD enti = (sObrazacJOPPD)x.Deserialize(reader);
            reader.Close();

            DataSet dataSet = new DataSet();
            dataSet.ReadXml(@"Serialization.xml");
            dataGridView1.DataSource = dataSet.Tables[14];

            enti.GetType();
        }

        private void textBoxSatiRada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void buttonPopuniObrazac_Click(object sender, EventArgs e)
        {
            PopuniJoppdEntitete();
        }

        private Zaposlenik _zaposlenik = new Zaposlenik();
        private DataTable _dt = new DataTable();
        private JoppdSifre _joppdSifre = new JoppdSifre();
        private JoppdEntitetCollection _joppdEntiteti = new JoppdEntitetCollection();
        private sObrazacJOPPD _sObrazacJoppd = new sObrazacJOPPD();
    }
}
