using ThalesElkinRodriguez.Models;

namespace ThalesElkinRodriguez.BLL
{
    public static class EmployeeAnualSalary
    {
        public static int CalculateAnnualSalary(Employee employee) 
        {
            return employee.employee_salary * 12;
        }

    }
}
