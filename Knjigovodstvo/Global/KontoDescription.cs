using Knjigovodstvo.FinancialReports;
using System;
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
            DataTable table = new KontniPlan().GetObjectDataTable($"Konto LIKE '1200%' OR Konto LIKE '2200%'");
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

        public void SetLabelKontoDescription(DBDataGridView dbDataGridView1)
        {
            if (dbDataGridView1.SelectedRows.Count > 0 && _kontniPlan.Count > 0)
            {
                DataGridViewRow row = dbDataGridView1.SelectedRows[0];
                string konto = row.Cells["Konto"].Value.ToString();
                var text = _kontniPlan.Find(k => k.Konto == konto);
                string opis = text == null ? "" : text.Opis;
                labelKontoDescription.Text = opis;
            }
        }

        private List<KontniPlan> _kontniPlan = new List<KontniPlan>();
    }
}
