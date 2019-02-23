// -----------------------------------------------------------------------------
// <copyright file="Wallet" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/22/2019 9:27:34 AM" />
// -----------------------------------------------------------------------------

namespace Stex.Net.Contracts
{
    #region Usings

    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Text;


    #endregion Usings

    public class Wallet
    {
        #region Properties

        [JsonProperty(PropertyName = "id")]
        public int WalletId { get; set; }

        [JsonProperty(PropertyName = "currency_id")]
        public int CurrencyId { get; set; }
        
        [JsonProperty(PropertyName = "delisted")]
        public bool Delisted { get; set; }

        [JsonProperty(PropertyName = "disabled")]
        public bool Disabled { get; set; }

        [JsonProperty(PropertyName = "disable_deposits")]
        public bool DisabledDeposits { get; set; }

        [JsonProperty(PropertyName = "currency_code")]
        public string Symbol { get; set; }

        [JsonProperty(PropertyName = "balance")]
        public decimal Balance { get; set; }

        [JsonProperty(PropertyName = "frozen_balance")]
        public decimal Frozen { get; set; }

        [JsonProperty(PropertyName = "bonus_balance")]
        public decimal Bonus { get; set; }

        #endregion Properties
    }
}