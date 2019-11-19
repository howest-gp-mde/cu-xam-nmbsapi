using System;
using System.Collections.Generic;
using System.Text;

namespace Siegfried.Oefening5.Domain
{
    public class Station
    {
        /*
    "id": "BE.NMBS.008821006",
    "@id": "http://irail.be/stations/NMBS/008821006",
    "locationX": 4.421101,
    "locationY": 51.2172,
    "standardname": "Antwerpen-Centraal",
    "name": "Antwerp-Central"
             */

        public string Id { get; set; }
        public double LocationX { get; set; }
        public double LocationY { get; set; }
        public string StandardName { get; set; }
        public string Name { get; set; }
    }
}
