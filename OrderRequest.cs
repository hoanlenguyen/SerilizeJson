using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerializeJsonDemo
{
    public class OrderRequest
    {
        [JsonProperty("order_time")]
        public long OrderTime { get; set; }

        [JsonProperty("path")]
        public IList<OrderPoint> Points { get; set; }

        [JsonProperty("service_id")]
        public string ServiceId { get; set; }

        [JsonProperty("requests")]
        public List<OrderSpecialRequest> Requests { get; set; } = new List<OrderSpecialRequest>();

        [JsonProperty("payment_method")]
        public string PaymentMethod { get; set; }
    }
}
