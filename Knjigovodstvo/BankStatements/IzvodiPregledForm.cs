using Knjigovodstvo.Books.PrepareForBalanceSheet;
using Knjigovodstvo.Database;
using Knjigovodstvo.Helpers;
using System;
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
            dataGridViewIzvodi.DataSource = new DataView(dt).ToTable(false, "Redni_broj", "Datum_izvoda");
            dataGridViewIzvodi.Sort(this.dataGridViewIzvodi.Columns["Redni_broj"], ListSortDirection.Descending);
            for (int i = 0; i< dataGridViewIzvodi.Columns.Count; i++)
            {
                dataGridViewIzvodi.Columns[i].HeaderText =
                    new TableHeaderFormat().FormatHeader(dataGridViewIzvodi.Columns[i].HeaderText);
            }

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
                        Iznos = decimal.Parse(prometStavka.IznosPrometa.Iznos),
                        Oznaka = prometStavka.IznosPrometa.Oznaka,
                        Naziv = prometStavka.Naziv,
                        Opis = prometStavka.OpisPlacanja
                    });
            }
        }

        private void OpenIzvodPojedinacnoForm()
        {
            IzvodiPojedinacniForm form = new IzvodiPojedinacniForm(_izvod);
            form.FormClosing += new FormClosingEventHandler(Izvod_FormClosing);
            form.ShowDialog();
        }

        private void Izvod_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoadExistingIzvodi();
        }

        private void OpenIzvodDetails()
        {
            if (dataGridViewIzvodi.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dataGridViewIzvodi.SelectedRows[0];
                int redniBroj = int.Parse(row.Cells["Redni_broj"].Value.ToString());
                _izvod.GetIzvodByRedniBroj(redniBroj);

                dataGridViewStavke.DataSource = _izvod.GetPrometData();

                dataGridViewStavke.Columns[0].Width = (int)(dataGridViewStavke.Width * 0.3);
                dataGridViewStavke.Columns[1].Width = (int)(dataGridViewStavke.Width * 0.3);
            }
        }

        private void DataGridViewIzvodi_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            OpenIzvodDetails();
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

            DeserializeIzvodXml();
        }

        private void ButtonOpenIzvod_Click(object sender, EventArgs e)
        {
            OpenIzvodDetails();
        }

        private void ButtonDeleteIzvod_Click(object sender, EventArgs e)
        {
            new DbDataDelete().DeleteItem(_izvod);
            LoadExistingIzvodi();
        }

        private void ButtonKnjizi_Click(object sender, EventArgs e)
        {
            TemeljnicaPripremaForm form = new TemeljnicaPripremaForm(_izvod, null);
            form.ShowDialog();
        }

        private IzvodiXml _izvodiXml = new IzvodiXml();
        private Izvod _izvod = new Izvod();
        private string _path = "";
    }
}
