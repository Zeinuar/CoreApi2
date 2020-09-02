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
    class UnitTestUpdateTask
    {
        private HttpClient client;

        [SetUp]
        public void Setup()
        {
            client = new HttpClient();
            client.BaseAddress = new System.Uri("http://localhost:5000/api/");
        }

        [Test]
        public void UpdateTask()
        {
            var item = new Todo();
            item.Id = 1002;
            item.Title = "Title A update";
            item.Description = "Description A update";
            item.Complete = 12;
            item.CreatedOn = DateTime.Now;
            item.ExpiredDate = DateTime.Now.AddDays(2);

            var json = JsonConvert.SerializeObject(item);
            var data = new StringContent(json, Encoding.UTF8, "application/json");


            var response = client.PutAsync("Todo/1002",data).Result;
            Console.WriteLine(response);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            
        }

    }
}
