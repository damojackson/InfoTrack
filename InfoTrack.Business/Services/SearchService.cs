using InfoTrack.Business.Factory;
using InfoTrack.Core.Entities;
using InfoTrack.Core.Factory;
using InfoTrack.Core.Interfaces;
using InfoTrack.Core.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace InfoTrack.Business.Services
{
    public class SearchService : ISearchService
    {
        #region Declarations

        readonly ISearchEngineFactory _searchEngineFactory;
        readonly ISearchClient _searchClient;
        readonly SearchSettings _searchSettings;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="searchEngineService">Takes a single search engine service for searching the htnl</param>
        /// <param name="client">The HttpClient</param>
        public SearchService(ISearchEngineFactory searchEngineFactory, ISearchClient searchClient, SearchSettings settings)
        {
            _searchEngineFactory = searchEngineFactory;
            _searchSettings = settings;
            _searchClient = searchClient;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Performs the search 
        /// </summary>
        /// <param name="request">The search engine request</param>
        /// <returns>Search engine results.</returns>
        public async Task<SearchEngineResult> PerformSearch(SearchEngineRequest request)
        {
            if (request == null)
            {
                throw new NullReferenceException();
            }

            // get the correct service to make the call.
            var searchEngineService = _searchEngineFactory.GetSearchService(request.SearchEngineURL);

            // find each of the search rows so we can check each one.
            var searchRows = await FindSearchResults(request, searchEngineService);
            var results = FindInfoTrackUrl(searchRows);

            // if we dont find anything return 0;
            if (results.Count == 0)
            {
                results.Add(0);
            }

            // return the result.
            return new SearchEngineResult()
            {
                Results = string.Join(",", results),
                SearchEngine = searchEngineService.SearchEngineName
            };
        }

        #endregion

        #region Private Methods



        /// <summary>
        /// Search a page for content.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="searchEngineService">The service.</param>
        /// <param name="page">The page number.</param>
        /// <returns></returns>
        private async Task<List<string>> SearchPage(SearchEngineRequest request, ISearchEngineService searchEngineService, int page)
        {
            // get the url of the page we are fetching.
            var pageURL = searchEngineService.GetSearchPageURL(request, page);

            // request the contnent from the url.
            var content = await _searchClient.GetContent(pageURL);

            // Perform the search.
            return searchEngineService.Search(content);
        }

        /// <summary>
        /// Finds search results.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="searchEngineService"></param>
        /// <returns></returns>
        private async Task<List<string>> FindSearchResults(SearchEngineRequest request, ISearchEngineService searchEngineService)
        {
            // loop around searching each page until we get to the maximum pages.
            var results = new List<string>();
            var page = 1;
            while (results.Count < this._searchSettings.MaxResults)
            {
                var pageResults = await SearchPage(request, searchEngineService, page);
                if (pageResults.Count > 0)
                {
                    results.AddRange(pageResults);
                    page++;
                }
                else
                {
                    // no results so stop.
                    break;
                }
            }

            return results;
        }

        /// <summary>
        /// Locates the Info track url in the search results.. 
        /// </summary>
        /// <param name="searchRows">the rows to search.</param>
        /// <returns></returns>
        private List<int> FindInfoTrackUrl(List<string> searchRows)
        {
            var results = new List<int>();
            // check for the infotrack url.
            for (int i = 0; i < searchRows.Count; i++)
            {
                if (searchRows[i].Contains(_searchSettings.SearchTag))
                {
                    results.Add(i + 1);
                }
            }

            return results;
        }

        #endregion
    }
}
