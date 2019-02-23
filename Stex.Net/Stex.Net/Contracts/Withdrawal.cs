// -----------------------------------------------------------------------------
// <copyright file="Withdrawal" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/22/2019 9:57:37 AM" />
// -----------------------------------------------------------------------------

namespace Stex.Net.Contracts
{
    #region Usings

    using Newtonsoft.Json;
    using System;

    #endregion Usings

    public class Withdrawal
    {
        #region Properties

        [JsonProperty(PropertyName = "id")]
        public int WithdrawlId { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public decimal Quantity { get; set; }

        [JsonProperty(PropertyName = "currency_id")]
        public int CurrencyId { get; set; }

        [JsonProperty(PropertyName = "currency_code")]
        public string Symbol { get; set; }

        [JsonProperty(PropertyName = "fee")]
        public decimal Fee { get; set; }

        [JsonProperty(PropertyName = "fee_currency_id")]
        public int FeeCurrencyId { get; set; }

        [JsonProperty(PropertyName = "fee_currency_code")]
        public int FeeSymbol { get; set; }

        [JsonProperty(PropertyName = "status")]
        public DepositStatus Status { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty(PropertyName = "created_ts")]
        public long CreatedTS { get; set; }

        [JsonProperty(PropertyName = "updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "updated_ts")]
        public long UpdatedTS { get; set; }

        [JsonProperty(PropertyName = "txid")]
        public string TransactionId { get; set; }

        [JsonProperty(PropertyName = "withdrawal_address")]
        public AddressDetail WitdrawalAddress { get; set; }

        #endregion Properties
    }
}