using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace neprostopleer.Entities.WS
{
    #pragma warning disable 0649

    [Serializable]
    class LoginResponse
    {
        public bool success;
        public bool premium;
        public string login;
        public string playlists;
        public bool advanced_play;
        public bool advanced_play_reversed;
        public bool top_player;
        public bool hotkeys;

    }
}
