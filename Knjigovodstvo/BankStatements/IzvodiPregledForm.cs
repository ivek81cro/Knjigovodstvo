using System;
using System.Data;
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

        private void buttonUcitajIzvod_Click(object sender, EventArgs e)
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
            _izvodi = (Izvodi)x.Deserialize(reader);
            reader.Close();
            //Read xml file into datagridview
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(_path);
            DataTable dt = new DataTable();
            dataGridView1.DataSource = dataSet.Tables[7];
        }

        private Izvodi _izvodi = new Izvodi();
        private string _path = "";
    }
}
