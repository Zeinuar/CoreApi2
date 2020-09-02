using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Todo0912.Models;

namespace NUnitTestTodo
{
    class UnitTestSetDone
    {
        private HttpClient client;

        [SetUp]
        public void Setup()
        {
            client = new HttpClient();
            client.BaseAddress = new System.Uri("http://localhost:5000/api/");
        }

        [Test]
        public void SetDone()
        {
            var data = new StringContent("", Encoding.UTF8, "application/json");
            var response = client.PutAsync("SetDone/1004",data).Result;
            Console.WriteLine(response);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            
        }

    }
}
