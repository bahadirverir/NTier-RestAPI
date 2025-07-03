
namespace Entities.RequestFeatures
{ 
    public class JobParameters : RequestParameters
    {
        public int? DepartmentID { get; set; }
        public string? JobTitle { get; set; }
    }
}
