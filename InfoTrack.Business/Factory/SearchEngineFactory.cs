using InfoTrack.Business.Services;
using InfoTrack.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrack.Business.Factory
{
    public class SearchEngineFactory
    {
        #region Declarations

        private readonly IServiceProvider serviceProvider;

        #endregion

        #region Constructor

        public SearchEngineFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        #endregion

        #region public Methods

        /// <summary>
        /// Gets the Search engine based on the url provided.
        /// </summary>
        /// <param name="userSelection"></param>
        /// <returns></returns>
        public ISearchEngineService GetSearcService(string url)
        {
            var urlToCheck = url.ToLower();
            if (urlToCheck.Contains("google"))
            {
                return (ISearchEngineService)serviceProvider.GetService(typeof(GoogleSearchService));
            }
            else if (urlToCheck.Contains("bing"))
            {
                return (ISearchEngineService)serviceProvider.GetService(typeof(BingSearchService));
            }

            throw new ArgumentException("Search engine not supported");
        }

        #endregion
    }
}
