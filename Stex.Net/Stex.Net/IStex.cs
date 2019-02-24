// -----------------------------------------------------------------------------
// <copyright file="IStex" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/3/2019 9:32:16 PM" />
// -----------------------------------------------------------------------------

namespace Stex.Net
{
    #region Usings

    using global::Stex.Net.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    #endregion Usings

    public interface IStex
    {
        #region Public Methods

        /// <summary>
        /// Get all exchange currencies
        /// </summary>
        /// <returns>Dictionary of currencies and associated ids</returns>
        Dictionary<string, string> GetExchangeCurrencies();

        /// <summary>
        /// Get all exchange trading pairs
        /// </summary>
        /// <returns>Dictionary of trading pairs and associated ids</returns>
        Dictionary<string, string> GetExchangePairs();

        /// <summary>
        /// Get exchange id for a currency
        /// </summary>
        /// <param name="symbol">Currency symbol</param>
        /// <returns>Currency Id</returns>
        int GetExchangeCurrencyId(string symbol);

        /// <summary>
        /// Get exchange id for a trading pair
        /// </summary>
        /// <param name="pair">Trading pair</param>
        /// <returns>Trading Pair Id</returns>
        int GetExchangePairId(string pair);

        #endregion Public Methods

        #region Public Api

        /// <summary>
        /// Get available currencies
        /// </summary>
        /// <returns>Collection of CurrencyDetails</returns>
        Task<List<CurrencyDetail>> GetCurrencies();

        /// <summary>
        /// Get detail about a currency
        /// </summary>
        /// <param name="currencyId">Currency Id</param>
        /// <returns>CurrencyDetails object</returns>
        Task<CurrencyDetail> GetCurrency(int currencyId);

        /// <summary>
        /// Get list of all avialable markets
        /// </summary>
        /// <returns>Collection of Markets</returns>
        Task<List<Market>> GetMarkets();

        /// <summary>
        /// Get all trading pair details.
        /// </summary>
        /// <returns>Collection of currency pairs</returns>
        Task<List<TradingPairDetail>> GetTradingPairDetails();

        /// <summary>
        /// Get all trading pair details for a given market.
        /// </summary>
        /// <param name="marketSymbol">Market symbol</param>
        /// <returns>Collection of currency pairs</returns>
        Task<List<TradingPairDetail>> GetTradingPairDetails(string marketSymbol);

        /// <summary>
        /// Get trading pair details.
        /// </summary>
        /// <param name="tradingPairId">Trading Pair Id</param>
        /// <returns>CurrencyPair object</returns>
        Task<TradingPairDetail> GetTradingPairDetail(int tradingPairId);

        /// <summary>
        /// Tickers list for all currency pairs
        /// </summary>
        /// <returns>Collection of Ticker</returns>
        Task<List<Ticker>> GetTickers();

        /// <summary>
        /// Ticker for a currency pair
        /// </summary>
        /// <param name="tradingPairId">Trading Pair id</param>
        /// <returns>Collection of Ticker</returns>
        Task<Ticker> GetTicker(int tradingPairId);

        /// <summary>
        /// Get trades for a trading pair
        /// </summary>
        /// <param name="tradingPairId">Trading Pair id</param>
        /// <param name="sort">Sort Order (default = DESC)</param>
        /// <param name="from">Timestamp from time (ms)</param>
        /// <param name="till">Timestamp till time (ms)</param>
        /// <param name="limit">Record max (default = 100)</param>
        /// <param name="offset">Offset</param>
        /// <returns>Collection of Trades</returns>
        Task<List<Trade>> GetTrades(int tradingPairId, SortOrder sort = SortOrder.DESC, int from = 0, int till = 0, int limit = 100, int offset = 0);

        /// <summary>
        /// Get Order book for a trading pair
        /// </summary>
        /// <param name="tradingPairId">Trading pair id</param>
        /// <param name="bids">Bit limit (default 100)</param>
        /// <param name="asks">Ask limit (default 100)</param>
        /// <returns>Orderbook object</returns>
        Task<OrderBook> GetOrderBook(int tradingPairId, int bids = 100, int asks = 100);

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
        Task<List<Candlestick>> GetCandlesticks(int tradingPairId, Interval interval, int start, int end, int limit = 100, int offset = 0);

        /// <summary>
        /// Ping exchange's API server
        /// </summary>
        /// <returns>PingResponse object</returns>
        Task<PingResponse> Ping();

        #endregion Public Api

        #region Trading Api

        /// <summary>
        /// Get all open orders for current account
        /// </summary>
        /// <returns>Collection of OrderDetail objects</returns>
        Task<List<OrderDetail>> GetOpenOrders();

        /// <summary>
        /// Delete all open orders
        /// </summary>
        /// <returns>DeleteOrderResponse object</returns>
        Task<DeleteOrderResponse> CancelOrders();

        /// <summary>
        /// Get all open orders for a trading pair for current account
        /// </summary>
        /// <param name="tradingPairId">Trading pair id</param>
        /// <returns>Collection of OrderDetail objects</returns>
        Task<List<OrderDetail>> GetOpenOrders(int tradingPairId);

        /// <summary>
        /// Delete all open orders for a trading pair
        /// </summary>
        /// <param name="tradingPairId">Trading pair id</param>
        /// <returns>DeleteOrderResponse object</returns>
        Task<DeleteOrderResponse> CancelOrders(int tradingPairId);

        /// <summary>
        /// Place an order
        /// </summary>
        /// <param name="tradingPairId">Trading pair id</param>
        /// <param name="side">Side of order</param>
        /// <param name="quantity">Order quantity</param>
        /// <param name="price">Order price</param>
        /// <returns>OrderDetail object</returns>
        Task<OrderDetail> PlaceOrder(int tradingPairId, Side side, decimal quantity, decimal price);

        /// <summary>
        /// Get an order
        /// </summary>
        /// <param name="orderId">Order id</param>
        /// <returns>OrderDetail object</returns>
        Task<OrderDetail> GetOrder(int orderId);

        /// <summary>
        /// Cancel an order
        /// </summary>
        /// <param name="orderId">Order id</param>
        /// <returns>DeletedOrderResponse object</returns>
        Task<DeleteOrderResponse> CancelOrder(int orderId);

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
        Task<List<OrderDetail>> GetOrders(int tradingPairId = 0, OrderStatus orderStatus = OrderStatus.ALL, DateTime? from = null, DateTime? to = null, int limit = 100, int offset = 0);

        /// <summary>
        /// Get Fills and Fees for an order
        /// </summary>
        /// <param name="orderId">Order Id</param>
        /// <returns>Detailed Order Details</returns>
        Task<OrderDetailPlus> GetDetailedOrder(int orderId);

        #endregion Trading History Api

        #region Profile Api

        /// <summary>
        /// Get current account information
        /// </summary>
        /// <returns>AccountInfo object</returns>
        Task<AccountInfo> GetAccountInfo();

        /// <summary>
        /// Get account balances
        /// </summary>
        /// <param name="sort">Sort direction (default DESC)</param>
        /// <param name="sortBy">Sort by (default BALANCE)</param>
        /// <returns>Collection of Wallet balances</returns>
        Task<List<Wallet>> GetBalances(SortOrder sort = SortOrder.DESC, SortDirection sortBy = SortDirection.BALANCE);

        /// <summary>
        /// Get balance for a wallet
        /// </summary>
        /// <param name="walletId">Wallet id</param>
        /// <returns>Wallet balances</returns>
        Task<WalletPlus> GetBalance(int walletId);

        /// <summary>
        /// Create a wallet
        /// </summary>
        /// <param name="currencyId">Currency id</param>
        /// <returns>Wallet object</returns>
        Task<WalletPlus> CreateWallet(int currencyId);

        /// <summary>
        /// Get deposit address for a wallet
        /// </summary>
        /// <param name="walletId">Wallet id</param>
        /// <returns>Deposit Address</returns>
        Task<AddressDetail> GetDepositAddress(int walletId);

        /// <summary>
        /// Create deposit address for a wallet
        /// </summary>
        /// <param name="walletId">Wallet id</param>
        /// <returns>Deposit Address</returns>
        Task<AddressDetail> CreateDepositAddress(int walletId);

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
        Task<List<Deposit>> GetDeposits(int currencyId = 0, SortOrder sortOrder = SortOrder.DESC, long start = 0, long end = 0, int limit = 100, int offset = 0);

        /// <summary>
        /// Get a deposit
        /// </summary>
        /// <param name="depositId">Deposit Id</param>
        /// <returns>Deposit object</returns>
        Task<Deposit> GetDeposits(int depositId);

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
        Task<List<Withdrawal>> GetWithdrawals(int currencyId = 0, SortOrder sortOrder = SortOrder.DESC, long start = 0, long end = 0, int limit = 100, int offset = 0);

        /// <summary>
        /// Get a withdrawal
        /// </summary>
        /// <param name="withdrawalId">Withdrawal Id</param>
        /// <returns>Withdrawal object</returns>
        Task<Withdrawal> GetWithdrawal(int withdrawalId);

        /// <summary>
        /// Create a withdrawal
        /// </summary>
        /// <param name="currencyId">Currency Id</param>
        /// <param name="quantity">Quantity to withdrawal</param>
        /// <param name="address">Address to withdrawal to</param>
        /// <param name="memo">Memo for address (not required)</param>
        /// <returns></returns>
        Task<Withdrawal> Withdrawal(int currencyId, decimal quantity, string address, string memo = "");

        /// <summary>
        /// Cancel an unconfirmed withdrawal
        /// </summary>
        /// <param name="withdrawalId">Withdrawal Id</param>
        /// <returns>Boolean of cancellation attempt</returns>
        Task<bool> CancelWithdrawal(int withdrawalId);

        #endregion Profile Api
    }
}