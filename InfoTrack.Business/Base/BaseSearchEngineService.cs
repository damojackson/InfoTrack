using InfoTrack.Core.Entities;
using InfoTrack.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace InfoTrack.Business.Base
{
    /// <summary>
    /// This is the base search engine, it contains all of the common code for each of the search engines.
    /// The searchHTML method is overridable in case a different way of searching for each resul is required.
    /// </summary>
    public class BaseSearchEngineService : ISearchEngineService
    {
        #region Declarations

        private string _searchEngineName { get; set; }
        private string _pagingTemplate { get; set; }
        private string _searchRegex { get; set; }

        #endregion

        #region Properties

        /// <summary>
        /// The name of the search engine.
        /// </summary>
        public string SearchEngineName
        {
            get
            {
                return _searchEngineName;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="searchEngineName">The name of the search engine</param>
        /// <param name="pagingTemplate">The template used for requesting each page.</param>
        /// <param name="searchRegex">The regular expression used to find each of the results.</param>
        public BaseSearchEngineService(string searchEngineName, string pagingTemplate, string searchRegex)
        {
            _searchEngineName = searchEngineName;
            _pagingTemplate = pagingTemplate;
            _searchRegex = searchRegex;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request">The search request</param>
        /// <param name="page">The page</param>
        /// <returns></returns>
        public string GetSearchPageURL(SearchEngineRequest request, int page)
        {
            if (page <= 0)
            {
                throw new ArgumentException("page number must be greater than 0");
            }

            // deal with the leading 0 on the page number.
            var pageString = page.ToString();
            if (page < 10)
            {
                pageString = "0" + pageString;
            }

            return string.Format(this._pagingTemplate, request.SearchEngineURL, pageString);
        }

        /// <summary>
        /// Search the content for a specific page.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public List<string> Search(string content, int page)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentException("content cannot be empty.");
            }

            // return the result.
            return this.SearchHTML(content);
        }

        #endregion

        #region Virtual Methods

        /// <summary>
        /// Base method for the search html. Can be overriden if needed.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        protected virtual List<string> SearchHTML(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentNullException("content");
            }

            var results = new List<string>();
            var searchResults = Regex.Matches(content, _searchRegex, RegexOptions.IgnoreCase);

            // grab each value that matches a search result.
            results.AddRange(searchResults.Select(a => a.Value));

            // return the results.
            return results;
        }

        #endregion
    }
}
