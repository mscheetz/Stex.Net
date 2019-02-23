// -----------------------------------------------------------------------------
// <copyright file="WalletPlus" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/22/2019 9:39:21 AM" />
// -----------------------------------------------------------------------------

namespace Stex.Net.Contracts
{
    #region Usings

    using Newtonsoft.Json;

    #endregion Usings

    public class WalletPlus : Wallet
    {
        #region Properties

        [JsonProperty(PropertyName = "deposit_address")]
        public AddressDetail DepositAddress { get; set; }

        #endregion Properties
    }
}