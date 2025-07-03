using System.ComponentModel.DataAnnotations;

namespace Entities.Models 
{ 
    public class Job
    {
        [Key][Required]
        public int JobID { get; set; }

        [Required]
        [StringLength(20)]
        public string JobTitle { get; set; }

        public int? DepartmentID { get; set; } 

        public ICollection<Employee> Employees { get; set; } 
        public Department Department { get; set; }
    }
}
