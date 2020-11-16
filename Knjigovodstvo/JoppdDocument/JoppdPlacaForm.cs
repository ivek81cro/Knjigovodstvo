using Knjigovodstvo.City;
using Knjigovodstvo.Database;
using Knjigovodstvo.Employee;
using Knjigovodstvo.Global;
using Knjigovodstvo.Payroll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

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
            GetKomitentData();
            buttonSnimiPodatke.Enabled = false;
        }

        private void GetKomitentData()
        {
            _dt = new DbDataGet().GetTable(_komitent);
            List<DataRow> row = _dt.AsEnumerable().ToList();
            _komitent = (from DataRow dr in row
                         select new Komitent()
                         {
                             OpciPodaci = new OpciPodaci()
                             {
                                 Id = int.Parse(dr["Id"].ToString()),
                                 Oib = dr["Oib"].ToString(),
                                 Naziv = dr["Naziv"].ToString(),
                             },
                             Kontakt = new Kontakt()
                             {
                                 Email = dr["Email"].ToString()
                             },
                             Adresa = new Adresa()
                             {
                                 Ulica = dr["Ulica"].ToString(),
                                 Broj = dr["Broj"].ToString(),
                                 Grad = new Grad()
                                 {
                                     Mjesto = dr["Mjesto"].ToString(),
                                     Posta = dr["Posta"].ToString()
                                 }
                             }
                         }).ToList().FirstOrDefault();
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            SetJoppdFormNumber();
        }
        /// <summary>
        /// Set correct form number
        /// </summary>
        /// <returns></returns>
        private string SetJoppdFormNumber()
        {
            DateTime date = dateTimePicker1.Value;
            string formNumber = date.Year.ToString();
            string dayOfYear = date.DayOfYear.ToString();

            if (dayOfYear.Length < 3)
            {
                while (dayOfYear.Length != 3)
                {
                    dayOfYear = "0" + dayOfYear;
                }
            }
            formNumber = formNumber.Substring(formNumber.Length - 2) + dayOfYear;

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
        /// <summary>
        /// Fetch data for JoppdB from database
        /// </summary>
        private void FillDataForJoppdFile()
        {
            string datumOd = dateTimePicker1.Value.Year.ToString() + '-' + (dateTimePicker1.Value.Month - 1).ToString();
            datumOd = datumOd.Split('-')[1].Length < 2 ?datumOd.Split('-')[0] + "-0" + datumOd.Split('-')[1] : datumOd;
            _dt = new DbDataExecProcedure().GetTable(ProcedureNames.Joppd_podaci, $"@datumOd='{datumOd}', @dan='01'");

            List<DataRow> rows = _dt.AsEnumerable().ToList();

            PopuniPodatkeStranaB(rows);

            PrikazPodataka();
        }
        /// <summary>
        /// Process data from database about employees needed for JoppdB data
        /// </summary>
        /// <param name="rows"></param>
        private void PopuniPodatkeStranaB(List<DataRow> rows)
        {
            //If only one specific employee is selected
            if (checkBoxPojedinacno.Checked && !comboBoxZaposlenik.Text.StartsWith('-'))
            {
                var newList = rows.Where(s => s.ItemArray[2].ToString() == _zaposlenik.Oib);
                rows = newList.ToList();
            }
            _joppdB.Entitet.Clear();
            int redni_broj = 1;
            _broj_osoba = 0;
            foreach (DataRow dr in rows)
            {
                //Add row for payroll
                _joppdEntitet = new JoppdEntitet()
                {
                    Redni_Broj = redni_broj,
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
                    Primitak_Nesamostalni = decimal.Parse(dr["Bruto"].ToString()),
                    Zdravstvo = decimal.Parse(dr["Doprinos_Zdravstvo"].ToString()),
                    IzdatakUplaceni_Mio = decimal.Parse(dr["Mio_1"].ToString()) + decimal.Parse(dr["Mio_2"].ToString())
                };
                //If only bonuses checked, skip adding payroll to list
                int dodatak_start_number = 1;
                if (checkBoxSamoDodaci.Checked == false)
                {
                    _joppdB.Entitet.Add(_joppdEntitet);
                    redni_broj++;
                }
                //If bonuses are checked insert new row for each separate bonus entity has
                if (checkBoxBezDodataka.Checked == false)
                {
                    var current_element = _joppdEntitet;
                    current_element.PopuniDodatke();
                    current_element.PoduzetnikPrilagodi();
                    //Check if there is more tham one untaxable item and save them in separate row or reciever is enterpreneur
                    if (current_element.GetDodaciCount() > 0)
                    {
                        //If only bonuses are selected start with 0 because of employee + one bonus auto merge
                        if (current_element.Stjecatelj == "0032" || checkBoxSamoDodaci.Checked == true)
                            dodatak_start_number = 0;

                        foreach (var item in current_element.GetDodatakList(dodatak_start_number))
                        {
                            _joppdEntitet = new JoppdEntitet()
                            {
                                Redni_Broj = redni_broj,
                                Opcina_Prebivalista = dr["Opcina_Prebivalista"].ToString(),
                                Opcina_Rada = dr["Opcina_Rada"].ToString(),
                                Oib = dr["Oib"].ToString(),
                                Ime_Prezime = dr["Ime_Prezime"].ToString(),
                                Datum_Od = Convert.ToDateTime(dr["Datum_Od"].ToString()).ToString("yyyy-MM-dd"),
                                Datum_Do = Convert.ToDateTime(dr["Datum_Do"].ToString()).ToString("yyyy-MM-dd"),
                                Oznaka_Neoporezivog = item.Sifra,
                                Nacin_Isplate = dr["Nacin_Isplate"].ToString(),
                                Iznos_Neoporezivog = item.Iznos
                            };
                            //If specific bonus is selected
                            if (!comboBoxDodaci.Text.StartsWith('-'))
                            {
                                if (_joppdEntitet.Oznaka_Neoporezivog == _placaDodatak.Sifra)
                                {
                                    _joppdB.Entitet.Add(_joppdEntitet);
                                    redni_broj++;
                                }
                            }
                            else
                            {
                                _joppdB.Entitet.Add(_joppdEntitet);
                                redni_broj++;
                            }
                        }
                    }
                }
            }
        }

        private void TextBoxSatiRada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// Creates XML file for sending to Porezna Uprava
        /// </summary>
        /// <returns></returns>
        private bool CreateJoppdXmlFile()
        {
            _sObrazacJoppd = new JoppdObrazac(_joppdB, _komitent)
                .CreateJoppdXmlFile(dateTimePicker1.Value, SetJoppdFormNumber(), textBoxIzvjesceSastavioIme.Text, _broj_osoba);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                Filter = "XML file|*.xml",
                Title = "Save an xml File"
            };
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                _path = saveFileDialog1.FileName;
            }
            //Save joppd.xml file
            if (_path != "")
            {
                TextWriter txtWriter = new StreamWriter(_path);
                XmlSerializer x = new XmlSerializer(_sObrazacJoppd.GetType());
                x.Serialize(txtWriter, _sObrazacJoppd);
                txtWriter.Close();

                return true;
            }
            else
            {
                MessageBox.Show("Nije odabrana datoteka za spremanje", "Spremanje XML datoteke", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }
        }
        /// <summary>
        /// Shows XML file data, JoppdB part in datagridview
        /// </summary>
        private void ReadJoppdXmlToDataGrid()
        {
            StreamReader reader = new StreamReader(_path);
            XmlSerializer x = new XmlSerializer(_sObrazacJoppd.GetType());
            _ = (sObrazacJOPPD)x.Deserialize(reader);
            reader.Close();
            //Read xml file into datagridview
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(_path);
            dataGridView1.DataSource = dataSet.Tables[dataSet.Tables.Count - 1];
        }

        private void ComboBoxZaposlenik_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string selected = comboBoxZaposlenik.GetItemText(comboBoxZaposlenik.SelectedItem);
            string oib = selected.Split(' ')[0];
            _zaposlenik.GetZaposlenikByOib(oib);
        }

        private void ComboBoxDodaci_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string selected = comboBoxDodaci.GetItemText(comboBoxDodaci.SelectedItem);
            string code = selected.Split(' ')[0];
            _placaDodatak.Sifra = code;
        }

        //mutually exclude two checkboxes
        private void CheckBoxSamoDodaci_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxSamoDodaci.Checked == true)
                checkBoxBezDodataka.Checked = false;
        }

        private void CheckBoxBezDodataka_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxBezDodataka.Checked == true)
                checkBoxSamoDodaci.Checked = false;
        }
        /// <summary>
        /// Prepare data for Joppd B part of document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPopuniObrazac_Click(object sender, EventArgs e)
        {
            FillDataForJoppdFile();
            buttonSnimiPodatke.Enabled = true;
        }
        /// <summary>
        /// Allow user to edit cells or delete rows before saving to XML file, unlocks edit mode of form's datagridvew
        /// </summary>
        private void PrikazPodataka()
        {
            _list = new BindingList<JoppdEntitet>(_joppdB.Entitet);
            dataGridView1.DataSource = _list;
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToDeleteRows = true;
        }
        /// <summary>
        /// Locks edit mode for form's datagridview and saves data to XML file, result is shown in datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSnimiPodatke_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToDeleteRows = false;
            _joppdB.Entitet = _list.ToList();
            _broj_osoba = _joppdB.Entitet.Select(o => o.Oib).Distinct().ToList().Count();
            if (CreateJoppdXmlFile())
                ReadJoppdXmlToDataGrid();
        }

        private readonly Zaposlenik _zaposlenik = new Zaposlenik();
        private DataTable _dt = new DataTable();
        private readonly JoppdSifre _joppdSifre = new JoppdSifre();
        private readonly JoppdB _joppdB = new JoppdB();
        private Komitent _komitent = new Komitent();
        private sObrazacJOPPD _sObrazacJoppd = new sObrazacJOPPD();
        private string _path = "";
        private int _broj_osoba = 0;
        private JoppdEntitet _joppdEntitet = new JoppdEntitet();
        private readonly PlacaDodatak _placaDodatak = new PlacaDodatak();
        private BindingList<JoppdEntitet> _list = new BindingList<JoppdEntitet>();
    }
}
