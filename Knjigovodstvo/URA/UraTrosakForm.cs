using Knjigovodstvo.Database;
using Knjigovodstvo.Helpers;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Knjigovodstvo.URA
{
    public partial class UraTrosakForm : Form
    {
        public UraTrosakForm()
        {
            _columns.Add(0, "Datum");
            _columns.Add(1, "Naziv_dobavljaca");
            _columns.Add(2, "Broj_racuna");
            InitializeComponent();
            LoadDatagrid();
        }

        private void LoadDatagrid()
        {
            dataGridView1.DataSource = new DbDataExecProcedure().GetTable(ProcedureNames.Izdvoji_Troskove);
            FixColumnHeaders();
        }

        private void FixColumnHeaders()
        {
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].HeaderText =
                    new TableHeaderFormat().FormatHeader(dataGridView1.Columns[i].HeaderText);
            }
        }

        private Dictionary<int, string> _columns = new Dictionary<int, string>();
    }
}
