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
    class UnitTestSetPercent
    {
        private HttpClient client;

        [SetUp]
        public void Setup()
        {
            client = new HttpClient();
            client.BaseAddress = new System.Uri("http://localhost:5000/api/");
        }

        [Test]
        public void SetPercent()
        {
            var data = new StringContent("", Encoding.UTF8, "application/json");


            var response = client.PutAsync("SetTodo/1003?Percent=80",data).Result;
            Console.WriteLine(response);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            
        }

    }
}
