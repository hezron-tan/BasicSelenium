using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using BasicSelenium.PageModel;
using BasicSelenium.DataModel;
using BasicSelenium.Helper;

namespace BasicSelenium.Tests
{
    /// <summary>
    /// Summary description for Employee
    /// </summary>
    [TestClass]
    public class EmployeeTest : BaseTest
    {
        /// <summary>
        /// Add and Delete Employee Test Case
        /// </summary>
        [TestMethod]
        public void AddDeleteEmployee()
        {
            // 1. Open Page
            EmployeePageModel employeePage = new EmployeePageModel(this.WebDriver);
            employeePage.OpenPage();

            // 2. Verify page is loaded
            Assert.IsTrue(employeePage.IsPageLoaded(), "Employee Page is not loaded");

            // 3. Create an employee
            CreateEmployeePageModel createEmployeePage = employeePage.ClickCreateNewLink();
            Employee employee = new Employee()
            {
                FirstName = DataEntryHelper.GenerateFirstName(),
                LastName = DataEntryHelper.GenerateLastName(),
                Address = DataEntryHelper.GenerateAddress(),
                State = createEmployeePage.GetRandomValueFromStateDropdown(),
                City = DataEntryHelper.GenerateCity(),
                Department = createEmployeePage.GetRandomValueFromDepartmentDropdown()
            };

            createEmployeePage.PopulateEachField(employee);
            createEmployeePage.ClickCreateButton();

            // 4. Verify if employee is displayed on the page
            Assert.IsTrue(employeePage.IsEmployeeAdded(employee), $"Page does not contain new employee: {employee.FirstName} {employee.LastName}");

            // Alternative step: Involves Data Modeling
            //List<Employee> employees = employeePage.GetEmployees();
            //Assert.IsTrue(employees.Contains(employee), $"Page does not contain new employee: {employee.FirstName} {employee.LastName}");

            // 5. Click Delete button on employee
            DeleteEmployeePageModel deletePage = employeePage.ClickDeleteLink(employee);

            // 6. Verify that Delete Employee page is loaded
            Assert.IsTrue(deletePage.IsPageLoaded(), "Delete page is not loaded");

            // 7. Click Delete button
            deletePage.ClickDeleteButton();

            // 8. Verify if employee is removed on the page
            Assert.IsFalse(employeePage.IsEmployeeAdded(employee), $"Employee: {employee.FirstName} {employee.LastName} is not removed");

            // Alternative step: Involves Data Modeling
            // employees = employeePage.GetEmployees();
            // Assert.IsFalse(employees.Contains(employee), $"Employee: {employee.FirstName} {employee.LastName} is not removed");
        }
    }
}
