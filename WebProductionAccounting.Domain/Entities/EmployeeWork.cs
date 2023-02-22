namespace WebProductionAccounting.Domain.Entities
{
    public class EmployeeWork
    {
        public int EmployeeId { get; set; } // First part of composite PK; FK to Employee
        public Employee? Employee { get; set; } // Reference navigation
        public int WorkId { get; set; } // First part of composite PK; FK to Work
        public Work? Work { get; set; } // Reference navigation
    }
}
