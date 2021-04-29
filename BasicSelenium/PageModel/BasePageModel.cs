using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSelenium.PageModel
{
    public abstract class BasePageModel
    {
        /// <summary>
        /// Gets or sets the Web Driver
        /// </summary>
        protected IWebDriver WebDriver { get; set; }

        /// <summary>
        /// Constructor for Base Page Model
        /// </summary>
        /// <param name="driver"></param>
        public BasePageModel(IWebDriver driver)
        {
            this.WebDriver = driver;
        }

        /// <summary>
        /// Check if user is navigated to page
        /// </summary>
        /// <returns>True if user is navigated to page and false otherwise</returns>
        public abstract bool IsPageLoaded();
    }
}
