using OpenQA.Selenium;

namespace FrontiersInTest.Cookie
{
    public class CookieActions
    {
        private readonly IWebDriver driver;
        private IWebElement CookieAcceptBtn => driver.FindElement(By.XPath("//button[contains(text(),'Allow cookies')]"));
        public CookieActions(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void AcceptCookies()
        {
            CookieAcceptBtn.Click();
        }
    }
}
