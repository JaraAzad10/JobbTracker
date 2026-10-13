using JobbTracker.Models;

namespace JobbTracker.Services;

public interface IJobApplicationService
{
    List<JobApplication> GetAll();
    JobApplication? GetById(int id);
    void Add(JobApplication application);
}