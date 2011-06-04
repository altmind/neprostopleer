using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace neprostopleer
{
    class CoreSnappingManager
    {
        public IDictionary<IntPtr, Rectangle> bounds = new Dictionary<IntPtr,Rectangle>();
    }
}
