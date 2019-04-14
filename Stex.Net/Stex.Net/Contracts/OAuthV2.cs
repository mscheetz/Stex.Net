// -----------------------------------------------------------------------------
// <copyright file="OAuthV2" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="4/14/2019 3:27:10 PM" />
// -----------------------------------------------------------------------------

namespace Stex.Net.Contracts
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Text;

    #endregion Usings

    public class OAuthV2
    {
        #region Properties

        public int ClientId { get; set; }

        public string ClientName { get; set; }

        public string[] RedirectUrls { get; set; }

        public string ClientSecret { get; set; }

        #endregion Properties
    }
}