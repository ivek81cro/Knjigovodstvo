using System;
using System.Linq;

namespace Knjigovodstvo.Helpers
{
    class TableHeaderFormat
    {
        //TOTO: Change clumn name format in DB and in model property to abc_abc_12_perc for easier column header format
        public string FormatHeader(string rawHeader)
        {
            string header = string.Concat(rawHeader.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');

            for (int i = 0; i < header.Length; i++)
            {
                if (char.IsDigit(header[i]))
                {
                    header = header.Insert(i, " ");
                    if(header.Contains("Porez"))
                        header = string.Concat(header, "%");
                    break;
                }
            }

            return header;
        }
    }
}
