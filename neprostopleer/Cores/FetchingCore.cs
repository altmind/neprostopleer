using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace neprostopleer.Cores
{
    //<summary>
    class FetchingCore
    {
        private IList<Uri> fetchQueue = new List<Uri>();
        private Dictionary<Uri, Stream> results = new Dictionary<Uri, Stream>();
        private Uri currentUri;
        private CancellationTokenSource currentCancellationTokenSource;

        public void enqueueUri(Uri uri)
        {
            fetchQueue.Add(uri);
            triggerFetchingIfNotAlreadyRunning();
        }

        public void dequeueUri(Uri uri)
        {
            if (fetchQueue.Contains(uri))
            {
                fetchQueue.Remove(uri);
                
            }
            else if (uri.Equals(currentUri) && currentCancellationTokenSource!=null)
            {
                currentCancellationTokenSource.Cancel();
            }
            triggerFetchingIfNotAlreadyRunning();
        }

        private void triggerFetchingIfNotAlreadyRunning()
        {
            throw new NotImplementedException();
        }
    }
}
