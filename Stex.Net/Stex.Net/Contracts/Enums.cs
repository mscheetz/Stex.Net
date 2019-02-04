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
        [Description("1D")]
        Day,
        [Description("1M")]
        Month,
        [Description("3M")]
        ThreeMonth,
        [Description("1Y")]
        Year
    }
}