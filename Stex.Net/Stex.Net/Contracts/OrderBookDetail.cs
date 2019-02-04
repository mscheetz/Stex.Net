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

        [JsonProperty(PropertyName = "Quantity")]
        public decimal Quantity { get; set; }

        [JsonProperty(PropertyName = "Rate")]
        public decimal Rate { get; set; }

        #endregion Properties
    }
}