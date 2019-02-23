// -----------------------------------------------------------------------------
// <copyright file="Candlestick" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/22/2019 8:32:41 AM" />
// -----------------------------------------------------------------------------

namespace Stex.Net.Contracts
{
    #region Usings

    using Newtonsoft.Json;

    #endregion Usings

    public class Candlestick
    {
        #region Properties

        [JsonProperty(PropertyName = "time")]
        public long Time { get; set; }

        [JsonProperty(PropertyName = "open")]
        public decimal Open { get; set; }

        [JsonProperty(PropertyName = "clsoe")]
        public decimal Close { get; set; }

        [JsonProperty(PropertyName = "low")]
        public decimal Low { get; set; }

        [JsonProperty(PropertyName = "high")]
        public decimal High { get; set; }

        [JsonProperty(PropertyName = "volume")]
        public decimal Volume { get; set; }

        #endregion Properties
    }
}