using Knjigovodstvo.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Knjigovodstvo.Employee
{
    public partial class ZaposleniciTableForm : Form
    {
        public ZaposleniciTableForm()
        {
            InitializeComponent();
            LoadDatagrid();
        }

        private void LoadDatagrid()
        {
            dbDataGridView1.DataSource = _zaposlenik.GetZaposlenikDataTable();
            for (int i = 0; i < dbDataGridView1.Columns.Count; i++)
            {
                dbDataGridView1.Columns[i].HeaderText =
                    new TableHeaderFormat().FormatHeader(dbDataGridView1.Columns[i].HeaderText);
            }
            dbDataGridView1.Columns["Id"].Visible = false;
            dbDataGridView1.Columns["Id1"].Visible = false;
        }

        private void ButtonNewZaposlenik_Click(object sender, EventArgs e)
        {
            ZaposlenikUnosForm form = new ZaposlenikUnosForm();
            form.ShowDialog();
            LoadDatagrid();
        }

        private void ButtonEditZaposlenik_Click(object sender, EventArgs e)
        {
            _zaposlenik.Id = int.Parse(dbDataGridView1.SelectedRows[0].Cells["Id"].Value.ToString());
            _zaposlenik.GetZaposlenikById();
            ZaposlenikUnosForm pn = new ZaposlenikUnosForm();
            pn.EditZaposlenik(_zaposlenik);
            LoadDatagrid();
        }

        private void ButtonDeleteZaposlenik_Click(object sender, EventArgs e)
        {
            _zaposlenik.Id = int.Parse(dbDataGridView1.SelectedRows[0].Cells["Id"].Value.ToString());
            _zaposlenik.GetZaposlenikById();
            DialogResult result = MessageBox.Show("Da li ste sigurni da želite obrisati odabranog zaposlenika?",
                "Brisanje reda", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (_zaposlenik.DeleteZaposlenik())
                    MessageBox.Show("Podatak obrisan", "Brisanje podatka", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDatagrid();
            }
        }

        private void TextBoxFilterZaposlenik_TextChanged(object sender, EventArgs e)
        {
            (dbDataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                $"Prezime LIKE '{textBoxZaposlenikFilter.Text}%' OR Prezime LIKE '% {textBoxZaposlenikFilter.Text}%'";
        }

        private readonly Zaposlenik _zaposlenik = new Zaposlenik();
        private List<Zaposlenik> _zaposlenikList = new List<Zaposlenik>();
    }
}
