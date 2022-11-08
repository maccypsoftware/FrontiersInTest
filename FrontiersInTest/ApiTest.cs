using FrontiersInTest.Enums;
using FrontiersInTest.Models;
using FrontiersInTest.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.IO;
using System.Net;

namespace FrontiersInTest
{
    [TestClass]
    public class ApiTest
    {
        [TestMethod]
        public void CheckCurrentTime()
        {
            //Select your capital city (enum)
            var request = (HttpWebRequest)WebRequest.Create(Consts.ApiEndpointEuropeURI + CitiesEnum.Warsaw.ToString());
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            var deserializedResponse = JsonConvert.DeserializeObject<DateModel>(responseString);

            string currentDate = DateTime.Now.ToString(Consts.DateFormat, CultureInfo.InvariantCulture);

            Assert.AreEqual(
                currentDate, 
                deserializedResponse.UtcDatetime.ToString(Consts.DateFormat, CultureInfo.InvariantCulture),
                "Date not match - check used city in test!");
        }
    }
}
