using WebProductionAccounting.Domain.Entities;
using WebProductionAccounting.Domain.Interfaces;
using WebProductionAccounting.Domain.Response;
using WebProductionAccounting.Domain.ViewModels;

namespace WebProductionAccounting.Services.Interfaces
{
    public interface IEmployeeService
    {

        IBaseResponse<List<Employee>> GetEmployees();

        Task<IBaseResponse<EmployeeViewModel>> GetEmployee(int id);

        Task<BaseResponse<Dictionary<int, string>>> GetEmployee(string term);

        Task<IBaseResponse<Employee>> Create(EmployeeViewModel model);

        Task<IBaseResponse<bool>> DeleteEmployee(int id);

        Task<IBaseResponse<Employee>> Edit(int id, EmployeeViewModel model);

    }
}
