﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace neprostopleer.Entities.DB
{
    class Track
    {
        public string id;
        public string state;
        public string disklocation;
        public DateTime fetchtime;
        public Track(string id, string state, string disklocation, DateTime fetchtime)
        {
            this.id = id;
            this.state = state;
            this.disklocation = disklocation;
            this.fetchtime = fetchtime;
        }
    }
}
