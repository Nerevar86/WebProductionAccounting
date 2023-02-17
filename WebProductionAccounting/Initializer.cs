using WebProductionAccounting.DAL.Interfaces;
using WebProductionAccounting.Domain.Entities;
using WebProductionAccounting.DAL.Repositories;
using WebProductionAccounting.Services.Interfaces;
using WebProductionAccounting.Services.Implementations;

namespace WebProductionAccounting
{
    public static class Initializer
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Employee>, EmployeeRepository>();
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
        }
    }
}
