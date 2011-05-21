using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace neprostopleer.Entities.Misc
{
    class PlayerProgressInformation
    {
        public PlayState state;
        public int totalLength;
        public int currentPosition;
        public string artist;
        public string track;
        public int secondsPrebuffered;
        public string trackId;
    }
    public enum PlayState
    {
        PLAYING, PAUSED, STOPPED, STALLED
    }
}
