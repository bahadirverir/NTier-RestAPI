using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{ 
    public class EmployeeDto
    {
        [Required(ErrorMessage = "The field 'EmployeeID' is required!!!")]
        public int? EmployeeID { get; set; }

        [Required(ErrorMessage = "The field 'FirstName' is required!!!")]
        [StringLength(25, ErrorMessage = "'FirstName' cannot be longer than 25 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The field 'LastName' is required!!!")]
        [StringLength(20, ErrorMessage = "'LastName' cannot be longer than 20 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The field 'Salary' is required!!!")]
        public decimal? Salary { get; set; }

        [Required(ErrorMessage = "The field 'DepartmentID' is required!!!")]
        public int? DepartmentID { get; set; }

        [Required(ErrorMessage = "The field 'JobID' is required!!!")]
        public int? JobID { get; set; }
    }
}