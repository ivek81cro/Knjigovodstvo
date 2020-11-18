
namespace Knjigovodstvo.Helpers
{
    /// <summary>
    /// Replace chars in database column name for displaying format
    /// </summary>
    class TableHeaderFormat
    {
        public string FormatHeader(string rawHeader)
        {
            rawHeader = rawHeader.Replace("_per", "%");
            rawHeader = rawHeader.Replace('_', ' ');

            return rawHeader;
        }
    }
}
