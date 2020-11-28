using Knjigovodstvo.Database;
using System;
using System.Windows.Forms;

namespace Knjigovodstvo.Settings.SettingsBookkeeping
{
    public partial class PostavkeKnjizenjaPregledForm : Form
    {
        public PostavkeKnjizenjaPregledForm(string knjiga)
        {
            _knjiga = knjiga;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dbDataGridView1.DataSource = new DbDataGet().GetTable(_postavkeKnjizenja, $"Knjiga='{_knjiga}'");
        }

        private readonly string _knjiga;
        private PostavkeKnjizenja _postavkeKnjizenja = new PostavkeKnjizenja();
    }
}
