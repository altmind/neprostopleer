using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#pragma warning disable 0649

namespace neprostopleer.Entities.WS
{
    [Serializable]
    class GetUrlResponse
    {
        public bool success;
        public string residue_type;
        public long residue;
        public string residue_human;
        public long battery_charge;
        public string track_link;
    }
}
