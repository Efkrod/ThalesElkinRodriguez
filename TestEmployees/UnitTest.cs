using Xunit;
using ThalesElkinRodriguez.BLL;
using ThalesElkinRodriguez.Models;

namespace TestEmployees
{
    public class UnitTest
    {
        [Fact]
        public void TestAnnualSalary()
        {
            //Arrange
            var employee = new Employee
            {
                id = 1,
                employee_name = "John Due",
                employee_salary = 1200,
                employee_age = 60
            };

            //Act
            var annualSalary = EmployeeAnualSalary.CalculateAnnualSalary(employee);

            //Assert
            Assert.Equal(14400, annualSalary);

        }
    }
}