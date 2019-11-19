using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Siegfried.Oefening5.Domain.Service
{
    public class NmbsService
    {
        private string baseUrl = "https://api.irail.be";
        private HttpClient client;

        public NmbsService()
        {
            
        }

        public async Task<IEnumerable<Station>> GetStations()
        {
            IEnumerable<Station> stations = new List<Station>();
            using(client = new HttpClient())
            {
                //request naar API sturen
                string url = $"{baseUrl}/stations/?format=json&lang=nl";
                string response = await client.GetStringAsync(url);

                //response parsen
                var stationResponse = JsonConvert.DeserializeObject<StationResponse>(response);
                stations = stationResponse.Station;
            }
            return stations;
        }

        public async Task<IEnumerable<Departure>> GetDepartures(Station station, DateTime startFrom)
        {
            IEnumerable<Departure> departures = new List<Departure>();
            using (client = new HttpClient())
            {
                //request naar API sturen
                string url = $"{baseUrl}/liveboard/?id={station.Id}&station={station.Name}&date={startFrom.ToString("ddMMyy")}&time={startFrom.ToString("HHmm")}&arrdep=departure&lang=nl&format=json&fast=false&alerts=false";
                string response = await client.GetStringAsync(url);

                //response parsen
                var depResponse = JsonConvert.DeserializeObject<DepartureResponse>(response);
                departures = depResponse.Departures.Departure;
            }
            return departures;
        }
    }
}
