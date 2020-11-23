using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Knjigovodstvo.Global
{
    public partial class KnjigaFilter : UserControl
    {
        /// <summary>
        /// Filters for URA and IRA datagridview's.
        /// Dictionary key 0: date column title, key 1: name column title that will be filtered
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="columns">key1:Name column title, key2:Date column title</param>
        public KnjigaFilter(DBDataGridView dgv, Dictionary<int, string> columns)
        {
            InitializeComponent();
            _dgv = dgv;
            _columns = columns;
        }

        public KnjigaFilter()
        {

        }

        void CheckValidRange(object sender, EventArgs e)
        {
            if (dateTimePickerOd.Value > dateTimePickerDo.Value)
            {
                MessageBox.Show(
                    "Početni datum mora biti manji ili jednak završnom.",
                    "Upozorenje",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                dateTimePickerDo.Value = dateTimePickerOd.Value;
            }
        }

        void CheckBoxDatumi_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxDatumi.Checked)
            {
                dateTimePickerOd.Enabled = true;
                dateTimePickerDo.Enabled = true;
            }
            else
            {
                dateTimePickerOd.Enabled = false;
                dateTimePickerDo.Enabled = false;
            }
        }

        void FilterDataGridView(object sender, KeyEventArgs e)
        {
            string filterCondition = $"[{_columns[1]}] LIKE '%{textBoxFilterNaziv.Text}%'";

            if (checkBoxDatumi.Checked)
            {
                filterCondition = $"[{_columns[0]}]>='{dateTimePickerOd.Value.ToString("yyyy-MM-dd")}' " +
                    $"AND [{_columns[0]}]<='{dateTimePickerDo.Value.ToString("yyyy-MM-dd")}' " +
                    $"AND [{_columns[1]}] LIKE '%{textBoxFilterNaziv.Text}%'";
            }

            (_dgv.DataSource as DataTable).DefaultView.RowFilter = filterCondition;
        }

        private void ButtonFilterDatum_Click(object sender, EventArgs e)
        {
            FilterDataGridView(null, null);
        }

        private DBDataGridView _dgv;
        private Dictionary<int, string> _columns;
    }
}
