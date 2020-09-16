using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerializeJsonDemo
{
    public class OrderPoint
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lng")]
        public double Longitude { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("short_address")]
        public string ShortAddress { get; set; }

        [JsonProperty("mobile")]
        public string Mobile { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Number	COD amount (Cash on delivery), for multiple delivery points.
        /// </summary>
        [JsonProperty("cod")]
        public double Cod { get; set; }

        [JsonProperty("remarks")]
        public string Remarks { get; set; }

        [JsonProperty("require_pod")]
        public bool RequirePod { get; set; }

        [JsonProperty("require_verification")]
        public bool RequireVerification { get; set; }

        [JsonProperty("rating_by_receiver")]
        public long RatingByReceiver { get; set; }

        [JsonProperty("comment_by_receiver")]
        public string CommentByReceiver { get; set; }

        #region Complete_Shipment
        [JsonProperty("complete_time")]
        public long CompleteTime { get; set; }

        [JsonProperty("complete_lat")]
        public double CompleteLatitude { get; set; }

        [JsonProperty("complete_lng")]
        public double CompleteLongitude { get; set; }

        [JsonProperty("complete_comment")]
        public string CompleteComment { get; set; }
        #endregion

        #region Fail_Shipment
        [JsonProperty("fail_time")]
        public long FailTime { get; set; }

        [JsonProperty("fail_comment")]
        public string FailComment { get; set; }

        [JsonProperty("fail_lat")]
        public double FailLatitude { get; set; }

        [JsonProperty("fail_lng")]
        public double FailLongitude { get; set; }
        #endregion

        [JsonProperty("image_url")]
        public Uri ImageUrl { get; set; }

        [JsonProperty("pod_info")]
        public string PodInfo { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
