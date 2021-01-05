using System;
using System.Windows.Forms;

namespace Knjigovodstvo.Books.PrepareForBalanceSheet
{
    public partial class TemeljnicaPripremaDatumKnjizenja : Form
    {
        public TemeljnicaPripremaDatumKnjizenja()
        {
            InitializeComponent();
            SetDate();
        }

        private void ButtonOdaberi_Click(object sender, EventArgs e)
        {
            SetDate();
            Close();
        }

        private void SetDate()
        {
            Datum = dateTimePickerDatum.Value.ToString("yyyy-MM-dd");
        }

        public string Datum { get; set; }

    }
}
