using System.Windows.Forms;

namespace Knjigovodstvo.MainForm
{
    class OpenChildForm
    {
        public void Open(Form f, Form p)
        {
            f.MdiParent = p;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }
    }
}
