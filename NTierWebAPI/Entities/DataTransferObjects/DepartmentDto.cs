using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects 
{ 
    public class DepartmentDto
    {
        [Required(ErrorMessage = "The field 'DepartmentID' is required!!!")]
        public int? DepartmentID { get; set; }
        
        [Required(ErrorMessage = "The field 'DepartmentName' is required!!!")]
        [StringLength(20, ErrorMessage = "'DepartmentName' cannot be longer than 20 characters.")]
        public string DepartmentName { get; set; }
    }
}