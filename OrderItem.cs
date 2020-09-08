using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerializeJsonDemo
{
    public class OrderItem
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("num")]
        public long Number { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }
    }
}
