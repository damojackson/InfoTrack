using InfoTrack.Core.Entities;
using InfoTrack.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InfoTrack.Web.Controllers
{
    /// <summary>
    /// The API controller 
    /// </summary>
    [Route("api/SearchEngine")]
    [ApiController]
    public class SearchEngineController : ControllerBase
    {
        #region Declarations

        private readonly ISearchService _searchService;

        #endregion

        #region Constrcutor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchEngineFactory">The fatcory used to </param>
        public SearchEngineController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        #endregion

        #region API Methods

        /// <summary>
        /// Perform the search and return the result back to the client.
        /// </summary>
        /// <param name="request">The request from the client</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Search")]
        public async Task<SearchEngineResult> Search(SearchEngineRequest request)
        {
            // check for trailing '/' and remove it if it exists.
            if (request.SearchEngineURL.EndsWith("/"))
            {
                request.SearchEngineURL = request.SearchEngineURL[0..^1];
            }

            // Get the correct search based on input. 
            var result = await _searchService.PerformSearch(request);
            return result;
        }

        #endregion
    }
}
