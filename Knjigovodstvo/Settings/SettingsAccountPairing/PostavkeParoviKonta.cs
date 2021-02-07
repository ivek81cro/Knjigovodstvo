using Knjigovodstvo.FinancialReports;
using System;
using System.Data;
using System.Windows.Forms;

namespace Knjigovodstvo.Settings 
{ 
    public partial class PostavkeParoviKonta : Form
    {
        public PostavkeParoviKonta(string knjiga)
        {
            InitializeComponent();
            _book = (BookNames)Enum.Parse(typeof(BookNames), knjiga);
            Parovi = new KontoParovi(_book);
            LoadDataGrid();
        }

        public void SetControls()
        {
            textBoxNaziv.Text = Parovi.Naziv;
            textBoxOpis.Text = Parovi.Opis;
        }

        private void LoadDataGrid()
        {
            DataTable dt = Parovi.GetKontoParoviDataTable($"Knjiga='{_book}'");
            dt.Columns.Add("Konto", typeof(string));
            foreach(DataRow row in dt.Rows)
            {
                KontniPlan kp = new KontniPlan();
                row["Konto"] = kp.GetKontoById(int.Parse(row["Id_Konto"].ToString()));
            }
            dbDataGridView1.DataSource = dt;
            dbDataGridView1.Columns["Id"].Visible = false;
            dbDataGridView1.Columns["Id_Konto"].Visible = false;
            dbDataGridView1.Columns["Knjiga"].Visible = false;
        }

        private void ButtonPostaviKonto_Click(object sender, EventArgs e)
        {
            KontniPlanPregledForm f = new KontniPlanPregledForm();
            f.ShowDialog();
            textBoxKonto.Text = f.KontoBroj;
            Parovi.Id_Konto = f.Id_Konto;
        }

        private void ButtonSpremi_Click(object sender, EventArgs e)
        {
            KontoParovi p = new KontoParovi(_book)
            {
                Id_Konto = Parovi.Id_Konto,
                Naziv = textBoxNaziv.Text,
                Opis = textBoxOpis.Text
            };

            if (p.InsertData())
            {
                MessageBox.Show("Uspješno spremljeno");
                LoadDataGrid();
            }

            Close();
        }

        private BookNames _book;

        public KontoParovi Parovi { get; set; }
    }
}
