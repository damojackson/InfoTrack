namespace InfoTrack.Core.Entities
{
    /// <summary>
    /// The search engine results that get passed back from the API.
    /// </summary>
    public class SearchEngineResult
    {
        /// <summary>
        /// The name of the search engine that the search was run for
        /// </summary>
        public string SearchEngine { get; set; }

        /// <summary>
        /// The delimited string of results to display on screen.
        /// </summary>
        public string Results { get; set; }

        /// <summary>
        /// An error message if a user freindly error message needs to passed back to the user.
        /// </summary>
        public string Error { get; set; }
    }
}
