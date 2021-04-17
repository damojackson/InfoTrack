using InfoTrack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrack.Core.Interfaces
{
    public interface ISearchService
    {
        Task<SearchEngineResult> PerformSearch(SearchEngineRequest request);
    }
}
