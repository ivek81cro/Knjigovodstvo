using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Knjigovodstvo.MainForm
{
    public enum ChildWindowName
    {
        KomitentNew,
        PostavkeTablicaForm,
        ZaposleniciTableForm,
        PartneriTableForm,
        GradoviTableForm,
        PlacaTableForm,
    }
    public class IsChildOpen
    {
        public bool Check(Form[] mdiChildren, string titleForm)
        {
            foreach(Form f in mdiChildren)
            {
                if(f.Name.ToString() == titleForm)
                {
                    f.Focus();
                    return true;
                }
            }
            return false;
        }

        public Form getChild(Form[] mdiChildren, string titleForm)
        {
            foreach (Form f in mdiChildren)
            {
                if (f.Name.ToString() == titleForm)
                {
                    return f;
                }
            }
            return null;
        }
    }
}
