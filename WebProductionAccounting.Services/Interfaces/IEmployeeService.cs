using WebProductionAccounting.Domain.Entities;
using WebProductionAccounting.Domain.Interfaces;
using WebProductionAccounting.Domain.Response;
using WebProductionAccounting.Domain.ViewModels.Employee;

namespace WebProductionAccounting.Services.Interfaces
{
    public interface IEmployeeService
    {

        IBaseResponse<List<EmployeeViewModel>> GetEmployees();

        Task<IBaseResponse<EmployeeViewModel>> GetEmployee(int id);

        Task<BaseResponse<Dictionary<int, string>>> GetEmployee(string term);

        Task<IBaseResponse<Employee>> CreateEmployee(EmployeeViewModel model);

        Task<IBaseResponse<bool>> DeleteEmployee(int id);

        Task<IBaseResponse<Employee>> EditEmployee(EmployeeViewModel model);

        BaseResponse<Dictionary<int, string>> GetPosition();

    }
}
