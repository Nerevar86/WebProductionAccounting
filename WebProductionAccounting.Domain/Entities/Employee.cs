using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebProductionAccounting.Domain.Enum;

namespace WebProductionAccounting.Domain.Entities
{
    #region Entity Employee
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string? Lastname { get; set; }

        public string? Firstname { get; set; }

        public string? Middlename { get; set; }

        public int PersonnelNumber { get; set; }

        public EmployeePositions Position { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfEmployment { get; set; } = DateTime.Now;
        public virtual IList<Work> Works { get; } = new List<Work>(); // Skip collection navigation

        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual IList<EmployeeWork> EmployeeWorks { get; set; } = new List<EmployeeWork>(); // Collection navigation


    }
    #endregion
}
