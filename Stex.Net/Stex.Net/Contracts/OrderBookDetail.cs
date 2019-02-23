// -----------------------------------------------------------------------------
// <copyright file="OrderBookDetail" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/3/2019 10:09:40 PM" />
// -----------------------------------------------------------------------------

namespace Stex.Net.Contracts
{
    #region Usings

    using Newtonsoft.Json;

    #endregion Usings

    public class OrderBookDetail
    {
        #region Properties

        [JsonProperty(PropertyName = "currency_pair_id")]
        public decimal TradingPairId { get; set; }

        [JsonProperty(PropertyName = "currency_pair")]
        public decimal TradingPair { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public decimal Quantity { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "amount2")]
        public decimal Amount2 { get; set; }

        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }

        #endregion Properties
    }
}