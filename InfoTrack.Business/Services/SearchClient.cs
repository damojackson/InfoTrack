using InfoTrack.Core.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace InfoTrack.Business.Services
{
    /// <summary>
    /// Search client to isolate the HttpClient calls.
    /// </summary>
    public class SearchClient : ISearchClient
    {
        #region Declarations

        private HttpClient _httpClient;

        #endregion

        #region Constructor

        public SearchClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Fetch the url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<string> GetContent(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException("url cannot be empty");
            }

            // Call the url to get the contnent.
            var content = await _httpClient.GetStringAsync(url);
            return content;
        }

        #endregion
    }
}
