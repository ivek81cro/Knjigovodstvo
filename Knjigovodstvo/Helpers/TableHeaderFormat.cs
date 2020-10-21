
namespace Knjigovodstvo.Helpers
{
    class TableHeaderFormat
    {
        //TOTO: Change clumn name format in DB and in model property to abc_abc_12_perc for easier column header format
        public string FormatHeader(string rawHeader)
        {
            rawHeader = rawHeader.Replace("_per", "%");
            rawHeader = rawHeader.Replace('_', ' ');

            return rawHeader;
        }
    }
}
