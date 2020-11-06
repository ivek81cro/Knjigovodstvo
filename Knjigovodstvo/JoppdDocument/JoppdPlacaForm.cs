﻿using Knjigovodstvo.City;
using Knjigovodstvo.Database;
using Knjigovodstvo.Employee;
using Knjigovodstvo.Global;
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
                      OpciPodaci = new OpciPodaci() 
                      {
                          Id = int.Parse(dr["Id"].ToString()),
                          Oib = dr["Oib"].ToString(),
                          Naziv = dr["Naziv"].ToString(),
                      },
                      Kontakt = new Kontakt() 
                      {
                          Email = dr["Mail"].ToString()
                      },
                      Adresa = new Adresa() 
                      {
                          Ulica = dr["Adresa"].ToString(),
                          Broj = dr["Broj"].ToString(),
                          Grad = new Grad()
                          {
                              Mjesto = dr["Mjesto"].ToString(),
                              Posta = dr["Posta"].ToString()
                          }
                      }
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
            JoppdA jA = new JoppdA(pArr);
            sStranaA strA = new sStranaA()
            {
                DatumIzvjesca = dateTimePicker1.Value,
                OznakaIzvjesca = SetJoppdFormNumber(),
                VrstaIzvjesca = tVrstaIzvjesca.Item2,
                IzvjesceSastavio = new sIzvjesceSastavio()
                {
                    Ime = textBoxIzvjesceSastavioIme.Text.Split(' ')[0],
                    Prezime = textBoxIzvjesceSastavioIme.Text.Split(' ')[1]
                },
                PodnositeljIzvjesca = new sPodnositeljIzvjesca()
                {
                    ItemsElementName = new[] { ItemsChoiceType.Naziv },
                    Items = new[] { _komitent.OpciPodaci.Naziv },
                    Adresa = new sAdresa()
                    {
                        Ulica = _komitent.Adresa.Ulica,
                        Broj = _komitent.Adresa.Broj,
                        Mjesto = _komitent.Adresa.Grad.Mjesto
                    },
                    Email = _komitent.Kontakt.Email,
                    OIB = _komitent.OpciPodaci.Oib,
                    Oznaka = tOznakaPodnositelja.Item2
                },
                BrojOsoba = pArr.Count.ToString(),
                BrojRedaka = pArr.Count.ToString(),
                PredujamPoreza = new sPredujamPoreza()
                {
                    P1 = jA.UkupnoPorezIPrirez(),
                    P11 = jA.UkupnoPorezIPrirez(),
                    P12 = 0,
                    P2 = 0,
                    P3 = 0,
                    P4 = 0,
                    P5 = 0,
                    P6 = 0
                },
                Doprinosi = new sDoprinosi()
                {
                    GeneracijskaSolidarnost = new sGeneracijskaSolidarnost()
                    {
                        P1 = jA.SviDoprinosiGeneracijskaDjelatnici(),
                        P1Specified = true,
                        P2 = 0,
                        P3 = jA.SviDoprinosiGeneracijskaPoduzetnik(),
                        P3Specified = true,
                        P4 = 0,
                        P5 = 0,
                        P6 = 0,
                        P7 = 0
                    },
                    KapitaliziranaStednja = new sKapitaliziranaStednja()
                    {
                        P1 = jA.SviDoprinosiKapitaliziranaDjelatnici(),
                        P1Specified = true,
                        P2 = 0,
                        P3 = jA.SviDoprinosiKapitaliziranaPoduzetnik(),
                        P3Specified = true,
                        P4 = 0,
                        P5 = 0,
                        P6 = 0
                    },
                    ZdravstvenoOsiguranje = new sZdravstvenoOsiguranje()
                    {
                        P1 = jA.ZdravstveoDjelatnici(),
                        P1Specified = true,
                        P2 = 0,
                        P3 = jA.ZdravstvenoPoduzetnici(),
                        P3Specified = true,
                        P4 = 0,
                        P5 = 0,
                        P6 = 0,
                        P7 = 0,
                        P8 = 0,
                        P9 = 0,
                        P10 = 0,
                        P11 = 0,
                        P12 = 0
                    },
                    Zaposljavanje = new sZaposljavanje()
                    {
                        P1 = 0,
                        P2 = 0,
                        P3 = 0,
                        P4 = 0
                    }
                },
                IsplaceniNeoporeziviPrimici = jA.ZbrojNeoporezivo(),
                IsplaceniNeoporeziviPrimiciSpecified = true,
                KamataMO2 = 0,
                UkupniNeoporeziviPrimici = 0,
                NaknadaZaposljavanjeInvalida = new sNaknadaZaposljavanjeInvalida() 
                {
                    P1 = "0",
                    P2 = 0
                }
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
