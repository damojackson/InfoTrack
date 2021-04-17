using InfoTrack.Business.Factory;
using InfoTrack.Business.Services;
using InfoTrack.Core.Entities;
using InfoTrack.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Net.Http;

/// <summary>
/// Unit tests will go here.
/// </summary>
namespace InfoTrack.Business.Test
{

    /// <summary>
    /// Basic unit tests.
    /// </summary>
    public class BingTests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test we get a correct page URL
        /// </summary>
        [Test]
        public void TestBingServiceName()
        {
            // Arrange
            var bingService  = new BingSearchService();

            // Act
            var name = bingService.SearchEngineName;

            // Assert
            Assert.AreEqual("Bing", name);
        }

        /// <summary>
        /// Test getting the page url.
        /// </summary>
        [Test]
        public void TestBingSearchHTML()
        { 
            // Arrange
            var bingService = new BingSearchService();
            var content = "<li class=\"b_algo\"><h3>https://www.infotrack.com.au</h3></li>";

            // Act
            var result = bingService.Search(content);

            // Assert
            Assert.AreEqual(1, result.Count);
        }

        /// <summary>
        /// Test getting the page url.
        /// </summary>
        [Test]
        public void TestBingPageUrl()
        {
            // Arrange
            var bingService = new BingSearchService();
            var request = new SearchEngineRequest()
            {
                SearchEngineURL = "https://infotrack-tests.infotrack.com.au/Bing",
            };

            // Act
            var url = bingService.GetSearchPageURL(request, 1);

            // Asset.
            Assert.AreEqual("https://infotrack-tests.infotrack.com.au/Bing/Page01.html", url);
        }
    }
}