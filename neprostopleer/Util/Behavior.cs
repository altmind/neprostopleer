using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace neprostopleer.Util
{
    class Behavior
    {
        public static void Assert(Boolean assertion, string description)
        {
            if (!assertion)
                throw new Exception(description);
        }
    }
}
