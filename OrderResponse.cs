using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerializeJsonDemo
{
    public class OrderResponse
    {
        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("shared_link")]
        public string SharedLink { get; set; }

        [JsonProperty("order")]
        public Order Order { get; set; }
    }
}
