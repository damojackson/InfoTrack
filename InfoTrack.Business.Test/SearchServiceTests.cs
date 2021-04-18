using InfoTrack.Business.Services;
using InfoTrack.Core.Entities;
using InfoTrack.Core.Factory;
using InfoTrack.Core.Interfaces;
using InfoTrack.Core.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoTrack.Business.Tests
{
    public class SearchServiceTests
    {

        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test calling the search service.
        /// </summary>
        [Test]
        public async Task TestSearchService()
        {
            // Arrange
            var searchSettings = new SearchSettings()
            {
                MaxResults = 1,
                SearchTag = "https://www.infotrack.com.au"
            };

            var request = new SearchEngineRequest()
            {
                SearchEngineURL = "https://infotrack-tests.infotrack.com.au/Google",
            };

            var content = "<div class=\"r\"><h3>https://www.infotrack.com.au</h3></div>";
            var firstPageUrl = "https://infotrack-tests.infotrack.com.au/Google/Page01.html";

            var list = new List<string>()
            {
                { content }
            };

            var mockDependency = new Mock<ISearchEngineService>();

            // set up mock for the name of the search engine.
            mockDependency.Setup(x => x.SearchEngineName)
                          .Returns("Test Search");

            // set up mock for the search
            mockDependency.Setup(x => x.Search(content))
                          .Returns(list);

            // set up mock for the page url
            mockDependency.Setup(x => x.GetSearchPageURL(request, 1))
                          .Returns("https://infotrack-tests.infotrack.com.au/Google/Page01.html");

            var mockFactory = new Mock<ISearchEngineFactory>();
            mockFactory.Setup(a => a.GetSearchService(request.SearchEngineURL))
                .Returns(mockDependency.Object);


            // mock client
            var mockClient = new Mock<ISearchClient>();
            mockClient.Setup(x => x.GetContent(firstPageUrl))
                         .Returns(Task.FromResult(content));

            var search = new SearchService(mockFactory.Object, mockClient.Object, searchSettings);

            // Act
            var result = await search.PerformSearch(request);

            //Assert
            Assert.IsNull(result.Error);
            Assert.AreEqual(result.SearchEngine, "Test Search");
            Assert.AreEqual(result.Results, "1");
        }
    }
}
