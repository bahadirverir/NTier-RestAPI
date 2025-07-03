using System.Dynamic;
using Entities.DataTransferObjects;
using Entities.RequestFeatures;

namespace Services.Abstract
{ 
    public interface IJobService
    {
        Task<(IEnumerable<ExpandoObject> jobs, MetaData metaData)> GetJobsByParameters(JobParameters jobParameters, bool trackChanges);
        Task<IEnumerable<JobDto>> GetAllJobs(bool trackChanges);
        Task<JobDto> GetOneJobById(int id, bool trackChanges);
        Task<JobDto> CreateJob(JobDto jobDto);
        Task<JobDtoForUpdate> UpdateJob(JobDtoForUpdate jobDto, int id);
        Task DeleteJob(int id);
    }
}