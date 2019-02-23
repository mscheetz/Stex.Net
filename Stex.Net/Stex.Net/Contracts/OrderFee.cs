// -----------------------------------------------------------------------------
// <copyright file="OrderFee" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/22/2019 9:17:55 AM" />
// -----------------------------------------------------------------------------

namespace Stex.Net.Contracts
{
    #region Usings

    using Newtonsoft.Json;

    #endregion Usings

    public class OrderFee
    {
        #region Properties

        [JsonProperty(PropertyName = "id")]
        public int FeeId { get; set; }

        [JsonProperty(PropertyName = "currency_id")]
        public int FeeCurrencyId { get; set; }

        [JsonProperty(PropertyName = "currency_symbol")]
        public int FeeCurrency { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public decimal Quantity { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public long Timestamp { get; set; }

        #endregion Properties
    }
}