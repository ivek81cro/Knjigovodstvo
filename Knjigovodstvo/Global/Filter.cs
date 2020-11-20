using System.Windows.Forms;

namespace Knjigovodstvo.Global
{
    class Filter
    {
        public void Filtriraj(string textFilter, DBDataGridView dataGridView1, string column)
        {
            BindingSource bs = new BindingSource
            {
                DataSource = dataGridView1.DataSource,
                Filter = dataGridView1.Columns[column].HeaderText.ToString() + " LIKE '%" + textFilter + "%'"
            };
            dataGridView1.DataSource = bs;
        }
    }
}
