// -----------------------------------------------------------------------------
// <copyright file="AccountInfo" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/22/2019 9:25:54 AM" />
// -----------------------------------------------------------------------------

namespace Stex.Net.Contracts
{
    #region Usings

    using Newtonsoft.Json;
    
    #endregion Usings

    public class AccountInfo
    {
        #region Properties

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        #endregion Properties
    }
}