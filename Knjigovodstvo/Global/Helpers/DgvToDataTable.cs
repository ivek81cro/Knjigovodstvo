using System.Data;
using System.Windows.Forms;

namespace Knjigovodstvo.Global.Helpers
{
    public class DgvToDataTable
    {
        public DataTable ToDataTable(DataGridView dataGridView)
        {
            var dt = new DataTable();
            foreach (DataGridViewColumn col in dataGridView.Columns)
            {
                dt.Columns.Add(col.Name);
            }
            var cell = new object[dataGridView.Columns.Count];
            foreach (DataGridViewRow dataGridViewRow in dataGridView.Rows)
            {
                for (int i = 0; i < dataGridViewRow.Cells.Count; i++)
                {
                    cell[i] = dataGridViewRow.Cells[i].Value;
                }
                dt.Rows.Add(cell);
            }
            return dt;
        }
    }
}
