using Knjigovodstvo.City;
using Knjigovodstvo.Models;

namespace Knjigovodstvo.Global
{
    public class Adresa : IDbObject
    {
        public string Ulica { get; set; } = "";
        public string Broj { get; set; } = "";
        public Grad Grad { get; set; } = new Grad();

        public FormError ValidateData()
        {
            throw new System.NotImplementedException();
        }
    }
}
