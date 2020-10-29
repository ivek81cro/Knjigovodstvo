using System.Collections.Generic;

namespace Knjigovodstvo.JoppdDocument
{
    class JoppdB
    {
        public string PodnositeljOib { get; set; }
        public string OznakaIzvjesca { get; set; }
        public int VrstaIzvjesca { get; set; }
        public List<JoppdEntitet> Entitet { get; set; }
    }
}
