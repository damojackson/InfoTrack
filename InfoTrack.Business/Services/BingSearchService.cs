using InfoTrack.Business.Base;
using InfoTrack.Core.Interfaces;

namespace InfoTrack.Business.Services
{
    /// <summary>
    /// This search engine is for the bing site, it only needs a few paramters passed into the base for it to to get results.
    /// This will allow another request to be able to 
    /// </summary>
    public class BingSearchService : BaseSearchEngineService, ISearchEngineService
    {
        #region Declarations

        const string SEARCH_ENGINE_NAME = "Bing";
        const string PAGING_TEMPLATE = "{0}/Page{1}.html";
        const string REGEX_SEARCH = "<li class=\"b_algo\">(.*?)</li>";

        #endregion

        #region Constructor

        public BingSearchService() : base(SEARCH_ENGINE_NAME, PAGING_TEMPLATE, REGEX_SEARCH)
        {
        }

        #endregion

    }
}