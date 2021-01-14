using Knjigovodstvo.Database;
using Knjigovodstvo.Helpers;
using Knjigovodstvo.URA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Knjigovodstvo.PoreznaUra
{
    public partial class PoreznaUraForm : Form
    {
        public PoreznaUraForm()
        {
            InitializeComponent();
        }

        private void LoadDataGrid()
        {
            string datumOd = dateTimePickerOd.Value.ToString("yyyy-MM-dd");
            string datumDo = dateTimePickerDo.Value.ToString("yyyy-MM-dd");
            _dt = _dbDataGet.GetTable(_uraKnjiga, $"Datum BETWEEN '{datumOd}' AND '{datumDo}'");
            dbDataGridView1.DataSource = _dt;

            FormatColumnHeaders();
        }

        private void FormatColumnHeaders()
        {
            for (int i = 0; i < dbDataGridView1.Columns.Count; i++)
            {
                dbDataGridView1.Columns[i].HeaderText =
                    new TableHeaderFormat().FormatHeader(dbDataGridView1.Columns[i].HeaderText);
            }
        }

        private void GenerateUraObrazac()
        {
            UraObrazacGeneralData gd = new UraObrazacGeneralData()
            {
                Autor = new Autor()
                {
                    Ime = textBoxAutorIme.Text,
                    Prezime = textBoxAutorPrezime.Text
                },
                Razdoblje = new Razdoblje()
                {
                    DatumOd = dateTimePickerOd.Value,
                    DatumDo = dateTimePickerDo.Value
                }
            };
            
            List<sRacun> racuni = new List<sRacun>();
            sRacuniUkupno ukupno = new sRacuniUkupno();
            if (dbDataGridView1.Rows.Count > 1)
            {
                foreach(DataGridViewRow row in dbDataGridView1.Rows)
                {
                    var osnovica0 = decimal.Parse(row.Cells["Porezna_osnovica_0_per"].Value.ToString());
                    racuni.Add(new sRacun()
                    {
                        R1 = row.Cells["Redni_broj"].Value.ToString(),
                        R2 = row.Cells["Broj_racuna"].Value.ToString(),
                        R3 = DateTime.Parse(row.Cells["Datum"].Value.ToString()),
                        R4 = row.Cells["Naziv_dobavljaca"].Value.ToString(),
                        R5 = row.Cells["Sjedište_dobavljaca"].Value.ToString(),
                        R6 = 1,
                        R7 = row.Cells["OIB"].Value.ToString(),
                        R8 = decimal.Parse(row.Cells["Porezna_osnovica_5_per"].Value.ToString()),
                        R9 = decimal.Parse(row.Cells["Porezna_osnovica_13_per"].Value.ToString()),
                        R10 = decimal.Parse(row.Cells["Porezna_osnovica_25_per"].Value.ToString()),
                        R11 = decimal.Parse(row.Cells["Iznos_s_porezom"].Value.ToString()) - osnovica0,
                        R12 = decimal.Parse(row.Cells["Ukupni_pretporez"].Value.ToString()),
                        R13 = decimal.Parse(row.Cells["Pretporez_za_T5"].Value.ToString()),
                        R14 = 0,
                        R15 = decimal.Parse(row.Cells["Pretporez_za_T13"].Value.ToString()),
                        R16 = 0,
                        R17 = decimal.Parse(row.Cells["Pretporez_za_T25"].Value.ToString()),
                        R18 = 0
                    });
                }

                foreach (sRacun racun in racuni)
                {
                    ukupno.U8 += racun.R8;
                    ukupno.U9 += racun.R9;
                    ukupno.U10 += racun.R10;
                    ukupno.U11 += racun.R11;
                    ukupno.U12 += racun.R12;
                    ukupno.U13 += racun.R13;
                    ukupno.U14 += racun.R14;
                    ukupno.U15 += racun.R15;
                    ukupno.U16 += racun.R16;
                    ukupno.U17 += racun.R17;
                    ukupno.U18 += racun.R18;

                }
            }
            _obrazacURA.GenerateForm(gd, racuni, ukupno);
            SaveToXmlFile();
        }

        private bool SaveToXmlFile()
        {
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
                XmlSerializer x = new XmlSerializer(_obrazacURA.GetSerializable().GetType());
                x.Serialize(txtWriter, _obrazacURA.GetSerializable());
                txtWriter.Close();

                return true;
            }
            else
            {
                MessageBox.Show("Nije odabrana datoteka za spremanje", "Spremanje XML datoteke", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }
        }

        private void ButtonPripremi_Click(object sender, EventArgs e)
        {
            LoadDataGrid();
        }

        private void ButtonKreirajXml_Click(object sender, EventArgs e)
        {
            GenerateUraObrazac();
        }

        private DbDataGet _dbDataGet = new DbDataGet();
        private KnjigaUra _uraKnjiga = new KnjigaUra();
        private DataTable _dt = new DataTable();
        private ObrazacUra _obrazacURA = new ObrazacUra();
        private string _path = "";
    }
}
