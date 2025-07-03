using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects 
{ 
    public record UserForRegistrationDto
    {
        public string? FirstName { get; init;}
        public string? LastName { get; init;}

        [Required(ErrorMessage = "UserName is Required")]
        public string? UserName { get; set;}

        [Required(ErrorMessage = "UserName is Required")]
        public string? PassWord { get; set;}

        public string? Email { get; set;}
        public string? PhoneNumber { get; set;}

        public ICollection<string> Roles { get; init; }
    }
}
