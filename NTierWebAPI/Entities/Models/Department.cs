using System.ComponentModel.DataAnnotations;

namespace Entities.Models 
{ 
    public class Department
    {
        [Key][Required]
        public int DepartmentID { get; set; }

        [Required]
        [StringLength(20)]
        public string DepartmentName { get; set; }

        public ICollection<Employee> Employees { get; set; }
        public ICollection<Job> Jobs { get; set; } 
    }
}
