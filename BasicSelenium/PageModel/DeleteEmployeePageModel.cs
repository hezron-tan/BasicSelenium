using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSelenium.PageModel
{
    public class DeleteEmployeePageModel : BasePageModel
    {
        /// <summary>
        /// Delete Employee Page Model Constructor
        /// </summary>
        /// <param name="driver"></param>
        public DeleteEmployeePageModel(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Gets the Page Header Element
        /// </summary>
        private IWebElement PageHeader
        {
            get { return this.WebDriver.FindElement(By.XPath("//h2[text()='Delete']")); }
        }

        /// <summary>
        /// Gets the Delete Button Element
        /// </summary>
        private IWebElement DeleteButton
        {
            get { return this.WebDriver.FindElement(By.XPath("//input[@value='Delete']")); }
        }

        /// <summary>
        /// Check if page is loaded
        /// </summary>
        /// <returns>True if page is displayed and false otherwise</returns>
        public override bool IsPageLoaded()
        {
            return PageHeader.Displayed;
        }

        /// <summary>
        /// Click Delete Button
        /// </summary>
        public void ClickDeleteButton()
        {
            DeleteButton.Click();
        }
    }
}
