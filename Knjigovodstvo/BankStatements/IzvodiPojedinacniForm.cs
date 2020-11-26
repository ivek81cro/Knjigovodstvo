using Knjigovodstvo.Database;
using System.Data;
using System.Windows.Forms;

namespace Knjigovodstvo.BankStatements
{
    public partial class IzvodiPojedinacniForm : Form
    {
        public IzvodiPojedinacniForm(IzvodKnjiga izvodKnjiga)
        {
            _izvodKnjiga = izvodKnjiga;
            InitializeComponent();
            FillData();
        }

        private void FillData()
        {
            labelDatumIzvoda.Text = "Datum izvoda: " + _izvodKnjiga.Datum_izvoda;
            labelRedniBroj.Text = "Redni broj:" + _izvodKnjiga.Redni_broj.ToString();
            labelStanjeZavrsno.Text = "Stanje završno " + _izvodKnjiga.Novo_stanje.ToString() + "HRK";

            DataTable dt = new DataTable() 
            {
                Columns = 
                { 
                    { "Naziv", typeof(string) }, 
                    { "Opis", typeof(string) }, 
                    { "Duguje", typeof(decimal) }, 
                    {"Potražuje", typeof(decimal) }
                }
            };

            foreach(var promet in _izvodKnjiga.Promet)
            {
                DataRow row = dt.NewRow();
                row["Naziv"] = promet.Naziv;
                row["Opis"] = promet.Opis;
                row["Duguje"] = promet.Oznaka == "D" ? promet.Iznos : 0;
                row["Potražuje"] = promet.Oznaka == "P" ? promet.Iznos : 0;
                dt.Rows.Add(row);
            }

            dataGridView1.DataSource = dt;
        }


        private void ButtonSpremi_Click(object sender, System.EventArgs e)
        {
            if (new DbDataInsert().InsertData(_izvodKnjiga))
            {
                _izvodKnjiga.GetCurrentId();
            }

            if(_izvodKnjiga.Id != 0)
            {
                foreach( var promet in _izvodKnjiga.Promet)
                {
                    promet.Id_izvod = _izvodKnjiga.Id;
                    new DbDataInsert().InsertData(promet);
                }
            }

            this.Close();
        }
        
        private IzvodKnjiga _izvodKnjiga;
    }
}
