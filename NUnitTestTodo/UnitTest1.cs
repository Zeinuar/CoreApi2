using NUnit.Framework;
using System.Net;
using System.Net.Http;

namespace Tests
{
    public class Tests
    {
        private HttpResponseMessage response;

        [SetUp]
        public void Setup()
        {

            using (var handler = new HttpClientHandler())
            using (var client = new HttpClient(handler)) {
                client.BaseAddress = new System.Uri("http://localhost:5000/api/");
                response = client.GetAsync("Todo").Result;
            }
            
        }

        [Test]
        public void GetIsSuccess()
        {
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}