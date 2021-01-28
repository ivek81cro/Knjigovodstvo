using Knjigovodstvo.Database;
using Knjigovodstvo.Interface;
using System;
using System.Collections.Generic;
using System.Data;

namespace Knjigovodstvo.Books.PrepareForBalanceSheet
{
    class TemeljnicaStavka : IDbObject
    {
        public FormError ValidateData()
        {
            throw new NotImplementedException();
        }

        public void SaveToDatabase(List<TemeljnicaStavka> stavke)
        {
            foreach(var stavka in stavke)
                new DbDataInsert().InsertData(stavka);
        }

        public bool CheckIfExistsInDatabase(List<TemeljnicaStavka> _temeljnicaStavka)
        {
            DataTable dt = new DbDataGet().GetTable(this, $"Dokument='{Dokument}' AND Broj={Broj}");
            _stavke = new List<TemeljnicaStavka>();
            if (dt.Rows.Count > 0)
            {
                for(int i =0; i<_temeljnicaStavka.Count; i++)
                {
                    _stavke.Add(new TemeljnicaStavka()
                    {
                        Id = int.Parse(dt.Rows[i]["Id"].ToString()),
                        Opis = _temeljnicaStavka[i].Opis,
                        Dokument = _temeljnicaStavka[i].Dokument,
                        Broj = _temeljnicaStavka[i].Broj,
                        Konto = _temeljnicaStavka[i].Konto,
                        Datum = _temeljnicaStavka[i].Datum,
                        Valuta = _temeljnicaStavka[i].Valuta,
                        Dugovna = _temeljnicaStavka[i].Dugovna,
                        Potražna = _temeljnicaStavka[i].Potražna,
                        Broj_temeljnice = _temeljnicaStavka[i].Broj_temeljnice
                    });
                }
                return true;
            }
            return false;
        }

        public void UpdateStavka()
        {
            foreach(var stavka in _stavke)
            {
                new DbDataUpdate().UpdateData(stavka);
            }
        }

        public void DeleteStavka()
        {
            new DbDataDelete().DeleteItem(this);
        }

        private List<TemeljnicaStavka> _stavke;

        public int Id { get; set; } = 0;
        public string Opis { get; set; } = "";
        public string Dokument { get; set; } = "";
        public int Broj { get; set; } = 0;
        public string Konto { get; set; } = "";
        public string Datum { get; set; } = "";
        public string Valuta { get; set; } = "HRK";
        public decimal Dugovna { get; set; } = 0;
        public decimal Potražna { get; set; } = 0;
        public int Broj_temeljnice { get; set; } = 0;
    }
}
