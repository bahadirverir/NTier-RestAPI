
namespace Entities.RequestFeatures
{ 
    public class EmployeeParameters : RequestParameters
    {
        protected override int MaxPageSize => 25; 
        public decimal? MinSalary { get; set; }
        public decimal? MaxSalary { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

    }
}
