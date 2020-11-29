using Knjigovodstvo.Database;
using Knjigovodstvo.FinancialReports;
using Knjigovodstvo.Helpers;
using Knjigovodstvo.Interface;
using Knjigovodstvo.URA;
using Knjigovodstvo.Validators;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Knjigovodstvo.Settings.SettingsBookkeeping
{
    public partial class PostavkeKnjizenjaPregledForm : Form
    {
        public PostavkeKnjizenjaPregledForm(string knjiga)
        {
            _knjiga = knjiga;
            InitializeComponent();
            LoadData();
            PopulateComboBoxStupac();
        }

        private void LoadData()
        {
            dbDataGridView1.DataSource = new DataView(
                new DbDataGet().GetTable(_postavkeKnjizenja, $"Knjiga='{_knjiga}'"))
                .ToTable(false, "Naziv_stupca", "Konto", "Strana");

            dbDataGridView1.Columns[0].Width = (int)(dbDataGridView1.Width * 0.3);
            dbDataGridView1.Columns[1].Width = (int)(dbDataGridView1.Width * 0.3);
        }

        private void PopulateComboBoxStupac()
        {
            GenericPropertyFinder<IDbObject> property = new GenericPropertyFinder<IDbObject>();
            IEnumerable<List<string>> obj = property.PrintTModelPropertyAndValue(_uraKnjiga);

            comboBoxStupac.DataSource = obj.ElementAt(0);
        }

        private void textBoxKonto_MouseClick(object sender, MouseEventArgs e)
        {
            KontniPlanPregledForm form = new KontniPlanPregledForm();
            form.ShowDialog();
        }

        private void buttonSpremi_Click(object sender, EventArgs e)
        {
            string konto = textBoxKonto.Text;
            if(new IntValidator().Check(konto) 
                && comboBoxStrana.Text != ""
                && comboBoxStupac.Text != "")
            {
                if (_kontniPlan.ExistsKonto(konto))
                {
                    _postavkeKnjizenja.Konto = konto;
                    _postavkeKnjizenja.Naziv_stupca = comboBoxStupac.Text;
                    _postavkeKnjizenja.Strana = comboBoxStrana.Text;
                    
                    new DbDataInsert().InsertData(_postavkeKnjizenja);
                }
                else
                {
                    MessageBox.Show("Nepostojeći konto, kreirajte novi.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Provjerite odabrane i unešene podatke", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            LoadData();
        }

        private readonly string _knjiga;
        private PostavkeKnjizenja _postavkeKnjizenja = new PostavkeKnjizenja() { Knjiga="Ura" };
        private UraKnjiga _uraKnjiga = new UraKnjiga();
        private KontniPlan _kontniPlan = new KontniPlan();
    }
}
