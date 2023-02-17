using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebProductionAccounting.Domain.ViewModels;
using WebProductionAccounting.Services.Interfaces;

namespace WebProductionAccounting.Controllers
{
    public class EmployeeController : Controller
    { 
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var response = _employeeService.GetEmployees();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return View("Error", $"{response.Description}");
        }

        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _employeeService.DeleteEmployee(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetEmployees");
            }
            return View("Error", $"{response.Description}");
        }

        public IActionResult Compare() => PartialView();

        [HttpGet]
        public async Task<IActionResult> Save(int id)
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
        public async Task<IActionResult> Save(EmployeeViewModel viewModel)
        {
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                if (viewModel.Id == 0)
                {
                    await _employeeService.Create(viewModel);
                }
                else
                {
                    await _employeeService.Edit(viewModel.Id, viewModel);
                }
            }
            return RedirectToAction("GetEmployees");
        }


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

    }
}
