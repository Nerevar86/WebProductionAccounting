
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebProductionAccounting.Domain.Enum
{
    public enum EmployeePositions
    {
        //"Начальник цеха"
        [Display(Name = "Начальник цеха")]
        ShopSupervisor = 0,

        //"Заместитель начальника цеха"
        [Display(Name = "Заместитель начальника цеха")]
        DeputyShopSupervisor = 1,

        //"Начальник технологического бюро"
        [Display(Name = "Начальник технологического бюро")]
        ManufacturingEngineeringSupervisor = 2,

        //"Начальник планово-распределительного бюро"
        [Display(Name = "Начальник планово-распределительного бюро")]
        PlanningEstimatingManager = 3,

        //"Ведущий инженер-экономист"
        [Display(Name = "Ведущий инженер-экономист")]
        LeadEngineerEconomist = 4,

        //"Старший мастер"
        [Display(Name = "Старший мастер")]
        Superintendent = 5,

        //"Технолог"
        [Display(Name = "Технолог")]
        ProcessEngineer = 6,

        //"Диспетчер"
        [Display(Name = "Диспетчер")]
        Operator = 7,

        //"Экономист")
        [Display(Name = "Экономист")]
        Economist = 8,

        //"Рабочий"
        [Display(Name = "Рабочий")]
        Workman = 9,

        //"Программист"
        [Display(Name = "Программист")]
        Programmer = 10

    }
}
