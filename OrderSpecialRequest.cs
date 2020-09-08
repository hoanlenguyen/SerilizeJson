using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerializeJsonDemo
{
    public class OrderSpecialRequest
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("num")]
        public int Number { get; set; }

        /// <summary>
        ///     Request fee
        /// </summary>
        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }

        [JsonProperty("item_price")]
        public double ItemPrice { get; set; }
    }
}
