// -----------------------------------------------------------------------------
// <copyright file="Enums" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/3/2019 10:06:15 PM" />
// -----------------------------------------------------------------------------

namespace Stex.Net.Contracts
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;
    
    #endregion Usings

    public enum Side
    {
        BUY,
        SELL
    }

    public enum Interval
    {
        [Description("1")]
        OneM,
        [Description("5")]
        FiveM,
        [Description("30")]
        ThirtyM,
        [Description("60")]
        OneH,
        [Description("240")]
        FourH,
        [Description("720")]
        TwelveH,
        [Description("1D")]
        OneD
    }

    public enum SortOrder
    {
        ASC,
        DESC
    }

    public enum OrderStatus
    {
        ALL,
        PROCESSING,
        PENDING,
        FINISHED,
        PARTIAL,
        CANCELLED
    }

    public enum SortDirection
    {
        BALANCE,
        FROZEN,
        BONUS,
        TOTAL
    }

    public enum DepositStatus
    {
        [Description("PROCESSING")]
        Processing,
        [Description("AWAITING APPROVAL")]
        AwaitingApproval,
        [Description("FINISHED")]
        Finished,
        [Description("CANCELLED BY ADMIN")]
        CanceledByAdmin,
        [Description("DEPOSIT ERROR")]
        DepositError,
        [Description("HODL")]
        Hodl
    }
}