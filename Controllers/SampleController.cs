using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace BackendExperimental.Controllers
{
    [ApiController]
    public class SampleController : ControllerBase {
        private static List<Tuple> allTuplesSubmitted = new List<Tuple>();
        private static List<SampleObject> allSampleObjectsReturned = new List<SampleObject>();

        [HttpGet]
        [Route(Constants.API_HEADER + "ping")]
        public String GetResponse() => "pong";

        [HttpGet]
        [Route(Constants.API_HEADER + "hello")]
        public String GetHelloWithName(String name) => "Hello " + name;

        [HttpPost]
        [Route(Constants.API_HEADER + "sample")]
        public SampleObject GetSampleObject(Tuple tuple)
        {
            allTuplesSubmitted.Add(tuple);
            allSampleObjectsReturned.Add(new SampleObject(tuple.getTotal()));

            return allSampleObjectsReturned[allSampleObjectsReturned.Count - 1];
        }

        [HttpGet]
        [Route(Constants.API_HEADER + "getAll")]
        public Dictionary<String, Object> getAllData()
        {
            int findFirstTotal = 0;
            int findSecondTotal = 0;
            int findTotal = 0;

            for (int i = 0; i < allSampleObjectsReturned.Count; i++)
            {
                findFirstTotal += allTuplesSubmitted[0].first;
                findSecondTotal += allTuplesSubmitted[0].second;
                findTotal += allSampleObjectsReturned[0].value;
            }

            return new Dictionary<string, Object>
            {
                { "tuples", allTuplesSubmitted },
                { "samples", allSampleObjectsReturned },
                { "first", findFirstTotal },
                { "second", findSecondTotal },
                { "total", findTotal }
            };
        }
    }


    public class SampleObject
    {
        public String id { get; set; }
        public int value { get; set; }

        public SampleObject(int value)
        {
            this.value = value;
        }
    }

    public class Tuple
    {
        public int first { get; set; }
        public int second { get; set; }

        public Tuple()
        {
        }

        public Tuple(int first, int second)
        {
            this.first = first;
            this.second = second;
        }

        public int getTotal() => first + second;

        public override string ToString()
        {
            return "{\"first\":" + first + ",\"second\":" + second + "}";
        }
    }
}