// -----------------------------------------------------------------------------
// <copyright file="CurrencyDetail" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/3/2019 9:41:04 PM" />
// -----------------------------------------------------------------------------

namespace Stex.Net.Contracts
{
    #region Usings

    using Newtonsoft.Json;

    #endregion Usings

    public class CurrencyDetail
    {
        #region Properties

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "code")]
        public string Symbol { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "active")]
        public bool Active { get; set; }

        [JsonProperty(PropertyName = "delisted")]
        public bool Delisted { get; set; }

        [JsonProperty(PropertyName = "precision")]
        public int Precision { get; set; }

        [JsonProperty(PropertyName = "minimum_withdrawal_amount")]
        public decimal MinWithdrawalAmount { get; set; }

        [JsonProperty(PropertyName = "minimum_deposit_amount")]
        public decimal MinDepositAmount { get; set; }

        [JsonProperty(PropertyName = "deposit_fee_currency_id")]
        public int DepositFeeId { get; set; }

        [JsonProperty(PropertyName = "deposit_fee_currency")]
        public string DepositFeeCurrency { get; set; }

        [JsonProperty(PropertyName = "deposit_fee_const")]
        public decimal DepositFeeConstant { get; set; }

        [JsonProperty(PropertyName = "deposit_fee_percent")]
        public decimal DepositFeePercent { get; set; }

        [JsonProperty(PropertyName = "withdrawal_fee_currency_id")]
        public int WithdrawalFeeId { get; set; }

        [JsonProperty(PropertyName = "withdrawal_fee_currency")]
        public string WithdrawalFeeCurrency { get; set; }

        [JsonProperty(PropertyName = "withdrawal_fee_const")]
        public string WithdrawalFeeConstant { get; set; }

        [JsonProperty(PropertyName = "withdrawal_fee_percent")]
        public decimal WithdrawalFeePercent { get; set; }

        [JsonProperty(PropertyName = "block_explorer_url")]
        public string BlockExplorerUrl { get; set; }

        #endregion Properties
    }
}