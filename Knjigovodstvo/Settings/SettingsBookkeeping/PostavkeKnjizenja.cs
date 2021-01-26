using Knjigovodstvo.Database;
using Knjigovodstvo.Interface;
using Knjigovodstvo.Settings.SettingsBookkeeping;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Knjigovodstvo.Settings
{
    public class PostavkeKnjizenja : IDbObject
    {
        public FormError ValidateData()
        {
            throw new System.NotImplementedException();
        }

        internal List<PostavkeKnjizenja> GetPostavkeKnjizenjaList(BookNames book)
        {
            List<DataRow> row = new DbDataGet()
                .GetTable(this, $"Knjiga='{book}'")
                .AsEnumerable()
                .ToList();

            return (from DataRow dRow in row
                    select new PostavkeKnjizenja()
                    {
                        Id = int.Parse(dRow["Id"].ToString()),
                        Knjiga = dRow["Knjiga"].ToString(),
                        Naziv_stupca = dRow["Naziv_stupca"].ToString(),
                        Konto = dRow["Konto"].ToString(),
                        Strana = dRow["Strana"].ToString(),
                        Mijenja_predznak = dRow["Mijenja_predznak"].ToString() == "True"
                    }).ToList();
        
        }

        public void GetIdByKontoNazivStupca() 
        {
            DataTable dt = new DbDataGet().GetTable(this, $"Naziv_stupca='{Naziv_stupca}' AND Knjiga='{Knjiga}'");
            Id = int.Parse(dt.Rows[0]["Id"].ToString());
            Knjiga = dt.Rows[0]["Knjiga"].ToString();
            Naziv_stupca = dt.Rows[0]["Naziv_stupca"].ToString();
            Strana = dt.Rows[0]["Strana"].ToString();
            Mijenja_predznak = dt.Rows[0]["Strana"].ToString() == "True";
        }

        public int Id { get; set; } = 0;
        public string Knjiga { get; set; } = "";
        public string Naziv_stupca { get; set; } = "";
        public string Konto { get; set; } = "";
        public string Strana { get; set; } = "";
        public bool Mijenja_predznak { get; set; }
    }
}
