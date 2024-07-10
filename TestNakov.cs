using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FirstTest
{
    public class FirstTest
    {
        private IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }
        [TearDown]
        public void Teardown()
        {
            driver.Close();
            driver.Dispose();
        }

        [Test]
        public void TestNakov()
        {
            driver.Navigate().GoToUrl("https://nakov.com");
            Assert.That(driver.Title.Contains("Svetlin Nakov – Official Web Site"));
            Console.WriteLine(driver.Title);

            var searchLink = driver.FindElement(By.ClassName("smoothScroll"));
            Assert.That(searchLink.Text, Does.Contain("SEARCH"));
            Console.WriteLine(searchLink.Text);

            searchLink.Click();

            var message = driver.FindElement(By.Id("s"));
            var placeHolderText = message.GetAttribute("placeholder");
            Assert.That(placeHolderText, Is.EqualTo("Search this site"));
            Console.WriteLine(placeHolderText);
        }
    }
}