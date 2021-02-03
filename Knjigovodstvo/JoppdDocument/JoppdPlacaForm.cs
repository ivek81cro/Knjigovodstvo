using Knjigovodstvo.Database;
using Knjigovodstvo.Helpers;
using Knjigovodstvo.Wages;
using System;
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
            InitializeDate();
            SetJoppdFormNumber();
            FillComboBoxDodaci();
            GetKomitentData();
            buttonSnimiPodatke.Enabled = false;
        }

        private void InitializeDate()
        {
            DateTime date = DateTime.Now.AddMonths(-1);
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            dateTimePickerRazdobljeOd.Value = firstDayOfMonth;
            dateTimePickerRazdobljeDo.Value = lastDayOfMonth;
        }

        private void GetKomitentData()
        {
            _komitent.GetData();
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
            formNumber = formNumber[^2..] + dayOfYear;

            labelBrojObrasca.Text = formNumber;

            return formNumber;
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
        private void LoadDataGrid()
        {
            _dt = new DbDataCustomQuery().ExecuteQuery($"SELECT * FROM JoppdObrazac");//View in DB
            _dt.Columns.Add("Sati_neradnih", typeof(string)).SetOrdinal(10);
            _dt.Columns.Add("Sati_radnih", typeof(string)).SetOrdinal(10);
            _dt.Columns.Add("Razdoblje_do", typeof(string)).SetOrdinal(10);
            _dt.Columns.Add("Razdoblje_od", typeof(string)).SetOrdinal(10);
            _dt.Columns.Add("Opcina_Rada", typeof(string)).SetOrdinal(1);
            _dt.Columns.Add("Odabir", typeof(bool)).SetOrdinal(0);

            dbDataGridView1.DataSource = _dt;
            foreach(DataGridViewRow row in dbDataGridView1.Rows)
            {
                row.Cells["Opcina_Rada"].Value = _komitent.Adresa.Grad.Sifra;
                row.Cells["Sati_radnih"].Value = textBoxSatiRada.Text;
                row.Cells["Sati_neradnih"].Value = textBoxSatiPraznika.Text;
                row.Cells["Razdoblje_od"].Value = dateTimePickerRazdobljeOd.Value.ToString("yyyy-MM-dd");
                row.Cells["Razdoblje_do"].Value = dateTimePickerRazdobljeDo.Value.ToString("yyyy-MM-dd");
            }

            foreach(DataGridViewColumn col in dbDataGridView1.Columns)
            {
                col.HeaderText = new TableHeaderFormat().FormatHeader(
                    col.HeaderText);
            }

            dbDataGridView1.Columns[0].Width = 50;
            dbDataGridView1.ReadOnly = false;
        }

        /// <summary>
        /// Process data from database about employees needed for JoppdB data
        /// </summary>
        /// <param name="rows"></param>
        private void PopuniPodatkeStranaB()
        {
            _joppdB.Entitet.Clear();

            int redni_broj = 1;
            foreach (DataGridViewRow row in dbDataGridView1.Rows)
            {
                //Add row for wage
                if (row.Cells["Odabir"].Value.ToString() == "True")
                {
                    _joppdEntitet = new JoppdEntitet().CreateNewJoppdEntitet(row, redni_broj);
                }
                else
                {
                    continue;
                }

                //If only bonuses checked, skip adding wage to list
                int dodatak_start_number = 1;
                if (!checkBoxSamoDodaci.Checked)
                {
                    _joppdB.Entitet.Add(_joppdEntitet);
                    redni_broj++;
                }

                var current_element = _joppdEntitet;
                //If bonuses are checked insert new row for each separate bonus entity has
                if (!checkBoxBezDodataka.Checked)
                {
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
                                Opcina_Prebivalista = row.Cells["Opcina_Prebivalista"].Value.ToString(),
                                Opcina_Rada = row.Cells["Opcina_Rada"].Value.ToString(),
                                Oib = row.Cells["Oib"].Value.ToString(),
                                Ime_Prezime = row.Cells["Ime_i_prezime"].Value.ToString(),
                                Datum_Od = dateTimePickerRazdobljeOd.Value.ToString("yyyy-MM-dd"),
                                Datum_Do = dateTimePickerRazdobljeDo.Value.ToString("yyyy-MM-dd"),
                                Oznaka_Neoporezivog = item.Sifra,
                                Nacin_Isplate = row.Cells["Nacin_Isplate"].Value.ToString(),
                                Iznos_Neoporezivog = item.Iznos,
                                Iznos_Isplate = item.Iznos
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
                else
                {
                    current_element.PoduzetnikPrilagodi();
                }
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
            dbDataGridView1.DataSource = dataSet.Tables[dataSet.Tables.Count - 1];
        }

        private void TextBoxSatiRada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
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

        private void TextBoxGodinaObracuna_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Prepare data for Joppd B part of document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPopuniObrazac_Click(object sender, EventArgs e)
        {
            LoadDataGrid();
            buttonSnimiPodatke.Enabled = true;
        }

        /// <summary>
        /// Locks edit mode for form's datagridview and saves data to XML file, result is shown in datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSnimiPodatke_Click(object sender, EventArgs e)
        {
            PopuniPodatkeStranaB();

            _broj_osoba = _joppdB.Entitet.Select(o => o.Oib).Distinct().ToList().Count();
            if (CreateJoppdXmlFile())
                ReadJoppdXmlToDataGrid();

            buttonSnimiPodatke.Enabled = false;
        }

        private DataTable _dt = new DataTable();
        private readonly JoppdSifre _joppdSifre = new JoppdSifre();
        private readonly JoppdB _joppdB = new JoppdB();
        private readonly Komitent _komitent = new Komitent();
        private sObrazacJOPPD _sObrazacJoppd = new sObrazacJOPPD();
        private string _path = "";
        private int _broj_osoba = 0;
        private JoppdEntitet _joppdEntitet = new JoppdEntitet();
        private readonly Dodatak _placaDodatak = new Dodatak();
    }
}
