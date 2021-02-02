using Knjigovodstvo.FinancialReports;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Knjigovodstvo.Global
{
    public partial class KontoDescription : UserControl
    {
        public KontoDescription()
        {
            InitializeComponent();
            LoadListKontniPlan();
        }

        private void LoadListKontniPlan()
        {
            DataTable table = new KontniPlan().GetObjectDataTable();
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    _kontniPlan.Add(new KontniPlan()
                    {
                        Konto = row["Konto"].ToString(),
                        Opis = row["Opis"].ToString()
                    });
                }
            }
        }

        public void SetLabelKontoDescription(DataGridViewRow row)
        {
            string konto = row.Cells["Konto"].Value.ToString();
            var text = _kontniPlan.Find(k => k.Konto == konto);
            string opis = text == null ? "" : text.Opis;
            labelKontoDescription.Text = "Opis konta: " + opis;
        }

        private readonly List<KontniPlan> _kontniPlan = new List<KontniPlan>();
    }
}
