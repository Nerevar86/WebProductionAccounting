using System.ComponentModel.DataAnnotations;

namespace WebProductionAccounting.Domain.Entities
{
    public class Work
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Scope { get; set; }
        public DateTime DateTimeImplementation { get; set; } = DateTime.Now;
        public IList<Employee> Employees { get; } = new List<Employee>(); // Skip collection navigation

        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public IList<EmployeeWork> EmployeeWorks { get; set; } = new List<EmployeeWork>(); // Collection navigation
    }
}
