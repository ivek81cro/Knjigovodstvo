using System;
using System.Collections.Generic;

namespace Knjigovodstvo.JoppdDocument
{
    class JoppdA
    {
        private readonly List<sPrimateljiP> _pArr;

        public JoppdA(List<sPrimateljiP> pArr)
        {
            _pArr = pArr;
        }

        internal decimal UkupnoPorezIPrirez()
        {
            decimal ukupno = 0;
            foreach (sPrimateljiP primatelj in _pArr)
            {
                ukupno += primatelj.P141 + primatelj.P142;
            }

            return Math.Round(ukupno, 2);
        }

        internal decimal SviDoprinosiGeneracijskaDjelatnici()
        {
            decimal ukupno = 0;
            foreach (sPrimateljiP primatelj in _pArr)
            {
                if (primatelj.P61 == tOznakaStjecatelja.Item0001 ||
                    primatelj.P61 == tOznakaStjecatelja.Item0002 ||
                    primatelj.P61 == tOznakaStjecatelja.Item0003)
                    ukupno += primatelj.P121;
            }

            return Math.Round(ukupno, 2);

        }

        internal decimal SviDoprinosiGeneracijskaPoduzetnik()
        {
            decimal ukupno = 0;
            foreach (sPrimateljiP primatelj in _pArr)
            {
                if (primatelj.P61 == tOznakaStjecatelja.Item0032)
                    ukupno += primatelj.P121;
            }

            return Math.Round(ukupno, 2);
        }

        internal decimal SviDoprinosiKapitaliziranaDjelatnici()
        {
            decimal ukupno = 0;
            foreach (sPrimateljiP primatelj in _pArr)
            {
                if (primatelj.P61 == tOznakaStjecatelja.Item0001 ||
                    primatelj.P61 == tOznakaStjecatelja.Item0002 ||
                    primatelj.P61 == tOznakaStjecatelja.Item0003)
                    ukupno += primatelj.P122;
            }

            return Math.Round(ukupno, 2);
        }

        internal decimal SviDoprinosiKapitaliziranaPoduzetnik()
        {
            decimal ukupno = 0;
            foreach (sPrimateljiP primatelj in _pArr)
            {
                if (primatelj.P61 == tOznakaStjecatelja.Item0032)
                    ukupno += primatelj.P122;
            }

            return Math.Round(ukupno, 2);
        }

        internal decimal ZdravstveoDjelatnici()
        {
            decimal ukupno = 0;
            foreach (sPrimateljiP primatelj in _pArr)
            {
                if (primatelj.P61 == tOznakaStjecatelja.Item0001 ||
                    primatelj.P61 == tOznakaStjecatelja.Item0002 ||
                    primatelj.P61 == tOznakaStjecatelja.Item0003)
                    ukupno += primatelj.P123;
            }

            return Math.Round(ukupno, 2);
        }

        internal decimal ZdravstvenoPoduzetnici()
        {
            decimal ukupno = 0;
            foreach (sPrimateljiP primatelj in _pArr)
            {
                if (primatelj.P61 == tOznakaStjecatelja.Item0032)
                    ukupno += primatelj.P123;
            }

            return Math.Round(ukupno, 2);
        }

        internal decimal ZbrojNeoporezivo()
        {
            decimal ukupno = 0;
            foreach (sPrimateljiP primatelj in _pArr)
            {
                ukupno += primatelj.P152;
            }

            return Math.Round(ukupno, 2);
        }
    }
}
