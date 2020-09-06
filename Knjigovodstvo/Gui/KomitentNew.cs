using Knjigovodstvo.Models;
using System;
using System.Windows.Forms;

namespace Knjigovodstvo.Gui
{
    public partial class KomitentNew : Form
    {
        public KomitentNew()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {

        }

        private void buttonSelectCity_Click(object sender, EventArgs e)
        {
            CityNew city = new CityNew();
            Opcina c = city.ShowDialogValue();

            if (c != null && c.ValidateData() == FormError.None)
            {
                textBoxCity.Text = c.Naziv;
                textBoxPost.Text = c.Posta;
            }
        }
    }
}
