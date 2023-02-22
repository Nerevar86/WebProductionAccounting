using Microsoft.AspNetCore.Mvc;
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

        public IActionResult GetWorks()
        {
            var response = _workService.GetWorks(1);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                if (response.Data == null)
                {
                    return View(new List<WorkViewModel>());
                }
                else
                {
                    return View(response.Data.ToList());
                }
            }
            return View("Error", $"{response.Description}");
        }
    }
}
