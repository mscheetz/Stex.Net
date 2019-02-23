// -----------------------------------------------------------------------------
// <copyright file="Deposit" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/22/2019 9:44:14 AM" />
// -----------------------------------------------------------------------------

namespace Stex.Net.Contracts
{
    #region Usings

    using Newtonsoft.Json;
    using System;

    #endregion Usings

    public class Deposit
    {
        #region Properties

        [JsonProperty(PropertyName = "id")]
        public int DepositId { get; set; }

        [JsonProperty(PropertyName = "currency_id")]
        public int CurrencyId { get; set; }

        [JsonProperty(PropertyName = "currency_code")]
        public string Symbol { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public decimal Quantity { get; set; }

        [JsonProperty(PropertyName = "fee")]
        public decimal Fee { get; set; }

        [JsonProperty(PropertyName = "txid")]
        public string TransactionId { get; set; }

        [JsonProperty(PropertyName = "status")]
        public DepositStatus Status { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty(PropertyName = "confirmations")]
        public string Confirmations { get; set; }

        #endregion Properties
    }
}