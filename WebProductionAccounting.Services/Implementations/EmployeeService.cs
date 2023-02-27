using Microsoft.EntityFrameworkCore;
using WebProductionAccounting.DAL.Interfaces;
using WebProductionAccounting.Domain.Entities;
using WebProductionAccounting.Domain.Enum;
using WebProductionAccounting.Domain.Extensions;
using WebProductionAccounting.Domain.Interfaces;
using WebProductionAccounting.Domain.Response;
using WebProductionAccounting.Domain.ViewModels.Employee;
using WebProductionAccounting.Services.Interfaces;

namespace WebProductionAccounting.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IBaseRepository<Employee> _employeeRepository;


        //__________Constructor EmployeeService__________
        public EmployeeService(IBaseRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        //__________Create employee__________
        public async Task<IBaseResponse<Employee>> CreateEmployee(EmployeeViewModel model)
        {
            try
            {
                var employee = new Employee()
                {
                    Lastname = model.Lastname,
                    Firstname = model.Firstname,
                    Middlename = model.Middlename,
                    PersonnelNumber = model.PersonnelNumber,
                    Position = (EmployeePositions)Convert.ToInt32(model.Position),
                    //DateOfEmployment = DateTime.ParseExact(model.DateOfEmployment, "yyyyMMdd HH:mm", null
                    DateOfEmployment = DateTime.Parse(model.DateOfEmployment)


                };
                await _employeeRepository.Create(employee);

                return new BaseResponse<Employee>()
                {
                    StatusCode = StatusCode.OK,
                    Data = employee
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Employee>()
                {
                    Description = $"[CreateEmployee] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }


        //__________Delete employee__________
        public async Task<IBaseResponse<bool>> DeleteEmployee(int id)
        {
            try
            {
                var employee = await _employeeRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (employee == null)
                {
                    return new BaseResponse<bool>()
                    {
                        Description = "Сотрудник не найден",
                        StatusCode = StatusCode.EmployeeNotFound,
                        Data = false
                    };
                }

                await _employeeRepository.Delete(employee);

                return new BaseResponse<bool>()
                {
                    Data = true,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteEmployee] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }


        //__________Edit employee__________
        public async Task<IBaseResponse<Employee>> EditEmployee(EmployeeViewModel model)
        {
            try
            {
                var employee = await _employeeRepository.GetAll().FirstOrDefaultAsync(x => x.Id == model.Id);
                if (employee == null)
                {
                    return new BaseResponse<Employee>()
                    {
                        Description = "Сотрудник не найден",
                        StatusCode = StatusCode.EmployeeNotFound
                    };
                }

                employee.Lastname = model.Lastname;
                employee.Firstname = model.Firstname;
                employee.Middlename = model.Middlename;
                employee.PersonnelNumber = model.PersonnelNumber;
                employee.Position = (EmployeePositions)Convert.ToInt32(model.Position);
                //employee.DateOfEmployment = DateTime.ParseExact(model.DateOfEmployment, "yyyyMMdd HH:mm", null);
                employee.DateOfEmployment = DateTime.Parse(model.DateOfEmployment);

                await _employeeRepository.Update(employee);


                return new BaseResponse<Employee>()
                {
                    Data = employee,
                    StatusCode = StatusCode.OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Employee>()
                {
                    Description = $"[EditEmployee] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }


        //__________Get employee by id__________
        public async Task<IBaseResponse<EmployeeViewModel>> GetEmployee(int id)
        {
            try
            {
                var employee = await _employeeRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (employee == null)
                {
                    return new BaseResponse<EmployeeViewModel>()
                    {
                        Description = "Сотрудник не найден",
                        StatusCode = StatusCode.EmployeeNotFound
                    };
                }

                var data = new EmployeeViewModel()
                {
                    Lastname = employee.Lastname,
                    Firstname = employee.Firstname,
                    Middlename = employee.Middlename,
                    PersonnelNumber = employee.PersonnelNumber,
                    Position = employee.Position.GetDisplayName(),
                    //DateOfEmployment = employee.DateOfEmployment.ToString("D")
                    DateOfEmployment = employee.DateOfEmployment.ToLongDateString()
                };

                return new BaseResponse<EmployeeViewModel>()
                {
                    StatusCode = StatusCode.OK,
                    Data = data
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<EmployeeViewModel>()
                {
                    Description = $"[GetEmployee] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }


        //__________Get employee by fullname__________
        public async Task<BaseResponse<Dictionary<int, string>>> GetEmployee(string term)
        {
            var baseResponse = new BaseResponse<Dictionary<int, string>>();
            try
            {
                var employees = await _employeeRepository.GetAll()
                    .Select(x => new EmployeeViewModel()
                    {
                        Id = x.Id,
                        Lastname = x.Lastname,
                        Firstname = x.Firstname,
                        Middlename = x.Middlename,
                        PersonnelNumber = x.PersonnelNumber,
                        Position = x.Position.GetDisplayName(),
                        DateOfEmployment = x.DateOfEmployment.ToLongDateString()
                    })
                    .Where(x => EF.Functions.Like(x.Lastname + " " + x.Firstname + " " + x.Middlename, $"%{term}%"))
                    .ToDictionaryAsync(x => x.Id, t => t.Lastname + " " + t.Firstname + " " + t.Middlename);

                baseResponse.Data = employees;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Dictionary<int, string>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }


        //__________Get list of employees __________
        public IBaseResponse<List<EmployeeViewModel>> GetEmployees()
        {
            try
            {
                var employees = _employeeRepository.GetAll()
                   .Select(x => new EmployeeViewModel()
                   {
                       Id = x.Id,
                       Lastname = x.Lastname,
                       Firstname = x.Firstname,
                       Middlename = x.Middlename,
                       PersonnelNumber = x.PersonnelNumber,
                       Position = x.Position.GetDisplayName(),
                       DateOfEmployment = x.DateOfEmployment.ToLongDateString()
                   }).ToList();
                if (!employees.Any())
                {
                    return new BaseResponse<List<EmployeeViewModel>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = StatusCode.OK
                    };
                }

                return new BaseResponse<List<EmployeeViewModel>>()
                {
                    Data = employees,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<EmployeeViewModel>>()
                {
                    Description = $"[GetEmployees] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        //__________Get positions of employees __________
        public BaseResponse<Dictionary<int, string>> GetPosition()
        {
            {
                try
                {
                    var positions = ((EmployeePositions[])Enum.GetValues(typeof(EmployeePositions)))
                        .ToDictionary(k => (int)k, t => t.GetDisplayName());

                    return new BaseResponse<Dictionary<int, string>>()
                    {
                        Data = positions,
                        StatusCode = StatusCode.OK
                    };
                }
                catch (Exception ex)
                {
                    return new BaseResponse<Dictionary<int, string>>()
                    {
                        Description = ex.Message,
                        StatusCode = StatusCode.InternalServerError
                    };
                }
            }
        }
    }
}
    

    
