using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Knjigovodstvo.GeneralData.WaitForm
{
    public partial class WaitDialog : Form
    {
        public WaitDialog(Action worker)
        {
            InitializeComponent();
            if (worker == null)
                throw new ArgumentNullException();
            Worker = worker;
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
