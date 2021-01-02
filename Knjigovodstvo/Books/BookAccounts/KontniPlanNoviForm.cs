using Knjigovodstvo.Database;
using Knjigovodstvo.Validators;
using System;
using System.Windows.Forms;

namespace Knjigovodstvo.FinancialReports
{
    public partial class KontniPlanNoviForm : Form
    {
        public KontniPlanNoviForm()
        {
            InitializeComponent();
        }

        private void ButtonSpremi_Click(object sender, EventArgs e)
        {
            if (textBoxKonto.Text.Length < 9 && _intValidator.Check(textBoxKonto.Text))
                _kontniPlan.Konto = textBoxKonto.Text;

            if (textBoxOpis.Text.Length > 5)
                _kontniPlan.Opis = textBoxOpis.Text;

            if (_kontniPlan.Opis == "" || _kontniPlan.Konto == "")
            {
                MessageBox.Show("Provjerite unešene podatke\n" +
                    "Konto mora imati minimalno jedan broj, maksimalno 8 brojeva,\n" +
                    "opis mora sadržavati minimalno 5 znakova.",
                    "Upozorenje",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                if(!_kontniPlan.ExistsKonto(_kontniPlan.Konto))
                new DbDataInsert().InsertData(_kontniPlan);
                _kontniPlan = new KontniPlan();
                textBoxKonto.Clear();
                textBoxOpis.Clear();
            }
        }

        private KontniPlan _kontniPlan = new KontniPlan();
        private readonly IntValidator _intValidator = new IntValidator();
    }
}
