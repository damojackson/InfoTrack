using InfoTrack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrack.Core.Interfaces
{
    /// <summary>
    /// Interface for a search engine service, implemented for each search engine.
    /// </summary>
    public interface ISearchEngineService
    {
        /// <summary>
        /// The name of the search engine.
        /// </summary>
        string SearchEngineName { get; }

        /// <summary>
        /// Perform the search
        /// </summary>
        /// <param name="SearchTerm">The search term</param>
        /// <param name="content">The contnent to search.</param>
        /// <returns></returns>
        List<string> Search(string content, int page);

        /// <summary>
        /// Get the search page url.
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="page">The page number to get the url for.</param>
        /// <returns></returns>
        string GetSearchPageURL(SearchEngineRequest request, int page);
    }
}
