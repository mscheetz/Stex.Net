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
        /// <param name="currencyId">Currency Id</param>
        /// <returns>CurrencyDetails object</returns>
        public async Task<CurrencyDetail> GetCurrencies(int currencyId)
        {
            var endpoint = $@"/public/currencies/{currencyId}";

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
        /// Get all trading pair details.
        /// </summary>
        /// <returns>Collection of currency pairs</returns>
        public async Task<List<TradingPairDetail>> GetTradingPairDetails()
        {
            var endpoint = $@"/public/currency_pairs/list/ALL";

            return await base.Get<List<TradingPairDetail>>(endpoint);
        }

        /// <summary>
        /// Get all trading pair details for a given market.
        /// </summary>
        /// <param name="marketSymbol">Market symbol</param>
        /// <returns>Collection of currency pairs</returns>
        public async Task<List<TradingPairDetail>> GetTradingPairDetails(string marketSymbol)
        {
            var endpoint = $@"/public/currency_pairs/list/{marketSymbol}";

            return await base.Get<List<TradingPairDetail>>(endpoint);
        }

        /// <summary>
        /// Get trading pair details.
        /// </summary>
        /// <param name="tradingPairId">Trading Pair Id</param>
        /// <returns>CurrencyPair object</returns>
        public async Task<TradingPairDetail> GetTradingPairDetail(int tradingPairId)
        {
            var endpoint = $@"/public/currency_pairs/{tradingPairId}";

            return await base.Get<TradingPairDetail>(endpoint);
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

        /// <summary>
        /// Ticker for a currency pair
        /// </summary>
        /// <param name="tradingPairId">Trading Pair id</param>
        /// <returns>Collection of Ticker</returns>
        public async Task<Ticker> GetTicker(int tradingPairId)
        {
            var endpoint = $@"/public/ticker/{tradingPairId}";

            return await base.Get<Ticker>(endpoint);
        }

        /// <summary>
        /// Get trades for a trading pair
        /// </summary>
        /// <param name="tradingPairId">Trading Pair id</param>
        /// <param name="sort">Sort Order (default = DESC)</param>
        /// <param name="from">Timestamp from time (ms)</param>
        /// <param name="till">Timestamp till time (ms)</param>
        /// <param name="limit">Record max (default = 100)</param>
        /// <param name="offset">Offsett</param>
        /// <returns>Collection of Trades</returns>
        public async Task<List<Trade>> GetTrades(int tradingPairId, SortOrder sort = SortOrder.DESC, int from = 0, int till = 0, int limit = 100, int offset = 0)
        {
            var endpoint = $@"/public/trades/{tradingPairId}";

            var parms = new SortedDictionary<string, object>();
            if (sort != SortOrder.DESC)
            {
                parms.Add("sort", sort);
            }
            if (from != 0)
            {
                parms.Add("from", from);
            }
            if (till != 0)
            {
                parms.Add("till", till);
            }
            if (limit != 100)
            {
                parms.Add("limit", limit);
            }
            if (offset != 0)
            {
                parms.Add("offset", offset);
            }

            return await base.Get<List<Trade>>(endpoint, parms);
        }

        /// <summary>
        /// Get Order book for a trading pair
        /// </summary>
        /// <param name="tradingPairId">Trading pair id</param>
        /// <param name="bids">Bit limit (default 100)</param>
        /// <param name="asks">Ask limit (default 100)</param>
        /// <returns>Orderbook object</returns>
        public async Task<OrderBook> GetOrderBook(int tradingPairId, int bids = 100, int asks = 100)
        {
            var endpoint = $@"/public/orderbook/{tradingPairId}";

            var parms = new SortedDictionary<string, object>();
            if (bids != 100)
            {
                parms.Add("limit_bids", bids);
            }
            if (asks != 100)
            {
                parms.Add("limit_asks", asks);
            }

            return await base.Get<OrderBook>(endpoint, parms);
        }

        /// <summary>
        /// Get candlesticks for a trading pair
        /// </summary>
        /// <param name="tradingPairId">Trading pair id</param>
        /// <param name="interval">Candle interval</param>
        /// <param name="start">Start time (ms)</param>
        /// <param name="end">End time (ms)</param>
        /// <param name="limit">Candlesticks to return (default 100)</param>
        /// <param name="offset">Offset</param>
        /// <returns></returns>
        public async Task<List<Candlestick>> GetCandlesticks(int tradingPairId, Interval interval, int start, int end, int limit = 100, int offset = 0)
        {
            var intervalDescription = interval.ToString();
            var endpoint = $@"/public/chart/{tradingPairId}/{intervalDescription}";

            var parms = new SortedDictionary<string, object>();
            parms.Add("timeStart", start);
            parms.Add("timeEnd", end);
            if(limit != 100)
            {
                parms.Add("limit", limit);
            }
            if (offset != 0)
            {
                parms.Add("offset", offset);
            }

            return await base.Get<List<Candlestick>>(endpoint, parms);
        }

        /// <summary>
        /// Ping exchange's API server
        /// </summary>
        /// <returns>PingResponse object</returns>
        public async Task<PingResponse> Ping()
        {
            var endpoint = "/public/ping";

            return await base.Get<PingResponse>(endpoint);
        }

        #endregion Public Api

        #region Trading Api

        /// <summary>
        /// Get all open orders for current account
        /// </summary>
        /// <returns>Collection of OrderDetail objects</returns>
        public async Task<List<OrderDetail>> GetOpenOrders()
        {
            var endpoint = $@"/trading/orders";

            return await base.Get<List<OrderDetail>>(endpoint, true);
        }

        /// <summary>
        /// Delete all open orders
        /// </summary>
        /// <returns>DeleteOrderResponse object</returns>
        public async Task<DeleteOrderResponse> CancelOrders()
        {
            var endpoint = $@"/trading/orders";

            return await base.Delete<DeleteOrderResponse>(endpoint);
        }

        /// <summary>
        /// Get all open orders for a trading pair for current account
        /// </summary>
        /// <param name="tradingPairId">Trading pair id</param>
        /// <returns>Collection of OrderDetail objects</returns>
        public async Task<List<OrderDetail>> GetOpenOrders(int tradingPairId)
        {
            var endpoint = $@"/trading/orders/{tradingPairId}";

            return await base.Get<List<OrderDetail>>(endpoint, true);
        }

        /// <summary>
        /// Delete all open orders for a trading pair
        /// </summary>
        /// <param name="tradingPairId">Trading pair id</param>
        /// <returns>DeleteOrderResponse object</returns>
        public async Task<DeleteOrderResponse> CancelOrders(int tradingPairId)
        {
            var endpoint = $@"/trading/orders/{tradingPairId}";

            return await base.Delete<DeleteOrderResponse>(endpoint);
        }

        /// <summary>
        /// Place an order
        /// </summary>
        /// <param name="tradingPairId">Trading pair id</param>
        /// <param name="side">Side of order</param>
        /// <param name="quantity">Order quantity</param>
        /// <param name="price">Order price</param>
        /// <returns>OrderDetail object</returns>
        public async Task<OrderDetail> PlaceOrder(int tradingPairId, Side side, decimal quantity, decimal price)
        {
            var endpoint = $@"/trading/orders/{tradingPairId}";

            var parms = new SortedDictionary<string, object>();
            parms.Add("type", side);
            parms.Add("amount", quantity);
            parms.Add("price", price);

            return await base.Post<OrderDetail>(endpoint, parms);
        }

        /// <summary>
        /// Get an order
        /// </summary>
        /// <param name="orderId">Order id</param>
        /// <returns>OrderDetail object</returns>
        public async Task<OrderDetail> GetOrder(int orderId)
        {
            var endpoint = $@"/trading/order/{orderId}";

            return await base.Get<OrderDetail>(endpoint);
        }

        /// <summary>
        /// Cancel an order
        /// </summary>
        /// <param name="orderId">Order id</param>
        /// <returns>DeletedOrderResponse object</returns>
        public async Task<DeleteOrderResponse> CancelOrder(int orderId)
        {
            var endpoint = $@"/trading/order/{orderId}";

            return await base.Delete<DeleteOrderResponse>(endpoint);
        }

        #endregion Trading Api

        #region Trading History Api

        /// <summary>
        /// Get order details
        /// </summary>
        /// <param name="tradingPairId">Trading pair id</param>
        /// <param name="orderStatus">Order Status</param>
        /// <param name="from">From Date</param>
        /// <param name="to">To Date</param>
        /// <param name="limit">Response Limit</param>
        /// <param name="offset">Offset</param>
        /// <returns>Collection of OrderDetail objects</returns>
        public async Task<List<OrderDetail>> GetOrders(int tradingPairId = 0, OrderStatus orderStatus = OrderStatus.ALL, DateTime? from = null, DateTime? to = null, int limit = 100, int offset = 0)
        {
            var endpoint = $@"/reports/orders";

            var parms = new SortedDictionary<string, object>();
            if (tradingPairId != 0)
            {
                parms.Add("currencyPairId", tradingPairId);
            }
            if (orderStatus != OrderStatus.ALL)
            {
                parms.Add("orderStatus", orderStatus);
            }
            if (from != null)
            {
                parms.Add("timeStart", from);
            }
            if (to != null)
            {
                parms.Add("timeEnd", to);
            }
            if (limit != 100)
            {
                parms.Add("limit", limit);
            }
            if (offset != 0)
            {
                parms.Add("offset", offset);
            }
            
            return await base.Get<List<OrderDetail>>(endpoint, parms, true);
        }

        /// <summary>
        /// Get Fills and Fees for an order
        /// </summary>
        /// <param name="orderId">Order Id</param>
        /// <returns>Detailed Order Details</returns>
        public async Task<OrderDetailPlus> GetDetailedOrder(int orderId)
        {
            var endpoint = $@"/reports/orders/{orderId}";

            return await base.Get<OrderDetailPlus>(endpoint, true);
        }

        #endregion Trading History Api

        #region Profile Api

        /// <summary>
        /// Get current account information
        /// </summary>
        /// <returns>AccountInfo object</returns>
        public async Task<AccountInfo> GetAccountInfo()
        {
            var endpoint = $@"/profile/info";

            return await base.Get<AccountInfo>(endpoint, true);
        }

        /// <summary>
        /// Get account balances
        /// </summary>
        /// <param name="sort">Sort direction (default DESC)</param>
        /// <param name="sortBy">Sort by (default BALANCE)</param>
        /// <returns>Collection of Wallet balances</returns>
        public async Task<List<Wallet>> GetBalances(SortOrder sort = SortOrder.DESC, SortDirection sortBy = SortDirection.BALANCE )
        {
            var endpoint = $@"/profile/wallets";

            var parms = new SortedDictionary<string, object>();
            if (sort != SortOrder.DESC)
            {
                parms.Add("sort", sort);
            }
            if (sortBy != SortDirection.BALANCE)
            {
                parms.Add("sortBy", sortBy);
            }

            return await base.Get<List<Wallet>>(endpoint, parms, true);
        }

        /// <summary>
        /// Get balance for a wallet
        /// </summary>
        /// <param name="walletId">Wallet id</param>
        /// <returns>Wallet balances</returns>
        public async Task<WalletPlus> GetBalance(int walletId)
        {
            var endpoint = $@"/profile/wallets/{walletId}";
            
            return await base.Get<WalletPlus>(endpoint, true);
        }

        /// <summary>
        /// Create a wallet
        /// </summary>
        /// <param name="currencyId">Currency id</param>
        /// <returns>Wallet object</returns>
        public async Task<WalletPlus> CreateWallet(int currencyId)
        {
            var endpoint = $@"/profile/wallets/{currencyId}";

            return await base.Post<WalletPlus>(endpoint);
        }

        /// <summary>
        /// Get deposit address for a wallet
        /// </summary>
        /// <param name="walletId">Wallet id</param>
        /// <returns>Deposit Address</returns>
        public async Task<AddressDetail> GetDepositAddress(int walletId)
        {
            var endpoint = $@"/profile/wallets/address/{walletId}";

            return await base.Get<AddressDetail>(endpoint, true);
        }

        /// <summary>
        /// Create deposit address for a wallet
        /// </summary>
        /// <param name="walletId">Wallet id</param>
        /// <returns>Deposit Address</returns>
        public async Task<AddressDetail> CreateDepositAddress(int walletId)
        {
            var endpoint = $@"/profile/wallets/address/{walletId}";

            return await base.Post<AddressDetail>(endpoint, true);
        }

        /// <summary>
        /// Get Deposits
        /// </summary>
        /// <param name="currencyId">Currency id</param>
        /// <param name="sortOrder">Sort order</param>
        /// <param name="start">Start timestamp</param>
        /// <param name="end">End timestamp</param>
        /// <param name="limit">Response limit</param>
        /// <param name="offset">Offset</param>
        /// <returns>Collection of deposits</returns>
        public async Task<List<Deposit>> GetDeposits(int currencyId = 0, SortOrder sortOrder = SortOrder.DESC, long start = 0, long end = 0, int limit = 100, int offset = 0)
        {
            var endpoint = $@"/profile/deposits";
            var parms = new SortedDictionary<string, object>();
            if(currencyId != 0)
            {
                parms.Add("currencyId", currencyId);
            }
            if (sortOrder != SortOrder.DESC)
            {
                parms.Add("sort", sortOrder);
            }
            if (start != 0)
            {
                parms.Add("timeStart", start);
            }
            if (end != 0)
            {
                parms.Add("timeEnd", end);
            }
            if (limit != 100)
            {
                parms.Add("limit", limit);
            }
            if (offset != 0)
            {
                parms.Add("offset", offset);
            }
        
            return await base.Get<List<Deposit>>(endpoint, parms, true);
        }

        /// <summary>
        /// Get a deposit
        /// </summary>
        /// <param name="depositId">Deposit Id</param>
        /// <returns>Deposit object</returns>
        public async Task<Deposit> GetDeposits(int depositId)
        {
            var endpoint = $@"/profile/deposits/{depositId}";
            
            return await base.Get<Deposit>(endpoint, true);
        }

        /// <summary>
        /// Get Withdrawals
        /// </summary>
        /// <param name="currencyId">Currency id</param>
        /// <param name="sortOrder">Sort order</param>
        /// <param name="start">Start timestamp</param>
        /// <param name="end">End timestamp</param>
        /// <param name="limit">Response limit</param>
        /// <param name="offset">Offset</param>
        /// <returns>Collection of withdrawals</returns>
        public async Task<List<Withdrawal>> GetWithdrawals(int currencyId = 0, SortOrder sortOrder = SortOrder.DESC, long start = 0, long end = 0, int limit = 100, int offset = 0)
        {
            var endpoint = $@"/profile/withdrawals";
            var parms = new SortedDictionary<string, object>();
            if (currencyId != 0)
            {
                parms.Add("currencyId", currencyId);
            }
            if (sortOrder != SortOrder.DESC)
            {
                parms.Add("sort", sortOrder);
            }
            if (start != 0)
            {
                parms.Add("timeStart", start);
            }
            if (end != 0)
            {
                parms.Add("timeEnd", end);
            }
            if (limit != 100)
            {
                parms.Add("limit", limit);
            }
            if (offset != 0)
            {
                parms.Add("offset", offset);
            }

            return await base.Get<List<Withdrawal>>(endpoint, parms, true);
        }

        /// <summary>
        /// Get a withdrawal
        /// </summary>
        /// <param name="withdrawalId">Withdrawal Id</param>
        /// <returns>Withdrawal object</returns>
        public async Task<Deposit> GetWithdrawal(int withdrawalId)
        {
            var endpoint = $@"/profile/withdrawals/{withdrawalId}";

            return await base.Get<Deposit>(endpoint, true);
        }

        #endregion Profile Api
    }
}