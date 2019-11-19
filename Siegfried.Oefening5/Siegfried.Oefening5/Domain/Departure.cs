using System;
using System.Collections.Generic;
using System.Text;

namespace Siegfried.Oefening5.Domain
{

    public class DepartureResponse
    {
        public string Version { get; set; }
        public string TimeStamp { get; set; }
        public DeparturesInfo Departures {get;set;}
    }

    public class DeparturesInfo
    {
        public int Number { get; set; }
        public IEnumerable<Departure> Departure { get; set; }
    }

    public class Departure
    {
        public int Id { get; set; }
        public int Delay { get; set; }
        public long Time { get; set; }
        public Vehicle Vehicleinfo { get; set; }
        public string Platform { get; set; }
        public int Canceled { get; set; }
        public int Left { get; set; }
    }
}
