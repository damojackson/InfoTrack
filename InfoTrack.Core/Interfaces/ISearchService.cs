using InfoTrack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrack.Core.Interfaces
{
    /// <summary>
    /// Interface for the search service. Used to fetch each of the pages of the search, which is the same no matter what the search engine.
    /// </summary>
    public interface ISearchService
    {
        Task<SearchEngineResult> PerformSearch(SearchEngineRequest request);
    }
}
