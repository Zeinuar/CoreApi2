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
    class UnitTestDeleteTask
    {
        private HttpClient client;

        [SetUp]
        public void Setup()
        {
            client = new HttpClient();
            client.BaseAddress = new System.Uri("http://localhost:5000/api/");
        }

        [Test]
        public void DeleteTask()
        {
            var response = client.DeleteAsync("Todo/1009").Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Console.WriteLine(response);
        }

    }
}
