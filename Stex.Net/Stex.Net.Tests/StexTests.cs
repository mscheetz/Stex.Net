// -----------------------------------------------------------------------------
// <copyright file="StexTests" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="4/14/2019 3:03:03 PM" />
// -----------------------------------------------------------------------------

namespace Stex.Net.Tests
{
    #region Usings

    using FileRepository;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Xunit;

    #endregion Usings

    public class StexTests : IDisposable
    {
        #region Properties

        private string configPath = "config.json";
        private Contracts.ApiCredentials _exchangeApi;
        private readonly IStex _service;

        #endregion Properties
        
        public StexTests()
        {
            _exchangeApi = null;
            IFileRepository _fileRepo = new FileRepository();
            if (_fileRepo.FileExists(configPath))
            {
                _exchangeApi = _fileRepo.GetDataFromFile<Contracts.ApiCredentials>(configPath);
            }
            if (_exchangeApi != null)
            {
                _service = new Stex(_exchangeApi);
            }
            else
            {
                _service = new Stex();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #region Profile Api

        [Fact]
        public void GetAccountInfo_Test()
        {
            var info = _service.GetAccountInfo().Result;

            Assert.NotNull(info);
        }

        #endregion Profile Api
    }
}