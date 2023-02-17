using WebProductionAccounting.Domain.Enum;

namespace WebProductionAccounting.Domain.Interfaces
{
    public interface IBaseResponse<T>
    {
        string Description { get; }
        StatusCode StatusCode { get; }
        T Data { get; }
    }
}
