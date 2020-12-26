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
                        Duguje1 = _temeljnicaStavka[i].Duguje1,
                        Potrazuje1 = _temeljnicaStavka[i].Potrazuje1,
                        Duguje2 = _temeljnicaStavka[i].Duguje2,
                        Potrazuje2 = _temeljnicaStavka[i].Potrazuje2,
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

        private List<TemeljnicaStavka> _stavke;

        public int Id { get; set; } = 0;
        public string Opis { get; set; } = "";
        public string Dokument { get; set; } = "";
        public int Broj { get; set; } = 0;
        public string Konto { get; set; } = "";
        public string Datum { get; set; } = "";
        public string Valuta { get; set; } = "HRK";
        public decimal Duguje1 { get; set; } = 0;
        public decimal Potrazuje1 { get; set; } = 0;
        public decimal Duguje2 { get; set; } = 0;
        public decimal Potrazuje2 { get; set; } = 0;
        public int Broj_temeljnice { get; set; } = 0;
    }
}
