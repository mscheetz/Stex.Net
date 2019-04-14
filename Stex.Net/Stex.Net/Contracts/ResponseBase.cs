// -----------------------------------------------------------------------------
// <copyright file="ResponseBase" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/3/2019 10:06:59 PM" />
// -----------------------------------------------------------------------------

namespace Stex.Net.Contracts
{
    #region Usings

    using Newtonsoft.Json;

    #endregion Usings

    public class ResponseBase<T>
    {
        #region Properties

        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        [JsonProperty(PropertyName = "data")]
        public T Data { get; set; }

        #endregion Properties
    }
}