namespace InfoTrack.Core.Entities
{
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
