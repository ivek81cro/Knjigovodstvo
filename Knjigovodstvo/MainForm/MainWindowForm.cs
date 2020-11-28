using Knjigovodstvo.BankStatements;
using Knjigovodstvo.City;
using Knjigovodstvo.Employee;
using Knjigovodstvo.FinancialReports;
using Knjigovodstvo.Gui;
using Knjigovodstvo.IRA;
using Knjigovodstvo.JoppdDocument;
using Knjigovodstvo.Partners;
using Knjigovodstvo.Payroll;
using Knjigovodstvo.Settings;
using Knjigovodstvo.URA;
using System;
using System.Windows.Forms;

namespace Knjigovodstvo.MainForm
{
    public partial class MainWindowForm : Form
    {
        public MainWindowForm()
        {
            InitializeComponent();
        }

        private void ShowNewFormKomitent(object sender, EventArgs e)
        {
            string formName = ChildWindowName.KomitentNew.ToString();
            if (_isOpen.Check(MdiChildren, formName))
            {
                Form f = _isOpen.GetChild(MdiChildren, formName);
                f.Focus();
            }
            else
            {
                _openForm.Open(new KomitentUnosForm(), this);
            }
        }

        private void ShowNewFormPostavke(object sender, EventArgs e)
        {
            string formName = ChildWindowName.PostavkeTablicaForm.ToString();
            if (_isOpen.Check(MdiChildren, formName))
            {
                Form f = _isOpen.GetChild(MdiChildren, formName);
                f.Focus();
            }
            else
            {
                _openForm.Open(new PostavkePlaceTablicaForm(), this);
                
            }
        }

        private void ShowNewFormPartneri(object sender, EventArgs e)
        {
            string formName = ChildWindowName.PartneriTableForm.ToString();
            if (_isOpen.Check(MdiChildren, formName))
            {
                Form f = _isOpen.GetChild(MdiChildren, formName);
                f.Focus();
            }
            else
            {
                _openForm.Open(new PartneriTableForm(), this);
            }
        }

        private void ShowNewFormZaposlenici(object sender, EventArgs e)
        {
            string formName = ChildWindowName.ZaposleniciTableForm.ToString();
            if (_isOpen.Check(MdiChildren, formName))
            {
                Form f = _isOpen.GetChild(MdiChildren, formName);
                f.Focus();
            }
            else
            {
                _openForm.Open(new ZaposleniciTableForm(), this);
            }
        }

        private void ShowNewFormGradovi(object sender, EventArgs e)
        {
            string formName = ChildWindowName.GradoviTableForm.ToString();
            if (_isOpen.Check(MdiChildren, formName))
            {
                Form f = _isOpen.GetChild(MdiChildren, formName);
                f.Focus();
            }
            else
            {
                _openForm.Open(new GradoviTableForm(), this);
            }
        }

        private void ShowNewFormPregledPlaca(object sender, EventArgs e)
        {
            string formName = ChildWindowName.PlacaTableForm.ToString();
            if (_isOpen.Check(MdiChildren, formName))
            {
                Form f = _isOpen.GetChild(MdiChildren, formName);
                f.Focus();
            }
            else
            {
                _openForm.Open(new PlacaTableForm(), this);
            }
        }

        private void ShowNewFormObracunPlaca(object sender, EventArgs e)
        {
            string formName = ChildWindowName.PlacaObracunForm.ToString();
            if (_isOpen.Check(MdiChildren, formName))
            {
                Form f = _isOpen.GetChild(MdiChildren, formName);
                f.Focus();
            }
            else
            {
                _openForm.Open(new PlacaObracunForm(), this);
            }
        }

        private void ShowNewFormPlacaJoppdForm(object sender, EventArgs e)
        {
            string formName = ChildWindowName.JoppdPlacaForm.ToString();
            if (_isOpen.Check(MdiChildren, formName))
            {
                Form f = _isOpen.GetChild(MdiChildren, formName);
                f.Focus();
            }
            else
            {
                _openForm.Open(new JoppdPlacaForm(), this);
            }
        }
        private void ShowNewFormUraPrimkaForm(object sender, EventArgs e)
        {
            string formName = ChildWindowName.UraPrimkaForm.ToString();
            if (_isOpen.Check(MdiChildren, formName))
            {
                Form f = _isOpen.GetChild(MdiChildren, formName);
                f.Focus();
            }
            else
            {
                _openForm.Open(new UraPrimkaForm(), this);
            }
        }

        private void ShowNewFormUraKnjigaPregled(object sender, EventArgs e)
        {
            string formName = ChildWindowName.UraKnjigaForm.ToString();
            if (_isOpen.Check(MdiChildren, formName))
            {
                Form f = _isOpen.GetChild(MdiChildren, formName);
                f.Focus();
            }
            else
            {
                _openForm.Open(new UraKnjigaForm(), this);
            }
        }

        private void ShowNewFormIraKnjigaPregled(object sender, EventArgs e)
        {
            string formName = ChildWindowName.IraKnjigaForm.ToString();
            if (_isOpen.Check(MdiChildren, formName))
            {
                Form f = _isOpen.GetChild(MdiChildren, formName);
                f.Focus();
            }
            else
            {
                _openForm.Open(new IraKnjigaForm(), this);
            }
        }

        private void ShowNewFormPregledIzvodaForm(object sender, EventArgs e)
        {
            string formName = ChildWindowName.IzvodiPregledForm.ToString();
            if (_isOpen.Check(MdiChildren, formName))
            {
                Form f = _isOpen.GetChild(MdiChildren, formName);
                f.Focus();
            }
            else
            {
                _openForm.Open(new IzvodiPregledForm(), this);
            }
        }

        private void ShowNewFormKontniPlanPregledForm(object sender, EventArgs e)
        {
            string formName = ChildWindowName.KontniPlanPregledForm.ToString();
            if (_isOpen.Check(MdiChildren, formName))
            {
                Form f = _isOpen.GetChild(MdiChildren, formName);
                f.Focus();
            }
            else
            {
                _openForm.Open(new KontniPlanPregledForm(), this);
            }
        }

        private void ShowDialogIzracunPlace(object sender, EventArgs e)
        {
            PlacaIzracunForm dialog = new PlacaIzracunForm();
            dialog.ShowDialog();
        }

        private void ShowDialogDodaci(object sender, EventArgs e)
        {
            DodaciUnosForm dialog = new DodaciUnosForm();
            dialog.ShowDialog();
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

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private readonly IsChildOpen _isOpen = new IsChildOpen();
        private readonly OpenChildForm _openForm = new OpenChildForm();
    }
}
