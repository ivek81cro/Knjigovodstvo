using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Knjigovodstvo.JoppdDocument
{
    [Serializable()]
    [XmlRoot("Metapodaci")]
    class JoppdObrazac
    {
        public JoppdObrazac()
        {

        }

        public JoppdObrazac(JoppdB joppdB, Komitent komitent)
        {
            _joppdB = joppdB;
            _komitent = komitent;
        }

        public sObrazacJOPPD CreateJoppdXmlFile(DateTime datum, string joppdBroj, string izvjesceSastavio, int broj_osoba) 
        {
            List<sPrimateljiP> pArr = new List<sPrimateljiP>();
            for (int i = 0; i < _joppdB.Entitet.Count; i++)
            {
                JoppdEntitet e = _joppdB.Entitet[i];
                pArr.Add(new sPrimateljiP()
                {
                    P1 = e.Redni_Broj,
                    P2 = e.Opcina_Prebivalista,
                    P3 = e.Opcina_Rada,
                    P4 = e.Oib,
                    P5 = e.Ime_Prezime,
                    P61 = (tOznakaStjecatelja)Enum.Parse(typeof(tOznakaStjecatelja), "Item" + e.Stjecatelj),
                    P62 = (tOznakaPrimici)Enum.Parse(typeof(tOznakaPrimici), "Item" + e.Primitak),
                    P71 = (tOznakaMO)Enum.Parse(typeof(tOznakaMO), e.Beneficirani),
                    P72 = (tOznakaInvaliditet)Enum.Parse(typeof(tOznakaInvaliditet), "Item" + e.Invaliditet),
                    P8 = (tOznakaMjesec)Enum.Parse(typeof(tOznakaMjesec), "Item" + e.Mjesec),
                    P9 = (tOznakaRadnoVrijeme)Enum.Parse(typeof(tOznakaRadnoVrijeme), "Item" + e.Vrijeme),
                    P10 = e.IsPoslodavac() ? int.Parse((Convert.ToDateTime(e.Datum_Do) - Convert.ToDateTime(e.Datum_Od)).Days.ToString()) + 1 : e.Sati,
                    P101 = Convert.ToDateTime(e.Datum_Od),
                    P102 = Convert.ToDateTime(e.Datum_Do),
                    P11 = e.Bruto,
                    P12 = e.Bruto,
                    P121 = e.Mio_1,
                    P122 = e.Mio_2,
                    P123 = e.Zdravstvo,
                    P124 = e.Zaštita,
                    P125 = e.Zaposljavanje,
                    P126 = e.Povecani_Mio,
                    P127 = e.Povecani_Mio2,
                    P129 = e.Invaliditet_Doprinos,
                    P131 = e.Izdatak,
                    P132 = e.IzdatakUplaceni_Mio,
                    P133 = e.Dohodak,
                    P134 = e.Osobni_Odbitak,
                    P135 = e.Porezna_Osnovica,
                    P141 = e.Porez_Ukupno,
                    P142 = e.Prirez,
                    P151 = (tOznakaNeoporezivogPrimitka)Enum.Parse(typeof(tOznakaNeoporezivogPrimitka), e.Oznaka_Neoporezivog),
                    P152 = e.Iznos_Neoporezivog,
                    P161 = (tOznakaNacinaIsplate)Enum.Parse(typeof(tOznakaNacinaIsplate), e.Nacin_Isplate),
                    P162 = e.Iznos_Isplate,
                    P17 = e.Primitak_Nesamostalni
                });
            }

            JoppdA jA = new JoppdA(pArr);
            sStranaA strA = new sStranaA()
            {
                DatumIzvjesca = datum,
                OznakaIzvjesca = joppdBroj,
                VrstaIzvjesca = tVrstaIzvjesca.Item1,
                IzvjesceSastavio = new sIzvjesceSastavio()
                {
                    Ime = izvjesceSastavio.Split(' ')[0],
                    Prezime = izvjesceSastavio.Split(' ')[1]
                },
                PodnositeljIzvjesca = new sPodnositeljIzvjesca()
                {
                    ItemsElementName = new[] { ItemsChoiceType.Naziv },
                    Items = new[] { _komitent.OpciPodaci.Naziv },
                    Adresa = new sAdresa()
                    {
                        Ulica = _komitent.Adresa.Ulica,
                        Broj = _komitent.Adresa.Broj,
                        Mjesto = _komitent.Adresa.Grad.Mjesto
                    },
                    Email = _komitent.Kontakt.Email,
                    OIB = _komitent.OpciPodaci.Oib,
                    Oznaka = tOznakaPodnositelja.Item2
                },
                BrojOsoba = broj_osoba.ToString(),
                BrojRedaka = pArr.Count.ToString(),
                PredujamPoreza = new sPredujamPoreza()
                {
                    P1 = jA.UkupnoPorezIPrirez(),
                    P11 = jA.UkupnoPorezIPrirez(),
                    P12 = 0,
                    P2 = 0,
                    P3 = 0,
                    P4 = 0,
                    P5 = 0,
                    P6 = 0
                },
                Doprinosi = new sDoprinosi()
                {
                    GeneracijskaSolidarnost = new sGeneracijskaSolidarnost()
                    {
                        P1 = jA.SviDoprinosiGeneracijskaDjelatnici(),
                        P1Specified = true,
                        P2 = 0,
                        P3 = jA.SviDoprinosiGeneracijskaPoduzetnik(),
                        P3Specified = true,
                        P4 = 0,
                        P5 = 0,
                        P6 = 0,
                        P7 = 0
                    },
                    KapitaliziranaStednja = new sKapitaliziranaStednja()
                    {
                        P1 = jA.SviDoprinosiKapitaliziranaDjelatnici(),
                        P1Specified = true,
                        P2 = 0,
                        P3 = jA.SviDoprinosiKapitaliziranaPoduzetnik(),
                        P3Specified = true,
                        P4 = 0,
                        P5 = 0,
                        P6 = 0
                    },
                    ZdravstvenoOsiguranje = new sZdravstvenoOsiguranje()
                    {
                        P1 = jA.ZdravstveoDjelatnici(),
                        P1Specified = true,
                        P2 = 0,
                        P3 = jA.ZdravstvenoPoduzetnici(),
                        P3Specified = true,
                        P4 = 0,
                        P5 = 0,
                        P6 = 0,
                        P7 = 0,
                        P8 = 0,
                        P9 = 0,
                        P10 = 0,
                        P11 = 0,
                        P12 = 0
                    },
                    Zaposljavanje = new sZaposljavanje()
                    {
                        P1 = 0,
                        P2 = 0,
                        P3 = 0,
                        P4 = 0
                    }
                },
                IsplaceniNeoporeziviPrimici = jA.ZbrojNeoporezivo(),
                IsplaceniNeoporeziviPrimiciSpecified = true,
                KamataMO2 = 0,
                UkupniNeoporeziviPrimici = 0,
                NaknadaZaposljavanjeInvalida = new sNaknadaZaposljavanjeInvalida()
                {
                    P1 = "0",
                    P2 = 0
                }
            };

            sJOPPDmetapodaci meta = new sJOPPDmetapodaci()
            {
                Datum = new sDatumTemeljni() { Value = datum.AddHours(12) },
                Naslov = new sNaslovTemeljni() { Value = "Izvješće o primicima, porezu na dohodak i prirezu te doprinosima za obvezna osiguranja" },
                Autor = new sAutorTemeljni() { Value = "Ivan Batinić" },
                Format = new sFormatTemeljni() { Value = tFormat.textxml },
                Jezik = new sJezikTemeljni() { Value = tJezik.hrHR },
                Identifikator = new sIdentifikatorTemeljni() { Value = Guid.NewGuid().ToString() },
                Uskladjenost = new sUskladjenost() { Value = "ObrazacJOPPD-v1-1" },
                Tip = new sTipTemeljni() { Value = tTip.Elektroničkiobrazac },
                Adresant = new sAdresantTemeljni() { Value = "Ministarstvo Financija, Porezna uprava, Zagreb" }
            };
            sPrimateljiP[][] prim = { pArr.ToArray() };

            _sObrazacJoppd.StranaA = strA;
            _sObrazacJoppd.StranaB = prim;
            _sObrazacJoppd.Metapodaci = meta;

            return _sObrazacJoppd;
        }

        private readonly JoppdB _joppdB = new JoppdB();
        private readonly Komitent _komitent = new Komitent();
        private readonly sObrazacJOPPD _sObrazacJoppd = new sObrazacJOPPD();
    }
}
