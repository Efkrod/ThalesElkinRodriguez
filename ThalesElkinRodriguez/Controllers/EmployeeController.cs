using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ThalesElkinRodriguez.DAL;
using ThalesElkinRodriguez.Models;

namespace ThalesElkinRodriguez.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;
        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int? id)
        {
            try 
            {
                if (id.HasValue)
                {
                    var employee = await _employeeService.GetEmployeeById(id.Value);
                    var annualSalaryById = await _employeeService.CalculateAnnualSalaryById(id ?? 0);
                    if (employee == null)
                    {
                        return NotFound();
                    }
                    ViewBag.AnnualSalaryById = annualSalaryById;
                    return View("Details", employee);
                }
                else
                {
                    var employees = await _employeeService.GetEmployees();
                    var annualSalaries = await _employeeService.CalculateAnnualSalaries();
                    ViewBag.AnnualSalaries = annualSalaries;
                    return View(employees);
                }
            }catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                //var errorViewModel = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
                ViewData["ErrorMessage"] = ex.Message;
                return View("~/Views/Shared/Error.cshtml");
            }
            
        }
    }
}
