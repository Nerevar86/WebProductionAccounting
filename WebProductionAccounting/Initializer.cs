using WebProductionAccounting.DAL.Interfaces;
using WebProductionAccounting.DAL.Repositories;
using WebProductionAccounting.Services.Interfaces;
using WebProductionAccounting.Services.Implementations;
using WebProductionAccounting.Domain.Entities;

namespace WebProductionAccounting
{
    public static class Initializer
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Employee>, EmployeeRepository>();

            services.AddScoped<IBaseRepository<Work>, WorkRepository>();
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<IWorkService, WorkService>();
        }
    }
}
