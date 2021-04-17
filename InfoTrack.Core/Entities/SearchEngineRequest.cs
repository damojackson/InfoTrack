using System.ComponentModel.DataAnnotations;

namespace InfoTrack.Core.Entities
{
    /// <summary>
    /// The request from the client with data annotations for model validation.
    /// </summary>
    public class SearchEngineRequest
    {
        [Required]
        [Url]
        public string SearchEngineURL { get; set; }

        [Required]
        public string SearchTerm { get; set; }
    }
}
