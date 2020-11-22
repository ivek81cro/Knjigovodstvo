using Knjigovodstvo.Database;
using Knjigovodstvo.Helpers;
using System;
using System.Data;
using System.Windows.Forms;

namespace Knjigovodstvo.URA
{
    public partial class UraTrosakForm : Form
    {
        public UraTrosakForm()
        {
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
            string filterCondition = $"[Naziv_dobavljaca] LIKE '%{textBoxFilterNaziv.Text}%'";

            if (checkBoxDatumi.Checked)
            {
                filterCondition = $"[Datum_knjizenja]>='{dateTimePickerOd.Value.ToString("yyyy-MM-dd")}' " +
                    $"AND [Datum_knjizenja]<='{dateTimePickerDo.Value.ToString("yyyy-MM-dd")}' " +
                    $"AND [Naziv_dobavljaca] LIKE '%{textBoxFilterNaziv.Text}%'";
            }

           (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = filterCondition;
        }

        private void ButtonFilterDatum_Click(object sender, EventArgs e)
        {
            FilterDataGridView(null, null);
        }
    }
}
