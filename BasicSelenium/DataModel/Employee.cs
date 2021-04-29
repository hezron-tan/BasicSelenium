using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSelenium.DataModel
{
    /// <summary>
    /// Employee Data Model
    /// </summary>
    public class Employee
    {
        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Employee emp = (Employee)obj;
                return this.FirstName == emp.FirstName && this.LastName == emp.LastName && this.Address == emp.Address &&
                        this.City == emp.City && this.State == emp.State && this.Department == emp.Department;
            }
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Department { get; set; }
    }
}
