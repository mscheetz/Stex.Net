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

        private IRESTRepository _restRepo;
        private string baseUrl = "https://app.stex.com/api2";
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
            _restRepo = new RESTRepository();
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
        public async Task<T> GetRequest<T>(string endpoint, SortedDictionary<string, object> parms, bool secure = false)
        {
            return await OnGetRequest<T>(endpoint);
        }

        /// <summary>
        /// Initiate a Get request
        /// </summary>
        /// <typeparam name="T">Object to return</typeparam>
        /// <param name="endpoint">Endpoint of request</param>
        /// <param name="secure">Secure endpoint?</param>
        /// <returns>Object from response</returns>
        public async Task<T> GetRequest<T>(string endpoint, bool secure = false)
        {
            return await OnGetRequest<T>(endpoint);
        }

        /// <summary>
        /// Initiate a Get request
        /// </summary>
        /// <typeparam name="T">Object to return</typeparam>
        /// <param name="endpoint">Endpoint of request</param>
        /// <returns>Object from response</returns>
        private async Task<T> OnGetRequest<T>(string endpoint)
        {
            var url = baseUrl + endpoint;

            try
            {
                var response = await Get<T>(url);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Initiate a Get request
        /// </summary>
        /// <typeparam name="T">Object to return</typeparam>
        /// <param name="endpoint">Endpoint of request</param>
        /// <returns>Object from response</returns>
        public async Task<T> GetRequest<T>(string endpoint)
        {
            var url = baseUrl + endpoint;

            try
            {
                var response = await Get<T>(url);

                return response;
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
        /// <returns>Object from response</returns>
        public async Task<T> PostRequest<T>(string endpoint)
        {
            var url = baseUrl + endpoint;

            try
            {
                var response = await Post<T>(url);

                return response;
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
        /// <returns>Object from response</returns>
        public async Task<T> PostRequest<T>(string endpoint, SortedDictionary<string, object> body, bool secure)
        {
            var url = baseUrl + endpoint;

            try
            {
                var response = await Post<T, SortedDictionary<string, object>>(url, body, secure);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get call to api stream 
        /// For large json responses
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="url">Url to access</param>
        /// <returns>Type requested</returns>
        private async Task<T> Get<T>(string url, bool secure = false)
        {
            using (var client = new HttpClient())
            {
                if (secure)
                {
                    var secureBytes = ASCIIEncoding.ASCII.GetBytes($"{_apiCreds.ApiKey}:{_apiCreds.ApiSecret}");
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Basic", Convert.ToBase64String(secureBytes));
                }

                var responseMessage = String.Empty;
                try
                {
                    var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
                    var sb = new StringBuilder();

                    using (var stream = await response.Content.ReadAsStreamAsync())
                    {
                        using (var sr = new StreamReader(stream, Encoding.UTF8))
                        {
                            sb.Append(sr.ReadToEnd());
                        }

                        responseMessage = sb.ToString();
                    }

                    if (!StatusCodeSuccess(response.StatusCode))
                    {
                        throw new Exception(responseMessage);
                    }

                    try
                    {
                        return JsonConvert.DeserializeObject<T>(responseMessage, settings);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        /// Post call to api with data
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <typeparam name="U">Type to post</typeparam>
        /// <param name="url">Url to access</param>
        /// <param name="data">Data object being sent</param>
        /// <returns>Type requested</returns>
        public async Task<T> Post<T, U>(string url, U data, bool secure = false)
        {
            using (var client = new HttpClient())
            {
                if (secure)
                {
                    var secureBytes = ASCIIEncoding.ASCII.GetBytes($"{_apiCreds.ApiKey}:{_apiCreds.ApiSecret}");
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Basic", Convert.ToBase64String(secureBytes));
                }

                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                try
                {
                    var response = await client.PostAsync(url, content);

                    string responseMessage = await response.Content.ReadAsStringAsync();

                    if (!StatusCodeSuccess(response.StatusCode))
                    {
                        throw new Exception(responseMessage);
                    }

                    try
                    {
                        return JsonConvert.DeserializeObject<T>(responseMessage, settings);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        /// Post call to api without data
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="url">Url to access</param>
        /// <returns>Type requested</returns>
        public async Task<T> Post<T>(string url, bool secure = false)
        {
            using (var client = new HttpClient())
            {
                if (secure)
                {
                    var secureBytes = ASCIIEncoding.ASCII.GetBytes($"{_apiCreds.ApiKey}:{_apiCreds.ApiSecret}");
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Basic", Convert.ToBase64String(secureBytes));
                }

                try
                {
                    var response = await client.PostAsync(url, null);

                    string responseMessage = await response.Content.ReadAsStringAsync();

                    if (!StatusCodeSuccess(response.StatusCode))
                    {
                        throw new Exception(responseMessage);
                    }

                    try
                    {
                        return JsonConvert.DeserializeObject<T>(responseMessage, settings);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        /// Check if response was successfully returned
        /// </summary>
        /// <param name="code">Status code of response</param>
        /// <returns>Boolean value of validity of response</returns>
        private bool StatusCodeSuccess(HttpStatusCode code)
        {
            if (code == HttpStatusCode.OK
                || code == HttpStatusCode.Accepted
                || code == HttpStatusCode.Created
                || code == HttpStatusCode.NoContent)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
