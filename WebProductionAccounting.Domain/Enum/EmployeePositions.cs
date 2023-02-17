
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebProductionAccounting.Domain.Enum
{
    public enum EmployeePositions
    {
        //"Начальник цеха"
        ShopSupervisor = 0,

        //"Заместитель начальника цеха"
        [Display(Name = "Заместитель начальника цеха")]
        DeputyShopSupervisor = 1,

        //"Начальник технологического бюро"
        ManufacturingEngineeringSupervisor = 2,

        //"Начальник планово-распределительного бюро"
        PlanningEstimatingManager = 3,

        //"Ведущий инженер-экономист"
        LeadEngineerEconomist = 4,

        //"Старший мастер"
        Superintendent = 5,

        //"Технолог"
        ProcessEngineer = 6,

        //"Диспетчер"
        Operator = 7,

        //"Экономист")
        Economist = 8,

        //"Рабочий"
        Workman = 9

    }
}
