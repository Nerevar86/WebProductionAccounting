using System.ComponentModel.DataAnnotations;

namespace WebProductionAccounting.Domain.Entities
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Scope { get; set; }
        public DateTime ImplementationDate { get; set; } = DateTime.Now;
        public Employee? Employee { get; set; }
    }
}
