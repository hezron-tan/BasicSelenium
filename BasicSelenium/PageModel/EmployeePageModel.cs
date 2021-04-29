using BasicSelenium.DataModel;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSelenium.PageModel
{
    public class EmployeePageModel : BasePageModel
    {
        /// <summary>
        /// Base URL of the site
        /// </summary>
        private string Url = @"http://magenicautomation.azurewebsites.net/Employees";

        /// <summary>
        /// Relative City Selector
        /// </summary>
        private By relativeCitySelector = By.XPath(".//td[1]"); //By.CssSelector("td:nth-child(1)");

        /// <summary>
        /// Relative Department Selector
        /// </summary>
        private By relativeDepartmentSelector = By.XPath(".//td[2]"); //By.CssSelector("td:nth-child(2)");

        /// <summary>
        /// Relative State Selector
        /// </summary>
        private By relativeStateSelector = By.XPath(".//td[3]"); //By.CssSelector("td:nth-child(3)");

        /// <summary>
        /// Relative First Name Selector
        /// </summary>
        private By relativeFirstNameSelector = By.XPath(".//td[4]"); //By.CssSelector("td:nth-child(4)");

        /// <summary>
        /// Relative Last Name Selector
        /// </summary>
        private By relativeLastNameSelector = By.XPath(".//td[5]"); //By.CssSelector("td:nth-child(5)");

        /// <summary>
        /// Relative Address Selector
        /// </summary>
        private By relativeAddressSelector = By.XPath(".//td[6]"); //By.CssSelector("td:nth-child(6)");

        /// <summary>
        /// Relative Delete Button Selector
        /// </summary>
        private By relativeDeleteButton = By.XPath(".//a[contains(@href, 'Delete')]"); //By.CssSelector("a[href*='Delete']");

        /// <summary>
        /// Employee Page Constructor
        /// </summary>
        /// <param name="driver">Web Driver</param>
        public EmployeePageModel(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Gets the Page Header Element
        /// </summary>
        private IWebElement PageHeader
        {
            get { return this.WebDriver.FindElement(By.CssSelector("div.container.body-content > h2")); }
        }

        /// <summary>
        /// Gets the Create New Link Element
        /// </summary>
        private IWebElement CreateNewLink
        {
            get { return this.WebDriver.FindElement(By.CssSelector("a[href*='Create']")); }
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
        /// Open browser and navigate to Main Page
        /// </summary>
        public void OpenPage()
        {
            this.WebDriver.Navigate().GoToUrl(Url);
        }

        /// <summary>
        /// Click Create New Link
        /// </summary>
        /// <returns>Create Employee Page Model</returns>
        public CreateEmployeePageModel ClickCreateNewLink()
        {
            CreateNewLink.Click();
            return new CreateEmployeePageModel(this.WebDriver);
        }

        /// <summary>
        /// Gets all employees
        /// </summary>
        /// <returns>List of Employee Object</returns>
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

            List<IWebElement> rows = GetRows();

            foreach (var row in rows)
            {
                Employee emp = new Employee()
                {
                    City = row.FindElement(relativeCitySelector).Text.Trim(),
                    Department = row.FindElement(relativeDepartmentSelector).Text.Trim(),
                    State = row.FindElement(relativeStateSelector).Text.Trim(),
                    FirstName = row.FindElement(relativeFirstNameSelector).Text.Trim(),
                    LastName = row.FindElement(relativeLastNameSelector).Text.Trim(),
                    Address = row.FindElement(relativeAddressSelector).Text.Trim()
                };
                employees.Add(emp);
            }

            return employees;
        }

        /// <summary>
        /// Check if employee is added
        /// </summary>
        /// <param name="employee">Employee Details</param>
        /// <returns>True if employee is on the page and false otherwise</returns>
        public bool IsEmployeeAdded(Employee employee)
        {
            List<IWebElement> rows = GetRows();
            return rows.Where(row => row.FindElement(relativeCitySelector).Text.Trim() == employee.City &&
                                                    row.FindElement(relativeDepartmentSelector).Text.Trim() == employee.Department &&
                                                    row.FindElement(relativeStateSelector).Text.Trim() == employee.State &&
                                                    row.FindElement(relativeFirstNameSelector).Text.Trim() == employee.FirstName &&
                                                    row.FindElement(relativeLastNameSelector).Text.Trim() == employee.LastName &&
                                                    row.FindElement(relativeAddressSelector).Text.Trim() == employee.Address).Any();
        }

        /// <summary>
        /// Click Delete Button
        /// </summary>
        /// <param name="employee">Employee Object</param>
        /// <returns>Delete Employee Page Model</returns>
        public DeleteEmployeePageModel ClickDeleteLink(Employee employee)
        {
            List<IWebElement> rows = GetRows();
            IWebElement element = rows.Where(row => row.FindElement(relativeCitySelector).Text.Trim() == employee.City &&
                                                    row.FindElement(relativeDepartmentSelector).Text.Trim() == employee.Department &&
                                                    row.FindElement(relativeStateSelector).Text.Trim() == employee.State &&
                                                    row.FindElement(relativeFirstNameSelector).Text.Trim() == employee.FirstName &&
                                                    row.FindElement(relativeLastNameSelector).Text.Trim() == employee.LastName &&
                                                    row.FindElement(relativeAddressSelector).Text.Trim() == employee.Address).FirstOrDefault();
            element.FindElement(relativeDeleteButton).Click();
            return new DeleteEmployeePageModel(this.WebDriver);
        }

        /// <summary>
        /// Gets all the rows from the page
        /// </summary>
        /// <returns>List of Web Element Employee Rows</returns>
        private List<IWebElement> GetRows()
        {
            By xpath = By.XPath("//tbody/tr/following-sibling::tr");
            //By css = By.CssSelector("tbody > tr ~ tr");
            return this.WebDriver.FindElements(xpath).ToList();
        }
    }
}
