using Microsoft.IdentityModel.Tokens;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

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

                Assert.Equal(8, els.Count);

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


        [Fact]
        public void FireFoxTest()
        {
            IWebDriver driver = new FirefoxDriver();
            try
            {
                driver.Navigate().GoToUrl("http://localhost:421/adduser");


                var title = driver.Title;
                Assert.Equal("FabricAPP", title);

                var btnDiv = driver.FindElement(By.ClassName("add-user-btn"));
                btnDiv.FindElement(By.TagName("button")).Submit();
                var els = driver.FindElements(By.ClassName("validation-message"));
                Assert.Equal(8, els.Count);

            }
            catch (StaleElementReferenceException ex)
            {
                var btnDiv = driver.FindElement(By.ClassName("add-user-btn"));
                btnDiv.FindElement(By.TagName("button")).Submit();
                var els = driver.FindElements(By.ClassName("validation-message"));
                Assert.Equal(8, els.Count);
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
