using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace TestProject1
{
    public class loadPageOpen
    {
        //Check that the Page loads and the Title is correct
        [Fact]
        public void LoadTestWebpage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://www.saucedemo.com");

                 string pageTitle = driver.Title;

                Assert.Equal("Swag Labs", pageTitle);
                Assert.Equal("https://www.saucedemo.com/", driver.Url);
                

            }
        }
        //Log into Webpage, then use the Logout button on the next page to exit.
        [Fact]
        public void LogoutAfterLogin()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://www.saucedemo.com");

                //Login name
                driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
                //Password name
                driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
                //click the Login Button
                driver.FindElement(By.Id("login-button")).Click();
                SlowDownTime.Pause();
                //Find the button for logout and other menu items.
                driver.FindElement(By.Id("react-burger-menu-btn")).Click();
                SlowDownTime.Pause();
                //Click the Logout button
                driver.FindElement(By.Id("logout_sidebar_link")).Click();

                //The home page to be open again
                Assert.Equal("https://www.saucedemo.com/", driver.Url);


            }

        }

        //Check all the Login names that have been supplied, and that they go to the next page.
        [Theory]
        [InlineData("standard_user", "secret_sauce", "https://www.saucedemo.com/inventory.html")]
        [InlineData("problem_user", "secret_sauce", "https://www.saucedemo.com/inventory.html")]
        [InlineData("performance_glitch_user", "secret_sauce", "https://www.saucedemo.com/inventory.html")]
        [InlineData("locked_out_user", "secret_sauce", "https://www.saucedemo.com/")]
        public void TestAllUserNameandPasswords(string userName, string passWord, string expected)
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://www.saucedemo.com");

                //Login name
                driver.FindElement(By.Id("user-name")).SendKeys(userName);
                //Password name
                driver.FindElement(By.Id("password")).SendKeys(passWord);
                //click the Login Button
                driver.FindElement(By.Id("login-button")).Click();

                Assert.Equal(expected, driver.Url);
            }

        }


    }
}