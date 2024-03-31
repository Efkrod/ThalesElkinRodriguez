using ThalesElkinRodriguez.BLL;
using ThalesElkinRodriguez.Models;

namespace ThalesElkinRodriguez.DAL
{
    public class EmployeeService
    {
        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        /// <summary>
        /// Obtiene la lista de empleados desde una API REST
        /// </summary>
        /// <returns>Una lista de objetos de tipo Employee que representan a los empleados.</returns>
        public async Task<List<Employee>> GetEmployees()
        {
            var response = await _httpClient.GetAsync("https://dummy.restapiexample.com/api/v1/employees");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<EmployeeResponse>();
            if (result == null || result.Data == null)
            {
                return new List<Employee>();
            }
            return result.Data;
        }
        /// <summary>
        /// Obtiene la lista de empleados desde una API REST por identificador único
        /// </summary>
        /// <param name="id">El identificador único del empleado</param>
        /// <returns>El objeto de tipo Employee que representa al empleado encontrado</returns>
        public async Task<Employee> GetEmployeeById (int id)
        {
            var response = await _httpClient.GetAsync($"https://dummy.restapiexample.com/api/v1/employee/{id}");
            response.EnsureSuccessStatusCode();
            
            var result = await response.Content.ReadFromJsonAsync<EmployeeResponseId>();
            if (result == null || result.Data == null)
            {
                return null;
            }
            return result.Data;
        }
        /// <summary>
        /// Calcula los salarios anuales de todos los empleados.
        /// </summary>
        /// <returns>Una lista que representa los salarios anuales de los empleados.</returns>
        public async Task<List<int>> CalculateAnnualSalaries()
        {
            var employees = await GetEmployees();
            var annualSalaries = new List<int>();

            foreach (var employee in employees)
            {
                annualSalaries.Add(EmployeeAnualSalary.CalculateAnnualSalary(employee));
            }

            return annualSalaries;
        }
        /// <summary>
        /// Calcula el salario anual de un empleado específico por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del empleado.</param>
        /// <returns>El salario anual del empleado.</returns>
        public async Task<int> CalculateAnnualSalaryById(int id)
        {
            var employee = await GetEmployeeById(id);
            if (employee == null)
            {
                throw new InvalidOperationException("Employee not found");
            }

            return EmployeeAnualSalary.CalculateAnnualSalary(employee);
        }
    }
}
