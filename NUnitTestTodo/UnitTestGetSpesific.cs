using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;

namespace NUnitTestTodo
{
    class UnitTestGetSpesific
    {
        private HttpClient client;

        [SetUp]
        public void Setup()
        {
            client = new HttpClient();
            client.BaseAddress = new System.Uri("http://localhost:5000/api/");
        }

        [Test]
        public void GetIsSuccess()
        {
            var response = client.GetAsync("Todo/1002").Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void GetString()
        {
            var result = client.GetStringAsync("Todo/1002").Result;
            Console.WriteLine(result);
        }

    }
}
