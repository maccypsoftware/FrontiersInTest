using FluentAssertions.Execution;
using FrontiersInTest.Cookie;
using FrontiersInTest.PageObject;
using FrontiersInTest.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;

namespace FrontiersInTest.UI
{
    [TestClass]
    public class FrontiersInTests
    {
        private ChromeDriver _driver;

        [TestInitialize]
        public void ChromeDriverInitialize()
        {
            _driver = new ChromeDriver(chromeDriverDirectory: @"drivers");
            _driver.Manage().Window.Maximize();
            _driver.Url = Consts.SkyScraperCenterURL;

            var cookieDriver = new CookieActions(_driver);
            cookieDriver.AcceptCookies();
        }

        [TestMethod]
        public void Select100TallestCompletedBuildingsInTheWorld()
        {
            var buildingsListDriver = new TallestBuildingsPage(_driver);
            buildingsListDriver.SelectListOfBuidings(Consts.ListWith100TallestAndCompletedBuildingsName);
            var listOfHighestBuildings = buildingsListDriver.GetTableOfBuildings();

            using (new AssertionScope())
            {
                Assert.AreEqual(100, listOfHighestBuildings.Count);
                Assert.AreEqual(123, listOfHighestBuildings
                    .Where(x => x.Name == "Lotte World Tower")
                    .Select(x => x.Floors)
                    .FirstOrDefault());
            }

            Console.WriteLine(listOfHighestBuildings.MaxBy(x => x.Floors).Name);
        }

        [TestCleanup]
        public void EdgeDriverCleanup()
        {
            try
            {                
                _driver.Close();
                _driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if we are unable to close the browser
            }
        }
    }
}
