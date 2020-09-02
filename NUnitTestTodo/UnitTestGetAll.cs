using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;

namespace NUnitTestTodo
{
    public class UnitTestGetAll
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
            var response = client.GetAsync("Todo").Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void GetString()
        {
            var result = client.GetStringAsync("Todo").Result;
            Console.WriteLine(result);
        }
    }
}