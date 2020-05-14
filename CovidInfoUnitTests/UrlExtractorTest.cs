using System;
using Xunit;
using CovidInfoWebService.Utils;

namespace CovidInfoUnitTests
{
    public class UrlExtractorTest
    {

        [Theory]
        [InlineData("https://localhost:44327", "https://localhost:44327/api/activo")]
        [InlineData("https://127.0.0.1:80", "https://127.0.0.1:80/index.html")]
        [InlineData("http://localhost", "http://localhost/api/casos/1")]
        public void ExtractBaseUrlOk(string baseUrlExpected, string url)
        {

            Assert.Equal(baseUrlExpected, UrlExtractor.ExtractBaseUrl(url));

        }

    }
}
