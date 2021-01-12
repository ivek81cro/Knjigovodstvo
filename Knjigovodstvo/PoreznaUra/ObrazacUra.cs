using System;
using System.Collections.Generic;

namespace Knjigovodstvo.PoreznaUra
{
    public class ObrazacUra
    {
        public void GenerateForm(UraObrazacGeneralData gd, List<sRacun> racuni, sRacuniUkupno ukupno)
        {
            _gd = gd;
            _komitent.GetData();
            _sObrazacURA = new sObrazacURA()
            {
                Metapodaci = new sURAmetapodaci()
                {
                    Naslov = new sNaslovTemeljni()
                    {
                        Value = "Knjiga primljenih (ulaznih) računa"
                    },
                    Autor = new sAutorTemeljni()
                    {
                        Value = _gd.Autor.Ime + ' ' + _gd.Autor.Prezime
                    },
                    Datum = new sDatumTemeljni()
                    {
                        Value = DateTime.Now
                    },
                    Format = new sFormatTemeljni()
                    {
                        Value = tFormat.textxml
                    },
                    Jezik = new sJezikTemeljni()
                    {
                        Value = tJezik.hrHR
                    },
                    Identifikator = new sIdentifikatorTemeljni()
                    {
                        Value = Guid.NewGuid().ToString()
                    },
                    Uskladjenost = new sUskladjenost()
                    {
                        Value = "ObrazacURA-v1-0"
                    },
                    Tip = new sTipTemeljni()
                    {
                        Value = tTip.Elektroničkiobrazac
                    },
                    Adresant = new sAdresantTemeljni()
                    {
                        Value = "Ministarstvo Financija, Porezna uprava, Zagreb"
                    }
                },
                Zaglavlje = new sZaglavlje()
                {
                    Razdoblje = new sRazdoblje()
                    {
                        DatumOd = _gd.Razdoblje.DatumOd,
                        DatumDo = _gd.Razdoblje.DatumDo
                    },
                    Obveznik = new sPorezniObveznik()
                    {
                        ItemElementName = ItemChoiceType.OIB,
                        Item = _komitent.OpciPodaci.Oib,
                        ItemsElementName = new ItemsChoiceType[] { ItemsChoiceType.Naziv },
                        Items = new string[] { _komitent.OpciPodaci.Naziv },
                        Adresa = new sAdresa()
                        {
                            Mjesto = _komitent.Adresa.Grad.Mjesto,
                            Ulica = _komitent.Adresa.Ulica,
                            Broj = _komitent.Adresa.Broj
                        },
                        PodrucjeDjelatnosti = "G",
                        SifraDjelatnosti = _komitent.Sifra_djelatnosti
                    },
                    ObracunSastavio = new sIspunjavatelj()
                    {
                        Ime = _gd.Autor.Ime,
                        Prezime = _gd.Autor.Prezime
                    }
                },
                Tijelo = new sTijelo() 
                {
                    Racuni = racuni.ToArray(),
                    Ukupno = ukupno
                }
            };
        }

        public sObrazacURA GetSerializable() 
        {
            return _sObrazacURA;
        }

        private sObrazacURA _sObrazacURA;
        private Komitent _komitent = new Komitent();
        private UraObrazacGeneralData _gd;
    }
}
