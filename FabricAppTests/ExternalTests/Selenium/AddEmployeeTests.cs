using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace FabricAppTests.ExternalTests.Selenium
{
    public class AddEmployeeTests : TestContext
    {
        [Fact]
        public void ChromeTest()
        {
            IWebDriver driver = new ChromeDriver();
            try
            {


                driver.Navigate().GoToUrl("http://localhost:421/adduser");


                var title = driver.Title;
                Assert.Equal("FabricAPP", title);


                var btnDiv = driver.FindElement(By.ClassName("add-user-btn"));
                btnDiv.FindElement(By.TagName("button")).Click();

                var els = driver.FindElements(By.ClassName("validation-message"));

                Assert.Equal(els.Count, 8);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
