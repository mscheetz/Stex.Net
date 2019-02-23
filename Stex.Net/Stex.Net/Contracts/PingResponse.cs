// -----------------------------------------------------------------------------
// <copyright file="PingResponse" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/22/2019 8:35:33 AM" />
// -----------------------------------------------------------------------------

namespace Stex.Net.Contracts
{
    #region Usings

    using Newtonsoft.Json;

    #endregion Usings

    public class PingResponse
    {
        #region Properties

        [JsonProperty(PropertyName = "server_datetime")]
        public ServerTime ServerDateTime { get; set; }

        [JsonProperty(PropertyName = "server_timestamp")]
        public long Timestamp { get; set; }

        #endregion Properties
    }
}