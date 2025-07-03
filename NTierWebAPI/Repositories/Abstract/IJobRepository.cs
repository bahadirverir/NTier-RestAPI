using Entities.Models;
using Entities.RequestFeatures;

namespace Repositories.Abstract
{ 
    public interface IJobRepository
    {
        Task<PagedList<Job>> GetJobsByParameters(JobParameters jobParameters, bool trackChanges);
        Task<IEnumerable<Job>> GetAllJobs(bool trackChanges);
        Task<Job> GetOneJobById(int id, bool trackChanges);
        Task<Job> CreateJob(Job job);
        Task<Job> UpdateJob(Job job);
        Task DeleteJob(int id);
        Task<Job> GetJobByTitle(string jobTitle, bool trackChanges);
    }
}