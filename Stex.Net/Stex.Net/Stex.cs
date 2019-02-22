// -----------------------------------------------------------------------------
// <copyright file="Stex" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/3/2019 9:30:34 PM" />
// -----------------------------------------------------------------------------

namespace Stex.Net
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using global::Stex.Net.Contracts;
    using global::Stex.Net.Repository;
    
    #endregion Usings

    public class Stex : RepositoryBase, IStex
    {
        #region Properties
        #endregion Properties

        #region Constructor

        public Stex() : base()
        { }

        public Stex(string apiKey, string apiSecret) : this(new ApiCredentials { ApiKey = apiKey, ApiSecret = apiSecret })
        { }

        public Stex(ApiCredentials creds) : base(creds)
        { }

        #endregion Constructor

        #region Public Api

        /// <summary>
        /// Get available currencies
        /// </summary>
        /// <returns>Collection of CurrencyDetails</returns>
        public async Task<List<CurrencyDetail>> GetCurrencies()
        {
            var endpoint = $@"/public/currencies";

            return await base.Get<List<CurrencyDetail>>(endpoint);
        }

        /// <summary>
        /// Get detail about a currency
        /// </summary>
        /// <param name="id">Currency Id</param>
        /// <returns>CurrencyDetails object</returns>
        public async Task<CurrencyDetail> GetCurrencies(int id)
        {
            var endpoint = $@"/public/currencies/{id}";

            return await base.Get<CurrencyDetail>(endpoint);
        }

        /// <summary>
        /// Get list of all avialable markets
        /// </summary>
        /// <returns>Collection of Markets</returns>
        public async Task<List<Market>> GetMarkets()
        {
            var endpoint = $@"/public/markets";

            return await base.Get<List<Market>>(endpoint);
        }

        /// <summary>
        /// Returns a list of avialable currency pairs.
        /// </summary>
        /// <returns>Collection of currency pairs</returns>
        public async Task<List<CurrencyPair>> GetCurrencyPairs()
        {
            var endpoint = $@"/public/currency_pairs/list/ALL";

            return await base.Get<List<CurrencyPair>>(endpoint);
        }

        /// <summary>
        /// Returns a list of avialable currency pairs in the given market.
        /// </summary>
        /// <param name="symbol">Market symbol</param>
        /// <returns>Collection of currency pairs</returns>
        public async Task<List<CurrencyPair>> GetCurrencyPairs(string symbol)
        {
            var endpoint = $@"/public/currency_pairs/list/{symbol}";

            return await base.Get<List<CurrencyPair>>(endpoint);
        }

        /// <summary>
        /// Returns a currency pairs.
        /// </summary>
        /// <param name="id">Currency Pair Id</param>
        /// <returns>CurrencyPair object</returns>
        public async Task<CurrencyPair> GetCurrencyPair(int id)
        {
            var endpoint = $@"/public/currency_pairs/{id}";

            return await base.Get<CurrencyPair>(endpoint);
        }

        /// <summary>
        /// Tickers list for all currency pairs
        /// </summary>
        /// <returns>Collection of Ticker</returns>
        public async Task<List<Ticker>> GetTickers()
        {
            var endpoint = $@"/public/ticker";

            return await base.Get<List<Ticker>>(endpoint);
        }

        public async Task<List<PairRate>> GetPrices()
        {
            var endpoint = $@"/prices";

            return await base.Get<List<PairRate>>(endpoint);
        }

        public async Task<List<Trade>> GetTrades(string pair)
        {
            var endpoint = $@"/trades?pair={pair}";

            var response = await base.Get<ResponseBase<List<Trade>>>(endpoint);

            return response.Data;
        }

        public async Task<OrderBook> GetOrderBook(string pair)
        {
            var endpoint = $@"/orderbook?pair={pair}";

            var response = await base.Get<ResponseBase<OrderBook>>(endpoint);

            return response.Data;
        }

        #endregion Public Api
    }
}