using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Knjigovodstvo.GeneralData.WaitForm
{
    public enum SplashMessages
    {
        Učitavanje,
        Spremanje,
        Brisanje
    }
    public partial class WaitDialog : Form
    {
        public WaitDialog(Action worker, SplashMessages message)
        {
            InitializeComponent();
            if (worker == null)
                throw new ArgumentNullException();
            Worker = worker;

            label1.Text = "Molim sačekati\n" + message.ToString() + " podataka";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //Start new thread to run wait form dialog
            Task.Factory.StartNew(Worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public Action Worker { get; set; }
    }
}
