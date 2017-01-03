using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AuTO
{
    // Structs for JSONs
    public class Tournament
    {
        [JsonProperty("name")]
        public string name;

        [JsonProperty("tournament_type")]
        public string type;

        [JsonProperty("subdomain")]
        public string subdomain;

        [JsonProperty("url")]
        public string url;
    }

    public class Participant
    {
        [JsonProperty("name")]
        public string name;

        [JsonProperty("seed")]
        public int seed;
    }
}
