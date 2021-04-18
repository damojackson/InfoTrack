using InfoTrack.Business.Services;
using InfoTrack.Core.Factory;
using InfoTrack.Core.Interfaces;
using System;

namespace InfoTrack.Business.Factory
{
    /// <summary>
    /// This factory will allow us to easily add search engines as needed.
    /// It will return the correct class based on what is passed in from the user.
    /// </summary>
    public class SearchEngineFactory : ISearchEngineFactory
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
        public ISearchEngineService GetSearchService(string url)
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
