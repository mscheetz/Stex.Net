// -----------------------------------------------------------------------------
// <copyright file="Market" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/3/2019 9:47:34 PM" />
// -----------------------------------------------------------------------------

namespace Stex.Net.Contracts
{
    #region Usings

    using Newtonsoft.Json;

    #endregion Usings

    public class Market
    {
        #region Properties

        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        [JsonProperty(PropertyName = "partner")]
        public string Partner { get; set; }

        [JsonProperty(PropertyName = "currency_long")]
        public string CurrencyName { get; set; }

        [JsonProperty(PropertyName = "partner_long")]
        public string PartnerName { get; set; }

        [JsonProperty(PropertyName = "min_order_amount")]
        public decimal MinOrderAmount { get; set; }

        [JsonProperty(PropertyName = "min_buy_price")]
        public decimal MinBuyPrice { get; set; }

        [JsonProperty(PropertyName = "min_sell_price")]
        public decimal MinSellPrice { get; set; }

        [JsonProperty(PropertyName = "buy_fee_percent")]
        public decimal BuyFeePercent { get; set; }

        [JsonProperty(PropertyName = "sell_fee_percent")]
        public decimal SellFeePercent { get; set; }

        [JsonProperty(PropertyName = "active")]
        public bool Active { get; set; }

        [JsonProperty(PropertyName = "currency_precision")]
        public int CurrencyPrecision { get; set; }

        [JsonProperty(PropertyName = "partner_precision")]
        public int PartnerPrecision { get; set; }

        [JsonProperty(PropertyName = "market_name")]
        public string Pair { get; set; }

        #endregion Properties
    }
}