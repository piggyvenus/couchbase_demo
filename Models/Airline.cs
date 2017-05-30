using System;

namespace couchbase_demo.Models
{
    [Serializable]
    public class Airline
    {
        public string Id {get;set;}
        public string Type {get;set;}
        public string Name {get;set;}
        public string Iata {get;set;}
        public string Icao {get;set;}
        public string Callsign {get;set;}
        public string Country {get;set;}
    }
}