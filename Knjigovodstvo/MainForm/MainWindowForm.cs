using Knjigovodstvo.Employee;
using Knjigovodstvo.Gui;
using Knjigovodstvo.Partners;
using Knjigovodstvo.Settings;
using System;
using System.Windows.Forms;

namespace Knjigovodstvo.MainForm
{
    public partial class MainWindowForm : Form
    {
        private int childFormNumber = 0;

        public MainWindowForm()
        {
            InitializeComponent();
        }

        private void ShowNewFormKomitent(object sender, EventArgs e)
        {
            string formName = ChildWindowName.Komitent.ToString();
            if (_isOpen.Check(MdiChildren, formName))
            {
                Form f = _isOpen.getChild(MdiChildren, formName);
                f.Focus();
            }
            else
            {
                _openForm.Open(new KomitentUnosForm(), this);
            }
        }

        private void ShowNewFormPostavke(object sender, EventArgs e)
        {
            string formName = ChildWindowName.Postavke.ToString();
            if (_isOpen.Check(MdiChildren, formName))
            {
                Form f = _isOpen.getChild(MdiChildren, formName);
                f.Focus();
            }
            else
            {
                _openForm.Open(new PostavkeTablicaForm(), this);
                
            }
        }

        private void ShowNewFormPartneri(object sender, EventArgs e)
        {
            string formName = ChildWindowName.Partneri.ToString();
            if (_isOpen.Check(MdiChildren, formName))
            {
                Form f = _isOpen.getChild(MdiChildren, formName);
                f.Focus();
            }
            else
            {
                _openForm.Open(new PartneriTableForm(), this);
            }
        }

        private void ShowNewFormZaposlenici(object sender, EventArgs e)
        {
            string formName = ChildWindowName.Zaposlenici.ToString();
            if (_isOpen.Check(MdiChildren, formName))
            {
                Form f = _isOpen.getChild(MdiChildren, formName);
                f.Focus();
            }
            else
            {
                _openForm.Open(new ZaposleniciTableForm(), this);
            }
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        IsChildOpen _isOpen = new IsChildOpen();
        OpenChildForm _openForm = new OpenChildForm();
    }
}
