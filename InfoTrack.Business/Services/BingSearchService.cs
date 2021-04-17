using InfoTrack.Business.Base;
using InfoTrack.Core.Entities;
using InfoTrack.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace InfoTrack.Business.Services
{
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