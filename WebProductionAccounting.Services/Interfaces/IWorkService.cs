using WebProductionAccounting.Domain.Entities;
using WebProductionAccounting.Domain.Interfaces;
using WebProductionAccounting.Domain.ViewModels.Work;

namespace WebProductionAccounting.Services.Interfaces
{
    public interface IWorkService
    {

        IBaseResponse<List<WorkViewModel>> GetWorks(int id);

        Task<IBaseResponse<WorkViewModel>> GetWork(int id);

        Task<IBaseResponse<Work>> CreateWork(WorkViewModel model,int id);

        Task<IBaseResponse<bool>> DeleteWork(int id);

        Task<IBaseResponse<Work>> EditWork(WorkViewModel model);

    }
}
