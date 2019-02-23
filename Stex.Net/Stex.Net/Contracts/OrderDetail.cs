// -----------------------------------------------------------------------------
// <copyright file="OrderDetail" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/22/2019 8:41:31 AM" />
// -----------------------------------------------------------------------------

namespace Stex.Net.Contracts
{
    #region Usings

    using System;
    using Newtonsoft.Json;

    #endregion Usings

    public class OrderDetail
    {
        #region Properties

        [JsonProperty(PropertyName = "id")]
        public int OrderId { get; set; }

        [JsonProperty(PropertyName = "currency_pair_id")]
        public int TradingPairId { get; set; }

        [JsonProperty(PropertyName = "currency_pair")]
        public string TradingPair { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "initial_amount")]
        public decimal OrderQuantity { get; set; }

        [JsonProperty(PropertyName = "processed_amount")]
        public decimal FilledQuantity { get; set; }

        [JsonProperty(PropertyName = "type")]
        public Side Side { get; set; }

        [JsonProperty(PropertyName = "created")]
        public DateTime Created { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty(PropertyName = "status")]
        public OrderStatus OrderStatus { get; set; }

        #endregion Properties
    }
}