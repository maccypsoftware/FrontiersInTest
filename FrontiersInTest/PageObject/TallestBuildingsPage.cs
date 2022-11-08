using FrontiersInTest.Builder;
using FrontiersInTest.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace FrontiersInTest.PageObject
{
    public class TallestBuildingsPage : BuildingDataBuilder
    {
        private readonly IWebDriver driver;
        private IWebElement SearchList => driver.FindElement(By.CssSelector("select[name='list']"));

        private IWebElement BuildingList => driver.FindElement(By.XPath("(//table[@id='buildingsTable'])[1]"));

        public TallestBuildingsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SelectListOfBuidings(string listName)
        {
            var selectElement = new SelectElement(SearchList);
            selectElement.SelectByText(listName);
        }

        public List<BuildingModel> GetTableOfBuildings()
        {
            var buildingsList = new List<BuildingModel>();
            var lstTrElem = new List<IWebElement>(BuildingList.FindElements(By.TagName("tr")));
            string strRowData;

            // Traverse each row
            foreach (var elemTr in lstTrElem)
            {
                // Fetch the columns from a particuler row
                var lstTdElem = new List<IWebElement>(elemTr.FindElements(By.TagName("td")));
                if (lstTdElem.Count > 0)
                {
                    strRowData = "";
                    // Traverse each column
                    foreach (var elemTd in lstTdElem)
                    {
                        strRowData = strRowData + elemTd.Text + "\n";
                    }

                    string[] buildingDetails = strRowData.Split("\n");
                    buildingsList.Add(BuildBuildingFromData(buildingDetails));
                }
            }
            return buildingsList;
        }
    }
}
