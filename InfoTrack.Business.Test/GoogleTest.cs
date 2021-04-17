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
    public class GoogleTests
    {

        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test we get a correct page URL
        /// </summary>
        [Test]
        public void TestGoogleServiceName()
        {
            // Arrange
            var googleService = new GoogleSearchService();

            // Act
            var name = googleService.SearchEngineName;

            // Assert
            Assert.AreEqual("Google", name);
        }

        /// <summary>
        /// Test getting the page url.
        /// </summary>
        [Test]
        public void TestGoogleSearchHTML()
        {
            // Arrange
            var googleService = new GoogleSearchService();
            var content = "<div class=\"r\"><h3>https://www.infotrack.com.au</h3></div>";

            // Act
            var result = googleService.Search(content);

            // Assert
            Assert.AreEqual(1, result.Count);
        }


        /// <summary>
        /// Test getting the page url.
        /// </summary>
        [Test]
        public void TestGoogleSearchPageURL()
        {
            // Arrange
            var googleService = new GoogleSearchService();
            var request = new SearchEngineRequest()
            {
                SearchEngineURL = "https://infotrack-tests.infotrack.com.au/Google",
            };

            // Act
            var url = googleService.GetSearchPageURL(request, 1);

            Assert.AreEqual("https://infotrack-tests.infotrack.com.au/Google/Page01.html", url);
        }
    }
}