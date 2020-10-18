using Knjigovodstvo.Models;

namespace Knjigovodstvo.Settings
{
    class Postavke : IDbObject
    {
        public FormError ValidateData()
        {
            if (Vrijednost.ToString() == "")
            {
                return FormError.Prazno;
            }

            return FormError.None;
        }
        public int Id { get; set; } = 0;
        public string Naziv { get; set; } = "";
        public string Vrsta { get; set; } = "";
        public float Vrijednost { get; set; } = 0;
    }    
}
