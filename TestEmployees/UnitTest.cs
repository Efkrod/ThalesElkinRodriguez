using Xunit;
using ThalesElkinRodriguez.BLL;

namespace TestEmployees
{
    public class UnitTest
    {
        [Fact]
        public void TestAnnualSalary()
        {
            //Arrange
            var employee = new EmployeeAnualSalary();

            //Act
            var annualSalary = employee.CalculateAnnualSalary(1200);

            //Assert
            Assert.Equal(14400, annualSalary);

        }
    }
}