using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace couchbase_demo.Controllers
{
    using Couchbase;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using couchbase_demo.Models;

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            using (var cluster = new Cluster())
            {
                using (var bucket = cluster.OpenBucket("travel-sample"))
                {
                    // Query by id.
                    using (var queryResult = bucket.Query<dynamic>("SELECT * FROM `travel-sample` LIMIT 10"))
                    {
                        return JsonConvert.SerializeObject(queryResult);
                    }
                }
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            using (var cluster = new Cluster())
            {
                using (var bucket = cluster.OpenBucket("travel-sample"))
                {
                    // Query by id.
                    using (var queryResult = bucket.Query<dynamic>("SELECT * FROM `travel-sample` WHERE id = " + id))
                    {
                        return JsonConvert.SerializeObject(queryResult);
                    }
                }
            }
        }


        // POST api/values
        [HttpPost]
        public string Post([FromBody]Airline airline)
        {
            using (var cluster = new Cluster())
            {
                using (var bucket = cluster.OpenBucket("travel-sample"))
                {
                    var document = new Document<dynamic>
                    {
                        Id = "airline_" + airline.Id,
                        Content = new
                        {
                            id = Int32.Parse(airline.Id),
                            type = airline.Type,
                            name = airline.Name,
                            iata = airline.Iata,
                            icao = airline.Icao,
                            callsign = airline.Callsign,
                            country = airline.Country
                        }
                    };
                    var result = bucket.Insert(document);
                    if (result.Success)
                    {
                        return document.Id;
                    } else {
                        return "Failed to insert " + airline.Name;
                    }
                }
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
