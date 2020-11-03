﻿using Knjigovodstvo.Code.Validators;
using Knjigovodstvo.Database;
using Knjigovodstvo.Employee;
using System;
using System.Collections.Generic;
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
        }

        private void GetKomitentData()
        {
            _dt = new DbDataGet().GetTable(_komitent);
            List<DataRow> row = _dt.AsEnumerable().ToList();
            _komitent = (from DataRow dr in row
                  select new Komitent()
                  {
                      Id = int.Parse(dr["Id"].ToString()),
                      Oib = dr["Oib"].ToString(),
                      Mail = dr["Mail"].ToString(),
                      Naziv = dr["Naziv"].ToString(),
                      Adresa = dr["Adresa"].ToString(),
                      Grad = dr["Grad"].ToString(),
                      Posta = dr["Posta"].ToString()
                  }).ToList().ElementAt(0);
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

        private void FillDataForJoppdFile()
        {
            string datumOd = dateTimePicker1.Value.Year.ToString() + '-' + (dateTimePicker1.Value.Month - 1).ToString();
            _dt = new DbDataExecProcedure().GetTable(ProcedureNames.Joppd_podaci, $"@datumOd='{datumOd}', @dan='01'");
         
            List<DataRow> rows = _dt.AsEnumerable().ToList();
            
            //If only one specific employee is selected
            if(checkBoxPojedinacno.Checked && !comboBoxZaposlenik.Text.StartsWith('-'))
            {
                var newList = rows.Where(s => s.ItemArray[2].ToString() == _zaposlenik.Oib);
                rows = newList.ToList();
            }

            _joppdB.Entitet = (from DataRow dr in rows
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
                                               Primitak_Nesamostalni = decimal.Parse(dr["Bruto"].ToString()),
                                               Zdravstvo = decimal.Parse(dr["Doprinos_Zdravstvo"].ToString()),
                                               IzdatakUplaceni_Mio = decimal.Parse(dr["Mio_1"].ToString()) + decimal.Parse(dr["Mio_2"].ToString())
                                           }).ToList();
        }

        private void TextBoxSatiRada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CreateJoppdXmlFile()
        {
            _sObrazacJoppd = new JoppdObrazac(_joppdB, _komitent)
                .CreateJoppdXmlFile(dateTimePicker1.Value, SetJoppdFormNumber(), textBoxIzvjesceSastavioIme.Text);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML file|*.xml";
            saveFileDialog1.Title = "Save an xml File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                _path = saveFileDialog1.FileName;
            }
                //Save joppd.xml file
                TextWriter txtWriter = new StreamWriter(_path);
            XmlSerializer x = new XmlSerializer(_sObrazacJoppd.GetType());
            x.Serialize(txtWriter, _sObrazacJoppd);
            txtWriter.Close();
        }

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

        private void ButtonPopuniObrazac_Click(object sender, EventArgs e)
        {
            FillDataForJoppdFile();
            CreateJoppdXmlFile();
            ReadJoppdXmlToDataGrid();
        }
        private void ComboBoxZaposlenik_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string selected = this.comboBoxZaposlenik.GetItemText(this.comboBoxZaposlenik.SelectedItem);
            string oib = selected.Split(' ')[0];
            _zaposlenik = _zaposlenik.GetZaposlenikByOib(oib);
        }

        private Zaposlenik _zaposlenik = new Zaposlenik();
        private DataTable _dt = new DataTable();
        private JoppdSifre _joppdSifre = new JoppdSifre();
        private JoppdB _joppdB = new JoppdB();
        private Komitent _komitent = new Komitent();
        private sObrazacJOPPD _sObrazacJoppd = new sObrazacJOPPD();
        private string _path = "";

    }
}
