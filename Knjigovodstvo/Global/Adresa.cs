using Knjigovodstvo.City;
using Knjigovodstvo.Interface;

namespace Knjigovodstvo.Global
{
    public class Adresa : IDbObject
    {
        public FormError ValidateData()
        {
            throw new System.NotImplementedException();
        }

        public string Ulica { get; set; } = "";
        public string Broj { get; set; } = "";
        public Grad Grad { get; set; } = new Grad();
    }
}
