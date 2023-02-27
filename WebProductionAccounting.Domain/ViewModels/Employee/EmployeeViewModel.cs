using System.ComponentModel.DataAnnotations;
using WebProductionAccounting.Domain.Entities;

namespace WebProductionAccounting.Domain.ViewModels.Employee
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Введите фамилию")]
        [MinLength(2, ErrorMessage = "Минимальная длина должна быть больше двух символов")]
        public string? Lastname { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Введите имя")]
        [MinLength(2, ErrorMessage = "Минимальная длина должна быть больше двух символов")]
        public string? Firstname { get; set; }

        [Display(Name = "Отчество")]
        [Required(ErrorMessage = "Введите отчество")]
        [MinLength(2, ErrorMessage = "Минимальная длина должна быть больше двух символов")]
        public string? Middlename { get; set; }


        [Display(Name = "Табельный номер")]
        [Required(ErrorMessage = "Введите табельный номер")]
        public int PersonnelNumber { get; set; }

        [Display(Name = "Должность")]
        [Required(ErrorMessage = "Выберите должность")]
        public string? Position { get; set; }

        [Display(Name = "Дата трудоустройства")]
        public string DateOfEmployment { get; set; } = DateTime.Now.ToString("D");

    }


}
