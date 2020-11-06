using Knjigovodstvo.Interface;

namespace Knjigovodstvo.Global
{
    public class Kontakt : IDbObject
    {
        public string Telefon { get; set; } = "";
        public string Telefon2 { get; set; } = "";
        public string  Fax { get; set; } = "";
        public string Email { get; set; } = "";

        public FormError ValidateData()
        {
            throw new System.NotImplementedException();
        }
    }
}
