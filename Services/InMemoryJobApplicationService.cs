using JobbTracker.Models;

namespace JobbTracker.Services;

public class InMemoryJobApplicationService : IJobApplicationService
{
    private readonly List<JobApplication> _applications = new()
    {
        new JobApplication { 
            Id = 1, 
            Company = "DNB", 
            Position = "Junior utvikler",
            AppliedDate = new DateTime(2026, 10, 1), 
            Status = ApplicationStatus.Applied,
            Notes = "",
            Url = "URL-navn"
            
            },


        new JobApplication { 
            Id = 2, 
            Company = "Visma", 
            Position = ".NET-utvikler",
            AppliedDate = new DateTime(2026, 9, 24), 
            Status = ApplicationStatus.Interview, 
            Url = "URL-navn"
            }
    };

    private int _nextId = 3;

    public List<JobApplication> GetAll()
        => _applications.OrderByDescending(a => a.AppliedDate).ToList();

    public JobApplication? GetById(int id)
        => _applications.FirstOrDefault(a => a.Id == id);

    public void Add(JobApplication application)
    {
        application.Id = _nextId++;
        _applications.Add(application);
    }
}