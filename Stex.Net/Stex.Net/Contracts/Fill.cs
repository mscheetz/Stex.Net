// -----------------------------------------------------------------------------
// <copyright file="Fill" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/22/2019 9:15:11 AM" />
// -----------------------------------------------------------------------------

namespace Stex.Net.Contracts
{
    #region Usings

    using Newtonsoft.Json;

    #endregion Usings

    public class Fill
    {
        #region Properties

        [JsonProperty(PropertyName = "id")]
        public int FillId { get; set; }

        [JsonProperty(PropertyName = "buy_order_id")]
        public int BuyOrderId { get; set; }

        [JsonProperty(PropertyName = "sell_order_id")]
        public int SellorderId { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public decimal Quantity { get; set; }

        [JsonProperty(PropertyName = "trade_type")]
        public Side Side { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public long Timestamp { get; set; }

        #endregion Properties
    }
}