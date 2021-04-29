using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Browser = BasicSelenium.SharedResources.Enums.Browser;

namespace BasicSelenium.Tests
{
    public class BaseTest
    {
        /// <summary>
        /// Gets or sets the Web Driver
        /// </summary>
        protected IWebDriver WebDriver { get; set; }

        /// <summary>
        /// Gets the WebDriver      
        /// </summary>
        /// <returns></returns>
        private IWebDriver GetWebDriver(Browser browser = Browser.Chrome)
        {

            IWebDriver driver = null;
            switch (browser)
            {
                case Browser.Chrome:
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("--start-maximized");
                    driver = new ChromeDriver(options);
                    break;
                case Browser.Firefox:
                    driver = new FirefoxDriver();
                    break;
                case Browser.Edge:
                    driver = new EdgeDriver();
                    break;
            }
            return driver;
        }

        /// <summary>
        /// 
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            this.WebDriver = GetWebDriver();
        }

        /// <summary>
        /// 
        /// </summary>
        [TestCleanup]
        public void CleanUp()
        {
            this.WebDriver.Close();
        }
    }
}
