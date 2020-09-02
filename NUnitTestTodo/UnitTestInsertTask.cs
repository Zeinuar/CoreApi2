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
    class UnitTestInsertTask
    {
        private HttpClient client;

        [SetUp]
        public void Setup()
        {
            client = new HttpClient();
            client.BaseAddress = new System.Uri("http://localhost:5000/api/");
        }

        [Test]
        public void InsertTask()
        {
            var item = new Todo();
            item.Title = "Title F";
            item.Description = "Description F";
            item.Complete = 36;
            item.CreatedOn = DateTime.Now;
            item.ExpiredDate = DateTime.Now.AddDays(6);

            var json = JsonConvert.SerializeObject(item);
            var data = new StringContent(json, Encoding.UTF8, "application/json");


            var response = client.PostAsync("Todo",data).Result;
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Console.WriteLine(response);

        }

    }
}
