using Knjigovodstvo.Settings;

namespace Knjigovodstvo.Wages
{
    class PlacaIzracun
    {
        public void Calculate(Placa p, decimal prirez, decimal stopaOdbitka, bool drugi = false)
        {
            PostavkePlace stope = new PostavkePlace();
            decimal iznos = p.Bruto;
            if (drugi)
            {
                iznos -= p.Mio_1 = iznos * (stope.GetStopaByName(PlacaStope.Mio_1) + stope.GetStopaByName(PlacaStope.Mio_2));
                p.Mio_2 = 0;
            }
            else
            {
                p.Mio_1 = iznos * stope.GetStopaByName(PlacaStope.Mio_1);
                p.Mio_2 = iznos * stope.GetStopaByName(PlacaStope.Mio_2);
                iznos -= p.Mio_1 + p.Mio_2;
            }
            p.Dohodak = iznos;
            iznos -= p.Osobni_Odbitak = stope.GetStopaByName(PlacaStope.Osnovica_odbitka) *
                (stope.GetStopaByName(PlacaStope.Osnovni_odbitak_koeficjent) + stopaOdbitka);
            if (iznos < 0)
            {
                iznos = 0;
                p.Osobni_Odbitak = p.Dohodak;
            }
            p.Porezna_Osnovica = iznos;

            if (p.Porezna_Osnovica > 30000)
            {
                iznos -= p.Porez_1 = 30000.0m * stope.GetStopaByName(PlacaStope.Porez_Dohodak_1);
                iznos -= p.Porez_1 = (p.Porezna_Osnovica - 30000) * stope.GetStopaByName(PlacaStope.Porez_Dohodak_2);
            }
            else
            {
                iznos -= p.Porez_1 = p.Porezna_Osnovica * stope.GetStopaByName(PlacaStope.Porez_Dohodak_1);
                p.Porez_2 = 0;
            }
            iznos -= p.Prirez = (p.Porez_Ukupno = p.Porez_1 + p.Porez_2) * prirez / 100;
            p.Ukupno_Porez_i_Prirez = p.Porez_Ukupno + p.Prirez;
            p.Neto = iznos + p.Osobni_Odbitak;

            p.Doprinos_Zdravstvo = p.Bruto * stope.GetStopaByName(PlacaStope.Doprinos_Zdravstveno);

            p.SumAllDodaci();
        }
    }
}
