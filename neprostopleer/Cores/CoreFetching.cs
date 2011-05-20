using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace neprostopleer.Cores
{
    //<summary>
    class CoreFetching
    {
        private IList<Uri> fetchQueue = new List<Uri>();
        private Dictionary<Uri, Stream> results = new Dictionary<Uri, Stream>();

        public void enqueueUri(Uri uri)
        {
            fetchQueue.Add(uri);
            triggerFetchingIfNotAlreadyRunning();
        }

        public void dequeueUri(Uri uri)
        {
            
        }

        private void triggerFetchingIfNotAlreadyRunning()
        {
            throw new NotImplementedException();
        }
    }
}
