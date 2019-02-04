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

        [JsonProperty(PropertyName = "currency")]
        public string Symbol { get; set; }

        [JsonProperty(PropertyName = "active")]
        public bool Active { get; set; }

        [JsonProperty(PropertyName = "precision")]
        public int Precision { get; set; }

        [JsonProperty(PropertyName = "api_precision")]
        public int ApiPrecision { get; set; }

        [JsonProperty(PropertyName = "minimum_withdrawal_amount")]
        public decimal MinWithdrawalAmount { get; set; }

        [JsonProperty(PropertyName = "minimum_deposit_amount")]
        public decimal MinDepositAmount { get; set; }

        [JsonProperty(PropertyName = "calculated_balance")]
        public decimal Balance { get; set; }

        [JsonProperty(PropertyName = "deposit_fee_currency")]
        public string DepositFeeSymbol { get; set; }

        [JsonProperty(PropertyName = "deposit_fee_const")]
        public decimal DepositFeeConstant { get; set; }

        [JsonProperty(PropertyName = "deposit_fee_percent")]
        public decimal DepositFeePercent { get; set; }

        [JsonProperty(PropertyName = "withdrawal_fee_currency")]
        public string WithdrawalFeeSymbol { get; set; }

        [JsonProperty(PropertyName = "withdrawal_fee_const")]
        public string WithdrawalFeeConstant { get; set; }

        [JsonProperty(PropertyName = "withdrawal_fee_percent")]
        public decimal WithdrawalFeePercent { get; set; }

        [JsonProperty(PropertyName = "currency_long")]
        public string Name { get; set; }

        #endregion Properties
    }
}