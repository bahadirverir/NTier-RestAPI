using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;
using Repositories.RepositoryExtensions;

namespace Repositories.Concrete
{ 
    public class JobRepository : IJobRepository
    {
        private readonly ApplicationDbContext _context;
        public JobRepository(ApplicationDbContext context)
        {
            _context = context;
        } 

        public async Task<Job> CreateJob(Job job)
        {
            await _context.Jobs.AddAsync(job);
            await _context.SaveChangesAsync();
            return job;
        }

        public async Task<IEnumerable<Job>> GetAllJobs(bool trackChanges)
        {
            return await (trackChanges
                ? _context.Jobs
                : _context.Jobs.AsNoTracking())
                .ToListAsync();
        }

        public async Task<PagedList<Job>> GetJobsByParameters(JobParameters jobParameters, bool trackChanges)
        {
            var jobs = trackChanges
                ? _context.Jobs
                : _context.Jobs.AsNoTracking();

            jobs = jobs
                .FilterJobs(jobParameters)
                .Search(jobParameters.JobTitle)
                .Sort(jobParameters.OrderBy);  
            
            return await PagedList<Job>.ToPagedListAsync(
                jobs,
                jobParameters.PageNumber,
                jobParameters.PageSize);
        }   

        public async Task<Job> GetOneJobById(int id, bool trackChanges)
        {
            return await (trackChanges
                ? _context.Jobs
                : _context.Jobs.AsNoTracking())
                .FirstOrDefaultAsync(e => e.JobID == id);
        }

        public async Task<Job> UpdateJob(Job job)
        {
            _context.Jobs.Update(job);
            await _context.SaveChangesAsync();
            return job;
        }

        public async Task DeleteJob(int id)
        {
            var deletedJob = await GetOneJobById(id, false);
            _context.Jobs.Remove(deletedJob);
            await _context.SaveChangesAsync();
        }

        public async Task<Job> GetJobByTitle(string jobTitle, bool trackChanges)
        {
            return await (trackChanges
                ? _context.Jobs
                : _context.Jobs.AsNoTracking())
                .Where(j => j.JobTitle.ToLower() == jobTitle.ToLower())
                .FirstOrDefaultAsync();
        }
    }
}