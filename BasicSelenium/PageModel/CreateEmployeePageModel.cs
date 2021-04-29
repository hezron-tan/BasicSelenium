using BasicSelenium.DataModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSelenium.PageModel
{
    public class CreateEmployeePageModel : BasePageModel
    {
        /// <summary>
        /// Create Employee Page Model Constructor
        /// </summary>
        /// <param name="driver">Web Driver</param>
        public CreateEmployeePageModel(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Gets the Page Header Element
        /// </summary>
        private IWebElement PageHeader
        {
            get { return this.WebDriver.FindElement(By.XPath("//h2[text()='Create']")); }
        }

        /// <summary>
        /// Gets the First Name Element
        /// </summary>
        private IWebElement FirstNameField
        {
            get { return this.WebDriver.FindElement(By.XPath("//*[@id='EmpFirstName']")); }
        }

        /// <summary>
        /// Gets the Last Name Element
        /// </summary>
        private IWebElement LasttNameField
        {
            get { return this.WebDriver.FindElement(By.XPath("//*[@id='EmpLastName']")); }
        }

        /// <summary>
        /// Gets the Address Element
        /// </summary>
        private IWebElement AddressField
        {
            get { return this.WebDriver.FindElement(By.XPath("//*[@id='EmpAddress']")); }
        }

        /// <summary>
        /// Gets the City Element
        /// </summary>
        private IWebElement CityField
        {
            get { return this.WebDriver.FindElement(By.XPath("//*[@id='CityObj_CityName']")); }
        }

        /// <summary>
        /// Gets the State Dropdown Element
        /// </summary>
        private SelectElement StateDropdown
        {
            get
            {
                IWebElement element = this.WebDriver.FindElement(By.XPath("//*[@id='StateID']"));
                return new SelectElement(element);
            }
        }

        /// <summary>
        /// Gets the Department Dropdown Element
        /// </summary>
        private SelectElement DepartmentDropdown
        {
            get
            {
                IWebElement element = this.WebDriver.FindElement(By.XPath("//*[@id='DepartmentID']"));
                return new SelectElement(element);
            }
        }

        /// <summary>
        /// Gets the Create Button Element
        /// </summary>
        private IWebElement CreateButton
        {
            get { return this.WebDriver.FindElement(By.XPath("//input[@type='submit']")); }
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
        /// Populate each field on the page
        /// </summary>
        /// <param name="employee">Employee Object</param>
        public void PopulateEachField(Employee employee)
        {
            ClearFields();

            FirstNameField.SendKeys(employee.FirstName);
            LasttNameField.SendKeys(employee.LastName);
            AddressField.SendKeys(employee.Address);
            StateDropdown.SelectByText(employee.State);
            CityField.SendKeys(employee.City);
            DepartmentDropdown.SelectByText(employee.Department);
        }

        /// <summary>
        /// Click the Create Button
        /// </summary>
        public void ClickCreateButton()
        {
            CreateButton.Click();
        }

        /// <summary>
        /// Get Random Value from State Dropdown
        /// </summary>
        /// <returns>Random State</returns>
        public string GetRandomValueFromStateDropdown()
        {
            return GetRandomValueFromDropdown(StateDropdown);
        }

        /// <summary>
        /// Get Random Value from Department Dropdown
        /// </summary>
        /// <returns>Random Department</returns>
        public string GetRandomValueFromDepartmentDropdown()
        {
            return GetRandomValueFromDropdown(DepartmentDropdown);
        }

        /// <summary>
        /// Clear Fields
        /// </summary>
        private void ClearFields()
        {
            List<IWebElement> fields = this.WebDriver.FindElements(By.CssSelector("input[type='text']")).ToList();
            foreach (IWebElement field in fields)
            {
                field.Clear();
            }
        }

        /// <summary>
        /// Gets randowm item from dropdown based on specified parameter
        /// </summary>
        /// <param name="element">Select Element Dropdown</param>
        /// <returns>Random item from dropdown</returns>
        private string GetRandomValueFromDropdown(SelectElement element)
        {
            List<IWebElement> options = element.Options.ToList();
            return options[new Random().Next(options.Count)].Text.Trim();
        }
    }
}
