using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSelenium.Helper
{
    public static class DataEntryHelper
    {
        /// <summary>
        /// Generate Number
        /// </summary>
        /// <param name="maxNumber">Max Number from 1 to N</param>
        /// <returns>Random Number</returns>
        public static int GenerateNumber(int maxNumber = 100)
        {
            return new Random().Next(1, maxNumber);
        }

        /// <summary>
        /// Generate First Name
        /// </summary>
        /// <returns>First Name</returns>
        public static string GenerateFirstName()
        {
            return Faker.Name.First();
        }

        /// <summary>
        /// Generate Last Name
        /// </summary>
        /// <returns>Last Name</returns>
        public static string GenerateLastName()
        {
            return Faker.Name.Last();
        }

        /// <summary>
        /// Generate Address
        /// </summary>
        /// <returns>Address</returns>
        public static string GenerateAddress()
        {
            return Faker.Address.StreetAddress();
        }

        /// <summary>
        /// Generate City
        /// </summary>
        /// <returns>City</returns>
        public static string GenerateCity()
        {
            return Faker.Address.City();
        }
    }
}
