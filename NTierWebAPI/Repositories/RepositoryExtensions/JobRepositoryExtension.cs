using System.Linq.Dynamic.Core;
using Entities.Models;
using Entities.RequestFeatures;

namespace Repositories.RepositoryExtensions
{ 
    public static class JobRepositoryExtension
    {
        public static IQueryable<Job> FilterJobs(this IQueryable<Job> jobs, JobParameters parameters)
        {
            if (parameters.DepartmentID.HasValue)
                jobs = jobs.Where(j => j.DepartmentID == parameters.DepartmentID.Value);

            return jobs;
        } 
          
        public static IQueryable<Job> Search(this IQueryable<Job> jobs, string? jobTitle)
        {
            if (!string.IsNullOrWhiteSpace(jobTitle))
            {
                var jttl = jobTitle.Trim().ToLower();
                jobs = jobs.Where(j => j.JobTitle.ToLower().Contains(jttl));
            }

            return jobs;
        }

        public static IQueryable<Job> Sort(this IQueryable<Job> jobs, string? orderByQueryStirng)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryStirng))
                return jobs.OrderBy(j => j.JobID);
            
            var orderQuery = OrderQueryBuilder
                .CreateOrderQuery<Job>(orderByQueryStirng);

            if(orderQuery is null)
                return jobs.OrderBy(j => j.JobID);
            
            return jobs.OrderBy(orderQuery);
        }
    }   
}
