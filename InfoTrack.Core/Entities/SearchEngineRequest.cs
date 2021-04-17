using System.ComponentModel.DataAnnotations;

namespace InfoTrack.Core.Entities
{
    public class SearchEngineRequest
    {
        [Required]
        [Url]
        public string SearchEngineURL { get; set; }

        [Required]
        public string SearchTerm { get; set; }
    }
}
