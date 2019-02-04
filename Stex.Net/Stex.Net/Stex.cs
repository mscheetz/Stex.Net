// -----------------------------------------------------------------------------
// <copyright file="Stex" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/3/2019 9:30:34 PM" />
// -----------------------------------------------------------------------------

namespace Stex.Net
{
    using global::Stex.Net.Contracts;
    using global::Stex.Net.Repository;
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;


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

        public async Task<List<CurrencyDetail>> GetCurrencies()
        {
            var endpoint = $@"/currencies";

            return await base.GetRequest<List<CurrencyDetail>>(endpoint);
        }

        public async Task<List<Market>> GetMarkets()
        {
            var endpoint = $@"/markets";

            return await base.GetRequest<List<Market>>(endpoint);
        }

        public async Task<Market> GetMarket(string currency1, string currency2)
        {
            var endpoint = $@"/market_summary/{currency1}/{currency2}";

            return await base.GetRequest<Market>(endpoint);
        }

        public async Task<List<Ticker>> GetTickers()
        {
            var endpoint = $@"/ticker";

            return await base.GetRequest<List<Ticker>>(endpoint);
        }

        public async Task<List<PairRate>> GetPrices()
        {
            var endpoint = $@"/prices";

            return await base.GetRequest<List<PairRate>>(endpoint);
        }

        public async Task<List<Trade>> GetTrades(string pair)
        {
            var endpoint = $@"/trades?pair={pair}";

            var response = await base.GetRequest<ResponseBase<List<Trade>>>(endpoint);

            return response.Result;
        }

        public async Task<OrderBook> GetOrderBook(string pair)
        {
            var endpoint = $@"/orderbook?pair={pair}";

            var response = await base.GetRequest<ResponseBase<OrderBook>>(endpoint);

            return response.Result;
        }

        #endregion Public Api
    }
}