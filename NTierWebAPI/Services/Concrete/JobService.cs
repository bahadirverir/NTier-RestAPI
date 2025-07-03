using System.Dynamic;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Abstract;
using Services.Abstract;

namespace Services.Concrete
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IMapper _mapper;
        private readonly IDataShaper<JobDto> _shaper;
        
        public JobService(IJobRepository jobRepository, IMapper mapper, IDataShaper<JobDto> shaper )
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
            _shaper = shaper;
        }
        
        public async Task<JobDto> CreateJob(JobDto jobDto)
        {
            var existingJobByTitle = await _jobRepository.GetJobByTitle(jobDto.JobTitle, false);
            var existingJobByID = await _jobRepository.GetOneJobById((int)jobDto.JobID, false);

            if(existingJobByTitle != null && existingJobByID != null)
                throw new JobDuplicateException("JobID",jobDto.JobID.ToString(),
                                                       "JobTitle",jobDto.JobTitle);  
            if(existingJobByID != null)
                throw new JobDuplicateException("JobID",jobDto.JobID.ToString());
            
            if(existingJobByTitle != null)
                throw new JobDuplicateException("jobTitle",jobDto.JobTitle);  

            var job = _mapper.Map<Job>(jobDto);
            var createdJob = await _jobRepository.CreateJob(job);
            return _mapper.Map<JobDto>(createdJob);
        }

        public async Task<IEnumerable<JobDto>> GetAllJobs(bool trackChanges)
        {
            var jobs = await _jobRepository.GetAllJobs(trackChanges);
            return _mapper.Map<IEnumerable<JobDto>>(jobs);
        }

        public async Task<(IEnumerable<ExpandoObject> jobs, MetaData metaData)> GetJobsByParameters(JobParameters jobParameters, bool trackChanges)
        {
            var jobsWithMetaData = await _jobRepository.GetJobsByParameters(jobParameters, trackChanges);

            var jobsDto = _mapper.Map<IEnumerable<JobDto>>(jobsWithMetaData);

            var shapedData = _shaper.ShapeData(jobsDto, jobParameters.Fields);

            return (jobs : shapedData, metaData : jobsWithMetaData.MetaData);
        }

        public async Task<JobDto> GetOneJobById(int id, bool trackChanges)
        {
            var job = await _jobRepository.GetOneJobById(id, trackChanges);
            if(job == null)
            {
                throw new JobNotFoundException(id);
            }
           return _mapper.Map<JobDto>(job);
        }

        public async Task<JobDtoForUpdate> UpdateJob(JobDtoForUpdate jobDto, int id)
        {
            var jobEntity = await _jobRepository.GetOneJobById(id, true);
            if (jobEntity == null)
            {
                throw new JobNotFoundException(id);
            }
            _mapper.Map(jobDto, jobEntity); 
            await _jobRepository.UpdateJob(jobEntity); 
            return _mapper.Map<JobDtoForUpdate>(jobEntity); 
        }

        public async Task DeleteJob(int id)
        {
            var job = await _jobRepository.GetOneJobById(id, false);
            if(job == null)
            {
                throw new JobNotFoundException(id);
            }
            await _jobRepository.DeleteJob(id);
        }
    }
}