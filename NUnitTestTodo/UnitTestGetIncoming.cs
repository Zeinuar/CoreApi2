using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;

namespace NUnitTestTodo
{
    public class UnitTestGetIncoming
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
            var response = client.GetAsync("GetIncoming?sDate=2020-9-3&eDate=2020-9-3").Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void GetString()
        {
            var result = client.GetStringAsync("GetIncoming?sDate=2020-9-3&eDate=2020-9-3").Result;
            Console.WriteLine(result);
        }
    }
}