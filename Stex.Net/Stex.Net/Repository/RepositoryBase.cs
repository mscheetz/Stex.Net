// -----------------------------------------------------------------------------
// <copyright file="RepositoryBase" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/3/2019 9:32:04 PM" />
// -----------------------------------------------------------------------------

namespace Stex.Net.Repository
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Text;
    using DateTimeHelpers;
    using RESTApiAccess;
    using RESTApiAccess.Interface;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net.Http.Headers;
    using System.IO;
    using Newtonsoft.Json;
    using System.Net;
    using global::Stex.Net.Contracts;

    #endregion Usings

    public class RepositoryBase
    {
        #region Properties

        private IRESTRepository _rest;
        private string baseUrl = "https://api3.stex.com";
        private ApiCredentials _apiCreds;
        private DateTimeHelper _dtHelper;
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore
        };

        #endregion Properties

        public RepositoryBase()
        {
            LoadBase();
        }

        public RepositoryBase(ApiCredentials apiCredentials)
        {
            _apiCreds = apiCredentials;
            LoadBase();
        }

        private void LoadBase()
        {
            _rest = new RESTRepository();
            _dtHelper = new DateTimeHelper();
        }

        public void SetApiKey(ApiCredentials apiCredentials)
        {
            _apiCreds = apiCredentials;
        }

        /// <summary>
        /// Initiate a Get request
        /// </summary>
        /// <typeparam name="T">Object to return</typeparam>
        /// <param name="endpoint">Endpoint of request</param>
        /// <param name="parms">Parameters to pass</param>
        /// <param name="secure">Secure endpoint?</param>
        /// <returns>Object from response</returns>
        public async Task<T> Get<T>(string endpoint, SortedDictionary<string, object> parms, bool secure = false)
        {
            var queryString = DictionaryToQueryString(parms);

            if(!string.IsNullOrEmpty(queryString))
            {
                endpoint += $@"?{queryString}";
            }

            return await OnGet<T>(endpoint, secure);
        }

        /// <summary>
        /// Initiate a Get request
        /// </summary>
        /// <typeparam name="T">Object to return</typeparam>
        /// <param name="endpoint">Endpoint of request</param>
        /// <param name="secure">Secure endpoint?</param>
        /// <returns>Object from response</returns>
        public async Task<T> Get<T>(string endpoint, bool secure = false)
        {
            return await OnGet<T>(endpoint, secure);
        }

        /// <summary>
        /// Initiate a Get request
        /// </summary>
        /// <typeparam name="T">Object to return</typeparam>
        /// <param name="endpoint">Endpoint of request</param>
        /// <returns>Object from response</returns>
        private async Task<T> OnGet<T>(string endpoint, bool secure)
        {
            var url = baseUrl + endpoint;

            try
            {
                var response = secure 
                    ? await _rest.GetApiStream<ResponseBase<T>>(url, _apiCreds.ApiKey, _apiCreds.ApiSecret)
                    : await _rest.GetApiStream<ResponseBase<T>>(url);

                return response.Data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Initiate a Post request
        /// </summary>
        /// <typeparam name="T">Object to return</typeparam>
        /// <param name="endpoint">Endpoint of request</param>
        /// <param name="body">Request body data</param>
        /// <param name="secure">Secure endpoint?</param>
        /// <returns>Object from response</returns>
        public async Task<T> Post<T>(string endpoint, bool secure = true)
        {
            var url = baseUrl + endpoint;

            try
            {
                var response = secure
                    ? await _rest.PostApi<ResponseBase<T>>(url, _apiCreds.ApiKey, _apiCreds.ApiSecret)
                    : await _rest.PostApi<ResponseBase<T>>(url);

                return response.Data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Initiate a Post request
        /// </summary>
        /// <typeparam name="T">Object to return</typeparam>
        /// <param name="endpoint">Endpoint of request</param>
        /// <param name="body">Request body data</param>
        /// <param name="secure">Secure endpoint?</param>
        /// <returns>Object from response</returns>
        public async Task<T> Post<T>(string endpoint, SortedDictionary<string, object> body, bool secure = true)
        {
            var url = baseUrl + endpoint;

            try
            {
                var response = secure
                    ? await _rest.PostApi<ResponseBase<T>, SortedDictionary<string, object>>(url, body, _apiCreds.ApiKey, _apiCreds.ApiSecret)
                    : await _rest.PostApi<ResponseBase<T>, SortedDictionary<string, object>>(url, body);

                return response.Data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Initiate a Delete request
        /// </summary>
        /// <typeparam name="T">Object to return</typeparam>
        /// <param name="endpoint">Endpoint of request</param>
        /// <param name="secure">Secure endpoint?</param>
        /// <returns>Object from response</returns>
        public async Task<T> Delete<T>(string endpoint, bool secure = true)
        {
            var url = baseUrl + endpoint;

            try
            {
                var response = secure
                    ? await _rest.DeleteApi<ResponseBase<T>>(url, _apiCreds.ApiKey, _apiCreds.ApiSecret)
                    : await _rest.DeleteApi<ResponseBase<T>>(url);

                return response.Data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Convert a dictionary to a query string
        /// </summary>
        /// <param name="data">Dictionary to convert</param>
        /// <returns>String of dictionary data</returns>
        public string DictionaryToQueryString(SortedDictionary<string, object> data)
        {
            var queryString = string.Empty;

            foreach(var kvp in data)
            {
                if(!string.IsNullOrEmpty(queryString))
                {
                    queryString += $@"&";
                }

                queryString += $@"{kvp.Key}={kvp.Value.ToString()}";
            }

            return queryString;
        }
    }
}
