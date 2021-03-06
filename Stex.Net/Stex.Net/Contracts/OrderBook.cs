// -----------------------------------------------------------------------------
// <copyright file="OrderBook" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/3/2019 10:10:45 PM" />
// -----------------------------------------------------------------------------

namespace Stex.Net.Contracts
{
    #region Usings

    using Newtonsoft.Json;
    using System.Collections.Generic;

    #endregion Usings

    public class OrderBook
    {
        #region Properties

        [JsonProperty(PropertyName = "bid")]
        public List<OrderBookDetail> Bids { get; set; }

        [JsonProperty(PropertyName = "ask")]
        public List<OrderBookDetail> Asks { get; set; }

        #endregion Properties
    }
}