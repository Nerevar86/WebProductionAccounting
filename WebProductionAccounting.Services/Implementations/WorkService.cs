using Microsoft.EntityFrameworkCore;
using WebProductionAccounting.DAL.Interfaces;
using WebProductionAccounting.Domain.Entities;
using WebProductionAccounting.Domain.Enum;
using WebProductionAccounting.Domain.Interfaces;
using WebProductionAccounting.Domain.Response;
using WebProductionAccounting.Domain.ViewModels.Work;
using WebProductionAccounting.Services.Interfaces;

namespace WebProductionAccounting.Services.Implementations
{
    public class WorkService : IWorkService
    {
        private readonly IBaseRepository<Work> _workRepository;


        //__________Constructor WorkService__________
        public WorkService(IBaseRepository<Work> workRepository)
        {
            _workRepository = workRepository;
        }


        //__________Create work__________
        public async Task<IBaseResponse<Work>> CreateWork(WorkViewModel model)
        {
            try
            {
                var work = new Work()
                {

                    Name = model.Name,
                    Scope = model.Scope,
                    DateTimeImplementation = model.DateTimeImplementation
                };
                await _workRepository.Create(work);

                return new BaseResponse<Work>()
                {
                    StatusCode = StatusCode.OK,
                    Data = work
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Work>()
                {
                    Description = $"[CreateWork] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }


        //__________Delete work__________
        public async Task<IBaseResponse<bool>> DeleteWork(int id)
        {
            try
            {
                var work = await _workRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (work == null)
                {
                    return new BaseResponse<bool>()
                    {
                        Description = "Работа не найдена",
                        StatusCode = StatusCode.WorkNotFound,
                        Data = false
                    };
                }

                await _workRepository.Delete(work);

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
                    Description = $"[DeleteWork] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }


        //__________Edit work__________
        public async Task<IBaseResponse<Work>> EditWork(WorkViewModel model)
        {
            try
            {
                var work = await _workRepository.GetAll().FirstOrDefaultAsync(x => x.Id == model.Id);
                if (work == null)
                {
                    return new BaseResponse<Work>()
                    {
                        Description = "Работа не найдена",
                        StatusCode = StatusCode.WorkNotFound
                    };
                }

                work.Name = model.Name;
                work.Scope = model.Scope;
                work.DateTimeImplementation = model.DateTimeImplementation;

                await _workRepository.Update(work);


                return new BaseResponse<Work>()
                {
                    Data = work,
                    StatusCode = StatusCode.OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Work>()
                {
                    Description = $"[EditWork] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }


        //__________Get work by id__________
        public async Task<IBaseResponse<WorkViewModel>> GetWork(int id)
        {
            try
            {
                var work = await _workRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (work == null)
                {
                    return new BaseResponse<WorkViewModel>()
                    {
                        Description = "Работа не найдена",
                        StatusCode = StatusCode.WorkNotFound
                    };
                }

                var data = new WorkViewModel()
                {
                    Name = work.Name,
                    Scope = work.Scope,
                    DateTimeImplementation = work.DateTimeImplementation
                };

                return new BaseResponse<WorkViewModel>()
                {
                    StatusCode = StatusCode.OK,
                    Data = data
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<WorkViewModel>()
                {
                    Description = $"[GetWork] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }


        //__________Get list of works __________
        public IBaseResponse<List<WorkViewModel>> GetWorks(int employeeId)
        {
            try
            {
                //var works = _workRepository.GetAll()
                //   .Select(x => new WorkViewModel()
                //   {
                //       Id = x.Id,
                //       Name = x.Name,
                //       Scope = x.Scope,
                //       DateTimeImplementation = x.DateTimeImplementation,
                //   }).ToList();
                var works = _workRepository.GetAll()
                    .Where(w => w.Employees
                    .Any(e => e.Id == 1))
                    .Select(w => new WorkViewModel()
                  {
                      Id = w.Id,
                      Name = w.Name,
                      Scope = w.Scope,
                      DateTimeImplementation = w.DateTimeImplementation,
                  }).ToList();
                if (!works.Any())
                {
                    return new BaseResponse<List<WorkViewModel>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = StatusCode.OK
                    };
                }

                return new BaseResponse<List<WorkViewModel>>()
                {
                    Data = works,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<WorkViewModel>>()
                {
                    Description = $"[GetWorks] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}


