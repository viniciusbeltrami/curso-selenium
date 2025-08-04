using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Alura.LeilaoOnline.Selenium.Helpers.TestHelper;

namespace Alura.LeilaoOnline.Selenium.Fixtures
{
    public class TestFixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }
        public TestFixture() 
        {
            Driver = WebDriverFactory.CreateWebDriver(BrowserType.Chrome);
        }

        public void Dispose() 
        { 
            Driver.Quit(); 
        }
    }
}
