using System;
using System.Collections.Generic;
using System.Text;

namespace Siegfried.Oefening5.Domain
{
    public class StationResponse
    {
        public string Version { get; set; }
        public string TimeStamp { get; set; }
        public IEnumerable<Station> Station { get; set; }
    }
}
