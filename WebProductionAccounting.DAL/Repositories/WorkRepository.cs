using WebProductionAccounting.DAL.Interfaces;
using WebProductionAccounting.Domain.Entities;

namespace WebProductionAccounting.DAL.Repositories
{
    public class WorkRepository : IBaseRepository<Work>
    {
        private readonly AppDbContext _db;
        public WorkRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task Create(Work entity)
        {
            await _db.Works.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Work entity)
        {
            _db.Works.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<Work> GetAll()
        {
            return _db.Works;
        }

        public async Task<Work> Update(Work entity)
        {
            _db.Works.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
