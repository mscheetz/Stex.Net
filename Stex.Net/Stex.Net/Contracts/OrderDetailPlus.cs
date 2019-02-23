// -----------------------------------------------------------------------------
// <copyright file="OrderDetailPlus" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/22/2019 8:41:31 AM" />
// -----------------------------------------------------------------------------

namespace Stex.Net.Contracts
{
    #region Usings

    using Newtonsoft.Json;
    using System.Collections.Generic;
    

    #endregion Usings

    public class OrderDetailPlus : OrderDetail
    {
        #region Properties

        [JsonProperty(PropertyName = "trades")]
        public List<Fill> Fills { get; set; }

        [JsonProperty(PropertyName = "fees")]
        public List<OrderFee> Fees { get; set; }

        #endregion Properties
    }
}