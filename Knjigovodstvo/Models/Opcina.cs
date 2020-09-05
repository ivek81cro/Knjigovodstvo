namespace Knjigovodstvo.Models
{
    public class Opcina : IDbObject
    {
        public FormError ValidateData()
        {
            if (Naziv.Length < 2 || Naziv.StartsWith("Odaberite"))
                return FormError.Name;
            if (Zupanija.Length < 2 || Zupanija.StartsWith("Odaberite"))
                return FormError.County;
            if (Drzava.Length < 2)
                return FormError.Country;
            if (Posta.Length != 5)
                return FormError.Post;

            return FormError.None;
        }

        public int Id { get; set; } = 0;
        public string Naziv { get; set; } = "";
        public string Zupanija { get; set; } = "";
        public string Drzava { get; set; } = "";
        public string Posta { get; set; } = "";
    }
}
