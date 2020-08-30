using System;
using System.Collections.Generic;
using System.Text;

namespace Knjigovodstvo.Code
{
    class PartnerInsert
    {
        public PartnerInsert(Partner partner) { _partner = partner; }

        public bool Insert()
        {
            return true;
        }
        //TODO Insert new partner into db
        readonly Partner _partner;
    }
}
