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
        PlacaPregledForm,
        PlacaObracunForm,
        JoppdPlacaForm,
        UraPrimkaReproForm,
        UraKnjigaForm,
        IraKnjigaForm,
        IzvodiPregledForm,
        KontniPlanPregledForm,
        TemeljnicePregledForm,
        DodatakObracun,
        PorezPdvForm,
        OsnovnoSredstvoForm,
        DnevnikKnjizenjaForm
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

        public Form GetChild(Form[] mdiChildren, string titleForm)
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
