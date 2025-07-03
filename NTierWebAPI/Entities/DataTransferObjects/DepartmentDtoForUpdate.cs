using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects 
{ 
    public class DepartmentDtoForUpdate
    {        
        [Required(ErrorMessage = "The field 'DepartmentName' is required!!!")]
        [StringLength(20, ErrorMessage = "'DepartmentName' cannot be longer than 20 characters.")]
        public string DepartmentName { get; set; }
    }
}