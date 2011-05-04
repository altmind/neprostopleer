using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace neprostopleer
{
    class SoundException: Exception
    {
        public SoundException(): base(){}
        public SoundException(string description): base(description){}
    }
}
