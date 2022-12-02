using FluentAssertions.Execution;
using FrontiersInTest.API.Models;
using FrontiersInTest.API.RequestBuilders;
using FrontiersInTest.Enums;
using FrontiersInTest.Utilities;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Globalization;
using Assert = NUnit.Framework.Assert;

namespace FrontiersInTest.API
{
    [TestFixture]
    public class ApiTest
    {
        private RestClient client;

        public ApiTest()
        {
        }

        [OneTimeSetUp]
        public void SetUp()
        {
            this.client = new RestClient("https://worldtimeapi.org");
        }

        [Test]
        public void CheckCurrentTime()
        {            
            var request = WorldTimeActions.GetWorldTime(CitiesEnum.Warsaw.ToString());
            var response = client.Execute(request);
            var deserializedResponse = JsonConvert.DeserializeObject<DateModel>(response.Content);

            string currentDate = DateTime.Now.ToString(Consts.DateFormat, CultureInfo.InvariantCulture);
            using (new AssertionScope())
            {
                Assert.AreEqual(true, response.IsSuccessful);
                Assert.AreEqual(
                    currentDate,
                    deserializedResponse.UtcDatetime.ToString(Consts.DateFormat, CultureInfo.InvariantCulture),
                    "Date not match - check used city in test!");
            }
        }
    }
}
