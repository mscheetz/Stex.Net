// -----------------------------------------------------------------------------
// <copyright file="Ticker" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/3/2019 9:56:16 PM" />
// -----------------------------------------------------------------------------

namespace Stex.Net.Contracts
{
    #region Usings

    using Newtonsoft.Json;

    #endregion Usings

    public class Ticker
    {
        #region Properties

        [JsonProperty(PropertyName = "min_order_amount")]
        public decimal MinOrderAmount { get; set; }

        [JsonProperty(PropertyName = "ask")]
        public decimal Ask { get; set; }

        [JsonProperty(PropertyName = "bid")]
        public decimal Bid { get; set; }

        [JsonProperty(PropertyName = "last")]
        public decimal Last { get; set; }

        [JsonProperty(PropertyName = "lastDayAgo")]
        public int LastDayAgo { get; set; }

        [JsonProperty(PropertyName = "vol")]
        public decimal Volume { get; set; }

        [JsonProperty(PropertyName = "spread")]
        public decimal Spread { get; set; }

        [JsonProperty(PropertyName = "buy_fee_percent")]
        public decimal BuyFeePercent { get; set; }

        [JsonProperty(PropertyName = "sell_fee_percent")]
        public decimal SellFeePercent { get; set; }

        [JsonProperty(PropertyName = "market_name")]
        public string Pair { get; set; }

        [JsonProperty(PropertyName = "updated_time")]
        public long UpdatedTime { get; set; }

        [JsonProperty(PropertyName = "Server_time")]
        public long ServerTime { get; set; }


        #endregion Properties
    }
}