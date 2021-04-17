using InfoTrack.Business.Base;
using InfoTrack.Core.Entities;
using InfoTrack.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace InfoTrack.Business.Services
{
    public class GoogleSearchService : BaseSearchEngineService, ISearchEngineService
    {
        #region Declarations

        const string SEARCH_ENGINE_NAME = "Google";
        const string PAGING_TEMPLATE = "{0}/Page{1}.html";
        const string REGEX_SEARCH = "<div class=\"r\">(.*?)</div>";

        #endregion

        #region Constructor

        public GoogleSearchService() : base(SEARCH_ENGINE_NAME, PAGING_TEMPLATE, REGEX_SEARCH)
        {
        }

        #endregion
    
    }
}
