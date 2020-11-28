using System.Windows.Forms;

namespace Knjigovodstvo.Settings.SettingsBookkeeping
{
    public partial class PostavkeKnjizenjaPregledForm : Form
    {
        public PostavkeKnjizenjaPregledForm(string knjiga)
        {
            _knjiga = knjiga;
            InitializeComponent();
        }

        private readonly string _knjiga;
    }
}
