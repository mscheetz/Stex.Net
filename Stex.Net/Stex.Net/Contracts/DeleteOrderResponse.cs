// -----------------------------------------------------------------------------
// <copyright file="DeleteOrderResponse" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/22/2019 8:49:54 AM" />
// -----------------------------------------------------------------------------

namespace Stex.Net.Contracts
{
    #region Usings

    using Newtonsoft.Json;
    using System.Collections.Generic;

    #endregion Usings

    public class DeleteOrderResponse
    {
        #region Properties

        [JsonProperty(PropertyName = "put_into_processing_queue")]
        public List<OrderDetail> InProcessingQueue { get; set; }

        [JsonProperty(PropertyName = "not_put_into_processing_queue")]
        public List<OrderDetail> NotInProcessingQueue { get; set; }

        #endregion Properties
    }
}