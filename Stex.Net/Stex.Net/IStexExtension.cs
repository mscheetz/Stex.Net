// -----------------------------------------------------------------------------
// <copyright file="IStexExtension" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/24/2019 1:53:06 PM" />
// -----------------------------------------------------------------------------

namespace Stex.Net
{
    #region Usings

    using global::Stex.Net.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    #endregion Usings

    public static class IStexExtension
    {
        /// <summary>
        /// Get currency details
        /// </summary>
        /// <param name="symbol">Symbol of currency</param>
        /// <returns>CurrencyDetail object</returns>
        public static async Task<CurrencyDetail> GetCurrency(this IStex service, string symbol)
        {
            var currencyId = service.GetExchangeCurrencyId(symbol);

            return await service.GetCurrency(currencyId);
        }

        /// <summary>
        /// Get trading pair details
        /// </summary>
        /// <param name="pair">Trading pair</param>
        /// <returns>TradingPairDetail object</returns>
        public static async Task<TradingPairDetail> GetTradingPairDetail(this IStex service, string pair)
        {
            var pairId = service.GetExchangePairId(pair);

            return await service.GetTradingPairDetail(pairId);
        }

        /// <summary>
        /// Get ticker for a trading pair
        /// </summary>
        /// <param name="pair">Trading pair</param>
        /// <returns>Ticker object</returns>
        public static async Task<Ticker> GetTicker(this IStex service, string pair)
        {
            var pairId = service.GetExchangePairId(pair);

            return await service.GetTicker(pairId);
        }

        /// <summary>
        /// Get trades for a trading pair
        /// </summary>
        /// <param name="pair">Trading Pair</param>
        /// <param name="sort">Sort Order (default = DESC)</param>
        /// <param name="from">Timestamp from time (ms)</param>
        /// <param name="till">Timestamp till time (ms)</param>
        /// <param name="limit">Record max (default = 100)</param>
        /// <param name="offset">Offset</param>
        /// <returns>Collection of Trades</returns>
        public static async Task<List<Trade>> GetTrades(this IStex service, string pair, SortOrder sort = SortOrder.DESC, int from = 0, int till = 0, int limit = 100, int offset = 0)
        {
            var pairId = service.GetExchangePairId(pair);

            return await service.GetTrades(pairId, sort, from, till, limit, offset);

        }
    }
}