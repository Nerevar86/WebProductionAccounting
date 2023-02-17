using System.ComponentModel.DataAnnotations;
using WebProductionAccounting.Domain.Enum;

namespace WebProductionAccounting.Domain.Entities
{
    #region Entity Employee
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Фамилия")]
        [Required]
        [Range(2, 50)]
        public string? Lastname { get; set; }
        [Display(Name = "Имя")]
        [Required]
        [Range(2, 50)]
        public string? Firstname { get; set; }
        [Display(Name = "Отчество")]
        [Required]
        [Range(2, 50)]
        public string? Middlename { get; set; }
        [Display(Name = "Табельный номер")]
        public int PersonnelNumber { get; set; }
        [Display(Name = "Должность")]
        [Required]
        public EmployeePositions Position { get; set; }
        [Display(Name = "Дата трудоустройства")]
        [Required]
        public DateTime DateOfEmployment { get; set; } = DateTime.Now;
        public virtual List<Job> Jobs { get; set; } = new();


    }
    #endregion
}
