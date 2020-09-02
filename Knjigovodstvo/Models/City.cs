using System;
using System.Collections.Generic;
using System.Text;

namespace Knjigovodstvo.Models
{
    public class City
    {
        public bool ValidateData()
        {
            if (Name.Length < 2 || Name.StartsWith("Odaberite"))
                return false;
            if (County.Length < 2 || County.StartsWith("Odaberite"))
                return false;
            if (Country.Length < 2)
                return false;
            if (Post.Length != 5)
                return false;

            return true;
        }

        public string Name { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string Post { get; set; }
    }
}
