using NUnit.Framework;
using System.Net;
using System.Net.Http;

namespace Tests
{
    public class Tests
    {
        private HttpClient client;
        private HttpResponseMessage response;

        [SetUp]
        public void Setup()
        {
            client = new HttpClient();
            
            response = client.GetAsync("api/Todo").Result;
        }

        [Test]
        public void GetIsSuccess()
        {
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}