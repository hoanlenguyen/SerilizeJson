using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SerializeJsonDemo
{
    public class Order
    {
        #region ReferencedIds_and_PartnerInfo
        [JsonProperty("_id")]
        public string OrderId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("service_id")]
        public string ServiceId { get; set; }

        [JsonProperty("city_id")]
        public string CityId { get; set; }

        /// <summary>
        ///     String:	User ID who created this order.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("user_name")]
        public string UserName { get; set; }

        [JsonProperty("partner")]
        public string PartnerId { get; set; }

        /// <summary>
        ///     String:	Supplier who accepted this order.
        /// </summary>
        [JsonProperty("supplier_id")]
        public string SupplierId { get; set; }

        [JsonProperty("supplier_name")]
        public string SupplierName { get; set; }

        /// <summary>
        ///     Object:	Pickup and drop-offs information
        /// </summary>
        [JsonProperty("path")]
        public List<OrderPoint> Points { get; set; } = new List<OrderPoint>();

        /// <summary>
        ///     JSONArray representing Special Requests.
        /// </summary>
        [JsonProperty("requests")]
        public OrderSpecialRequest[] Requests { get; set; }
        #endregion

        #region OrderItems
        /// <summary>
        ///     JSONArray representing image urls.
        /// </summary>
        [JsonProperty("images")]
        public string[] Images { get; set; }

        /// <summary>
        ///     Number (Unix timestamp) The broadcast time. Set idle_until=order_time if order_time > 0. Optional if order_time is 0. 
        /// </summary>
        [JsonProperty("idle_until")]
        public long IdleUntil { get; set; }

        /// <summary>
        ///     JSONArray representing items (for Food Partners)
        /// </summary>
        [JsonProperty("items")]
        public OrderItem[] Items { get; set; }

        /// <summary>
        ///     Order type, for eg: warehouse, etc … Treat as normal flow incase type is not specified
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        ///     Order type, for eg: warehouse, etc … Treat as normal flow incase type is not specified
        /// </summary>
        [DefaultValue(false)]
        [JsonProperty("need_optimize_route")]
        public bool NeedOptimizeRoute { get; set; }

        #endregion

        #region Order_Times
        /// <summary>
        ///     Number: Time when order was created, in epoch timestamp format.
        /// </summary>
        [JsonProperty("create_time")]
        public long CreateTime { get; set; }

        /// <summary>
        ///     Number: Time user want supplier to pick up his package, in epoch timestamp format.
        /// </summary>
        [JsonProperty("order_time")]
        public long OrderTime { get; set; }

        /// <summary>
        ///     Number:	Time when a supplier accept an order, in epoch timestamp format
        /// </summary>
        [JsonProperty("accept_time")]
        public long AcceptTime { get; set; }

        /// <summary>
        ///     Number	Time when a supplier come to user place, in epoch timestamp format.
        /// </summary>
        [JsonProperty("board_time")]
        public long BoardTime { get; set; }

        /// <summary>
        ///     Number	Time when a supplier pick up user package successfully, in epoch timestamp format.
        /// </summary>
        [JsonProperty("pickup_time")]
        public long PickupTime { get; set; }

        /// <summary>
        ///     Number	Time when an order was cancelled, in epoch timestamp format.
        /// </summary>
        [JsonProperty("cancel_time")]
        public long CancelTime { get; set; }

        /// <summary>
        ///     Number	Time when an order was completed, in epoch timestamp format.
        /// </summary>
        [JsonProperty("complete_time")]
        public long CompleteTime { get; set; }

        #endregion

        #region Currency_Fees
        /// <summary>
        ///     Currency (ISO 4217 currency code)
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        ///     Promotion code to be applied
        /// </summary>
        [JsonProperty("promo_code")]
        public string PromoCode { get; set; }

        /// <summary>
        ///     Method which user chooses to pay for this order (Available methods: CASH)
        /// </summary>
        [JsonProperty("payment_method")]
        public string PaymentMethod { get; set; }

        #region Obsolete 
        [ObsoleteAttribute("Stop fee for multiple drop-offs (Will be removed after December 1st, 2019)", false)]
        [JsonProperty("stop_fee")]
        public double StopFee { get; set; }


        [ObsoleteAttribute("Extra fee for adding special request to the order (Will be removed after December 1st, 2019)", false)]
        [JsonProperty("request_fee")]
        public double RequestFee { get; set; }

        [ObsoleteAttribute("Service fee calculated based on distance (Will be removed after December 1st, 2019)", false)]
        [JsonProperty("distance_fee")]
        public double DistanceFee { get; set; }

        [ObsoleteAttribute("(Will be removed after December 1st, 2019)", false)]
        [JsonProperty("discount")]
        public double Discount { get; set; }

        [ObsoleteAttribute("(Will be removed after December 1st, 2019)", false)]
        [JsonProperty("total_fee")]
        public double TotalFee { get; set; }

        #endregion
        /// <summary>
        ///     The amount of credit which is deducted fron user bonus account if bonus account have enough credit
        /// </summary>
        [JsonProperty("user_bonus_account")]
        public long UserBonusAccount { get; set; }

        /// <summary>
        ///     The amount of credit which is deducted fron user main account if main account have enough credit
        /// </summary>
        [JsonProperty("user_main_account")]
        public long UserMainAccount { get; set; }

        /// <summary>
        ///     The amount of CASH that user has to pay for this order (Total pay = Total fee - User Main account - User Bonus account)
        /// </summary>
        [JsonProperty("total_pay")]
        public double TotalPay { get; set; }

        #endregion

        #region Prices
        /// <summary>
        ///     Number: Service fee calculated based on distance (alternaltive for distance_fee)
        /// </summary>
        [JsonProperty("distance_price")]
        public double DistancePrice { get; set; }

        /// <summary>
        ///     Number: Extra fee for adding special request to the order (alternaltive for request_fee)
        /// </summary>
        [JsonProperty("special_request_price")]
        public double SpecialRequestPrice { get; set; }

        /// <summary>
        ///     Number: Stop fee for multiple drop-offs (alternaltive for stop_fee)
        /// </summary>
        [JsonProperty("stoppoint_price")]
        public double StopPointPrice { get; set; }

        /// <summary>
        ///     Number: Discount (alternaltive for discount)
        /// </summary>
        [JsonProperty("voucher_discount")]
        public double VoucherDiscount { get; set; }

        /// <summary>
        ///     Number: Sum of distance price, special_request_price,stoppoint_price (alternaltive for total_fee)
        /// </summary>
        [JsonProperty("subtotal_price")]
        public double SubtotalPrice { get; set; }

        /// <summary>
        ///     Number: Final price, equals subtotal_price - voucher_discount
        /// </summary>
        [JsonProperty("total_price")]
        public double TotalPrice { get; set; }
        #endregion
    }
}
