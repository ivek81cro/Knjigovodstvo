using Knjigovodstvo.Books.PrepareForBalanceSheet;
using Knjigovodstvo.Database;
using Knjigovodstvo.Helpers;
using Knjigovodstvo.Settings;
using Knjigovodstvo.Settings.SettingsBookkeeping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Knjigovodstvo.BankStatements
{
    public partial class IzvodiPregledForm : Form
    {
        public IzvodiPregledForm()
        {
            InitializeComponent();
            LoadExistingIzvodi();
        }

        private void LoadExistingIzvodi()
        {
            DataTable dt = new DbDataGet().GetTable(_izvod);
            dataGridViewIzvodi.DataSource = new DataView(dt).ToTable(false, "Redni_broj", "Datum_izvoda", "Knjizen");
            dataGridViewIzvodi.Sort(this.dataGridViewIzvodi.Columns["Redni_broj"], ListSortDirection.Descending);
            for (int i = 0; i < dataGridViewIzvodi.Columns.Count; i++)
            {
                dataGridViewIzvodi.Columns[i].HeaderText =
                    new TableHeaderFormat().FormatHeader(dataGridViewIzvodi.Columns[i].HeaderText);
            }
            CustomiseColumnWidthIzvodi();
        }

        private void DeserializeIzvodXml()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var encoding = Encoding.GetEncoding("windows-1250");
            StreamReader reader = new StreamReader(_path, encoding);
            XmlSerializer x = new XmlSerializer(_izvodiXml.GetType());
            _izvodiXml = (IzvodiXml)x.Deserialize(reader);
            reader.Close();

            CreateIzvodKnjigaElement();
        }

        private void CreateIzvodKnjigaElement()
        {
            _izvod = new Izvod
            {
                Datum_izvoda = DateTime
                .ParseExact(_izvodiXml.Izvod.DatumIzvoda, ("yyyyMMdd"), CultureInfo.InvariantCulture)
                .ToString("yyyy-MM-dd"),
                Redni_broj = int.Parse(_izvodiXml.Izvod.RedniBroj),
                Suma_potrazna = decimal.Parse(_izvodiXml.Izvod.Sekcije.Sekcija.PStrana.UkupnaSuma),
                Suma_dugovna = decimal.Parse(_izvodiXml.Izvod.Sekcije.Sekcija.DStrana.UkupnaSuma),
                Stanje_prethodnog_izvoda = decimal.Parse(_izvodiXml.Izvod.Sekcije.Sekcija.PrethodnoStanje),
                Novo_stanje = decimal.Parse(_izvodiXml.Izvod.Sekcije.Sekcija.NovoStanje)
            };

            CreatePrometElements();

            OpenIzvodPojedinacnoForm();
        }

        private void CreatePrometElements()
        {
            foreach(var prometStavka in _izvodiXml.Izvod.Sekcije.Sekcija.Prometi.Promet)
            {
                _izvod.Promet.Add(
                    new IzvodPromet()
                    {
                        Dugovna = prometStavka.IznosPrometa.Oznaka == "D" ? decimal.Parse(prometStavka.IznosPrometa.Iznos) : 0,
                        Potrazna = prometStavka.IznosPrometa.Oznaka == "P" ? decimal.Parse(prometStavka.IznosPrometa.Iznos) : 0,
                        Oznaka = prometStavka.IznosPrometa.Oznaka,
                        Naziv = prometStavka.Naziv,
                        Opis = prometStavka.OpisPlacanja
                    });
            }
        }

        private void OpenIzvodPojedinacnoForm()
        {
            IzvodiPojedinacniForm form = new IzvodiPojedinacniForm(_izvod);
            form.ShowDialog();
            LoadExistingIzvodi();
        }

        private void OpenIzvodDetails()
        {
            if (dataGridViewIzvodi.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dataGridViewIzvodi.SelectedRows[0];
                int redniBroj = int.Parse(row.Cells["Redni_broj"].Value.ToString());
                _izvod.GetIzvodByRedniBroj(redniBroj);

                dbDataGridViewStavke.DataSource = _izvod.GetPrometData();
                CustomiseColumnWidthDetalji();
                labelDuguje.Text = "Duguje: " + _izvod.Suma_dugovna.ToString();
                labelPortazuje.Text = "Potražuje: " + _izvod.Suma_potrazna.ToString();
                labelStanjePocetno.Text = "Početno stanje: " + _izvod.Stanje_prethodnog_izvoda.ToString();
                labelStanjeZavrsno.Text = "Završno stanje: " + _izvod.Novo_stanje.ToString();
            }
        }

        private void DataGridViewIzvodi_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            OpenIzvodDetails();
            buttonKnjizi.Enabled = true;
        }

        private void ClearDataGridView()
        {
            dbDataGridViewStavke.DataSource = null;
            dbDataGridViewStavke.Rows.Clear();
        }

        private void DataGridViewStavke_SelectionChanged(object sender, EventArgs e)
        {
            if (dbDataGridViewStavke.SelectedRows.Count > 0)
                kontoDescription.SetLabelKontoDescription(dbDataGridViewStavke.SelectedRows[0]);
        }
        private List<KontoParovi> GetPartnerKontoList()
        {
            List<KontoParovi> parovi = new KontoParovi(BookNames.Izvodi).GetParoviList();
            return parovi;
        }

        private void ButtonUcitajIzvod_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Filter = "XML file|*.xml",
                Title = "Otvori xml datoteku izvoda"
            };
            openFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (openFileDialog1.FileName != "")
            {
                _path = openFileDialog1.FileName;
            }
            if (_path != "")
                DeserializeIzvodXml();

        }

        private void ButtonOpenIzvod_Click(object sender, EventArgs e)
        {
            OpenIzvodDetails();
        }

        private void ButtonDeleteIzvod_Click(object sender, EventArgs e)
        {
            if (_izvod.Knjizen && MessageBox.Show("Izvod je knjižen, želite li svejedno obrisati izvod?"
                , "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _izvod.DeleteIzvod();
            }
            else
                _izvod.DeleteIzvod();

            ClearDataGridView();
            LoadExistingIzvodi();
        }

        private void ButtonKnjizi_Click(object sender, EventArgs e)
        {
            var postavke = new List<PostavkeKnjizenja>
            {
                new PostavkeKnjizenja() { Knjiga = BookNames.Izvodi.ToString() }
            };
            List<KontoParovi> parovi = GetPartnerKontoList();
            using TemeljnicaPripremaForm form = new TemeljnicaPripremaForm(_izvod, postavke, parovi);
            form.ShowDialog();
            //TODO implement check if saved to books before setting true
            if (form.Knjizeno)
            {
                _izvod.Knjizen = true;
                _izvod.UpdateData();
                LoadExistingIzvodi();
                _izvod = new Izvod();
                ClearDataGridView();
                buttonKnjizi.Enabled = false;
            }
        }

        private IzvodiXml _izvodiXml = new IzvodiXml();
        private Izvod _izvod = new Izvod();
        private string _path = "";
    }
}
