using Knjigovodstvo.Interface;

namespace Knjigovodstvo.Settings
{
    class PostavkeKnjizenja : IDbObject
    {
        public FormError ValidateData()
        {
            throw new System.NotImplementedException();
        }

        public int Id { get; set; } = 0;
        public string Book { get; set; } = "";
        public string Column_name { get; set; } = "";
        public string Konto { get; set; } = "";
    }
}
