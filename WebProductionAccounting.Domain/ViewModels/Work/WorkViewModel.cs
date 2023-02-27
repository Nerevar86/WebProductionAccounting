using System.ComponentModel.DataAnnotations;

namespace WebProductionAccounting.Domain.ViewModels.Work
{
    public class WorkViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Введите наименование")]
        [MinLength(2, ErrorMessage = "Минимальная длина должна быть больше двух символов")]
        public string? Name { get; set; }

        [Display(Name = "Объем работ (ч.)")]
        public double Scope { get; set; }

        [Display(Name = "Дата и время выполнения")]
        [Required(ErrorMessage = "Укажите дату и время выполнения")]
        public DateTime DateTimeImplementation { get; set; } = DateTime.Now;
       
    }


}
