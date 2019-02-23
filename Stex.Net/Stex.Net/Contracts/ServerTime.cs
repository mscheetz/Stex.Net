// -----------------------------------------------------------------------------
// <copyright file="ServerTime" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/22/2019 8:37:12 AM" />
// -----------------------------------------------------------------------------

namespace Stex.Net.Contracts
{
    #region Usings

    using System;
    using Newtonsoft.Json;

    #endregion Usings

    public class ServerTime
    {
        #region Properties

        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "timezone_type")]
        public int TimezoneType { get; set; }

        [JsonProperty(PropertyName = "timezone")]
        public string Timezone { get; set; }

        #endregion Properties
    }
}