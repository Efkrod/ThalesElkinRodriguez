namespace ThalesElkinRodriguez.Models
{
    public class EmployeeResponse
    {
        public string Status { get; set; }
        public List<Employee> Data { get; set; }
        public string Message { get; set; }
    }
}
