using Knjigovodstvo.Database;
using Knjigovodstvo.Interface;
using System;
using System.Windows.Forms;

namespace Knjigovodstvo.BankStatements
{
    public class IzvodPromet :IDbObject
    {
        public FormError ValidateData()
        {
            return FormError.None;
        }

        internal void InsertData()
        {
            new DbDataInsert().InsertData(this);
        }

        internal void InsertData(DataGridViewRow row)
        {
            Naziv = row.Cells["Naziv"].Value.ToString();
            Opis = row.Cells["Opis"].Value.ToString();
            Konto = row.Cells["Konto"].Value.ToString();
            Dugovna = decimal.Parse(row.Cells["Duguje"].Value.ToString());
            Potrazna = decimal.Parse(row.Cells["Potražuje"].Value.ToString());
            Oznaka = Dugovna == 0 ? "P" : "D";
            
            InsertData();
        }

        public int Id { get; set; } = 0;
        public int Id_izvod { get; set; } = 0;
        public string Naziv { get; set; } = "";
        public string Opis { get; set; } = "";
        public string Konto { get; set; } = "";
        public decimal Dugovna { get; set; } = 0;
        public decimal Potrazna { get; set; } = 0;
        public string Oznaka { get; set; } = "x";
    }
}
