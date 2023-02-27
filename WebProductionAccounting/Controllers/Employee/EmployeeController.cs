using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebProductionAccounting.Domain.Entities;
using WebProductionAccounting.Domain.ViewModels.Employee;
using WebProductionAccounting.Services.Interfaces;

namespace WebProductionAccounting.Controllers.Employee
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        // GetEmployees (List)
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var response = _employeeService.GetEmployees();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                if (response.Data == null)
                {
                    return View(new List<EmployeeViewModel>());
                }
                else
                {
                    return View(response.Data.ToList());
                }
            }
            return View("Error", $"{response.Description}");
        }


        // DeleteEmployee
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var response = await _employeeService.GetEmployee(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return View("Error", $"{response.Description}");
        }

        [HttpPost, ActionName("DeleteEmployee")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEmployeePOST(int id)
        {
            var response = await _employeeService.DeleteEmployee(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetEmployees");
            }
            return View("Error", $"{response.Description}");
        }


        // EditEmployee
        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            if (id == 0)
                return PartialView();

            var response = await _employeeService.GetEmployee(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return PartialView(response.Data);
            }
            ModelState.AddModelError("", response.Description);
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(EmployeeViewModel viewModel)
        {
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                if (viewModel.Id == 0)
                {
                    await _employeeService.CreateEmployee(viewModel);
                }
                else
                {
                    await _employeeService.EditEmployee(viewModel);
                }
            }
            return RedirectToAction("GetEmployees");
        }


        // GetEmployee
        [HttpGet]
        public async Task<ActionResult> GetEmployee(int id, bool isJson)
        {
            var response = await _employeeService.GetEmployee(id);
            if (isJson)
            {
                return Json(response.Data);
            }
            return PartialView("GetEmployee", response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> GetEmployee(string term)
        {
            var response = await _employeeService.GetEmployee(term);
            return Json(response.Data);
        }


        //CreateEmployee
        [HttpGet]
        public IActionResult CreateEmployee() => PartialView();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEmployee(EmployeeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.CreateEmployee(viewModel);
            }
            return RedirectToAction("GetEmployees");
        }


        //GetPosition
        [HttpPost]
        public JsonResult GetPosition()
        {
            var positions = _employeeService.GetPosition();
            return Json(positions.Data);
        }

    }
}
