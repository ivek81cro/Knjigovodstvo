using System;
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

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var encoding = Encoding.GetEncoding("windows-1250");
            StreamReader reader = new StreamReader(_path, encoding);
            XmlSerializer x = new XmlSerializer(_izvodi.GetType());
            _izvodi = (IzvodiXml)x.Deserialize(reader);
            CreateIzvodKnjigaElement();
            reader.Close();
            //Read xml file into datagridview
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(_path);
            dataGridView1.DataSource = dataSet.Tables[7];
        }

        private void CreateIzvodKnjigaElement()
        {
            _izvodKnjiga.Datum_izvoda = DateTime.ParseExact(_izvodi.Izvod.DatumIzvoda, ("yyyyMMdd"), CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            _izvodKnjiga.Redni_broj = int.Parse(_izvodi.Izvod.RedniBroj);
            _izvodKnjiga.Suma_potrazna = decimal.Parse(_izvodi.Izvod.Sekcije.Sekcija.PStrana.UkupnaSuma);
            _izvodKnjiga.Stanje_prethodnog_izvoda = decimal.Parse(_izvodi.Izvod.Sekcije.Sekcija.PrethodnoStanje);
            _izvodKnjiga.Novo_stanje = decimal.Parse(_izvodi.Izvod.Sekcije.Sekcija.NovoStanje);

            CreatePrometElements();

            OpenIzvodPojedinacnoForm();
        }

        private void CreatePrometElements()
        {
            foreach(var prometStavka in _izvodi.Izvod.Sekcije.Sekcija.Prometi.Promet)
            {
                _izvodKnjiga.Promet.Add(
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
            IzvodiPojedinacniForm form = new IzvodiPojedinacniForm(_izvodKnjiga);
            form.ShowDialog();
        }

        private IzvodiXml _izvodi = new IzvodiXml();
        private IzvodKnjiga _izvodKnjiga = new IzvodKnjiga();
        private string _path = "";
    }
}
