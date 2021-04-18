using System.Threading.Tasks;

namespace InfoTrack.Core.Services
{
    public interface ISearchClient
    {
        Task<string> GetContent(string url);
    }
}