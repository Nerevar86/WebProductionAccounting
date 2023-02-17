using WebProductionAccounting.DAL.Interfaces;
using WebProductionAccounting.Domain.Entities;

namespace WebProductionAccounting.DAL.Repositories
{
    public class EmployeeRepository : IBaseRepository<Employee>
    {
        private readonly AppDbContext _db;
        public EmployeeRepository(AppDbContext db) { 
            _db = db;
        }
        public async Task Create(Employee entity)
        {
            await _db.Employees.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<Employee> GetAll()
        {
            return _db.Employees;
        }

        public async Task Delete(Employee entity)
        {
            _db.Employees.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<Employee> Update(Employee entity)
        {
            _db.Employees.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}