// -----------------------------------------------------------------------------
// <copyright file="AddressDetail" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/22/2019 9:37:39 AM" />
// -----------------------------------------------------------------------------

namespace Stex.Net.Contracts
{
    #region Usings

    using Newtonsoft.Json;

    #endregion Usings

    public class AddressDetail
    {
        #region Properties

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "address_name")]
        public string AddressName { get; set; }

        [JsonProperty(PropertyName = "additional_address_parameter")]
        public string AddressExtra { get; set; }

        [JsonProperty(PropertyName = "addtional_address_parameter_name")]
        public string AddressExtraName { get; set; }

        #endregion Properties
    }
}