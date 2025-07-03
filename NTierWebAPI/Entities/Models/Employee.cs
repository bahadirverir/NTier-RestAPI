using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models 
{ 
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity )]
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [Column(TypeName = "decimal(10,3)")]
        public decimal Salary { get; set; }

        public int? DepartmentID { get; set; }
        public int? JobID { get; set; }

        [ForeignKey("DepartmentID")]
        public Department Department { get; set; } 
        
        [ForeignKey("JobID")]
        public Job Job { get; set; }
    }
}
