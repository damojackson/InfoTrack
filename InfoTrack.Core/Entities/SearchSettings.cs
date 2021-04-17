namespace InfoTrack.Core.Entities
{
    /// <summary>
    /// The search settings that can be set from the app settings and injected in.
    /// </summary>
    public class SearchSettings
    {
        /// <summary>
        /// The maximum number of results to search for.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The search string to find in each of the result pages.
        /// </summary>
        public string SearchTag { get; set; }
    }
}
