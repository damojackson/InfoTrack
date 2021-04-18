using InfoTrack.Core.Interfaces;

namespace InfoTrack.Core.Factory
{
    public interface ISearchEngineFactory
    {
        ISearchEngineService GetSearchService(string url);
    }
}