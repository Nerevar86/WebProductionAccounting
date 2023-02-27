using Microsoft.AspNetCore.Mvc;
using WebProductionAccounting.Domain.ViewModels.Employee;
using WebProductionAccounting.Domain.ViewModels.Work;
using WebProductionAccounting.Services.Interfaces;

namespace WebProductionAccounting.Controllers.Work
{
    public class WorkController : Controller
    {
        private readonly IWorkService _workService;

        public WorkController(IWorkService workService)
        {
            _workService = workService;
        }

        public IActionResult GetWorks(int id)
        {
            var response = _workService.GetWorks(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                if (response.Data == null)
                {
                    //return View(new List<WorkViewModel>());
                    return View();
                }
                else
                {
                    //return View(response.Data);
                    return View(new List<Object>()
                    {
                      response.Data,
                      id
                    });
                }
            }
            return View("Error", $"{response.Description}");
        }


        //CreateWork
        [HttpGet]
        public IActionResult CreateWork() => PartialView();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateWork(WorkViewModel viewModel, int id)
        {
            if (ModelState.IsValid)
            {
                await _workService.CreateWork(viewModel, id);
            }
            return RedirectToAction("GetWorks", new { id });
        }


        // DeleteWork
        public async Task<IActionResult> DeleteWork(int id)
        {
            var response = await _workService.GetWork(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return View("Error", $"{response.Description}");
        }

        [HttpPost, ActionName("DeleteWork")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteWorkPOST(int id)
        {
            var response = await _workService.DeleteWork(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetEmployees", "Employee");
            }
            return View("Error", $"{response.Description}");
        }


        // EditEmployee
        [HttpGet]
        public async Task<IActionResult> EditWork(int id)
        {
            if (id == 0)
                return PartialView();

            var response = await _workService.GetWork(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return PartialView(response.Data);
            }
            ModelState.AddModelError("", response.Description);
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> EditWork(WorkViewModel viewModel)
        {
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                await _workService.EditWork(viewModel);

            }
            return RedirectToAction("GetEmployees","Employee");
        }

    }
}
