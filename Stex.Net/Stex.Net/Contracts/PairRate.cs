// -----------------------------------------------------------------------------
// <copyright file="PairRate" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/3/2019 10:00:46 PM" />
// -----------------------------------------------------------------------------

namespace Stex.Net.Contracts
{
    #region Usings

    using Newtonsoft.Json;

    #endregion Usings

    public class PairRate
    {
        #region Properties

        [JsonProperty(PropertyName = "buy")]
        public decimal Buy { get; set; }

        [JsonProperty(PropertyName = "sell")]
        public decimal Sell { get; set; }

        [JsonProperty(PropertyName = "market_name")]
        public string Pair { get; set; }

        [JsonProperty(PropertyName = "updated_time")]
        public long UpdatedTime { get; set; }

        [JsonProperty(PropertyName = "Server_time")]
        public long ServerTime { get; set; }

        #endregion Properties
    }
}