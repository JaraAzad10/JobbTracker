using JobbTracker.Models;
using JobbTracker.Services;
using JobbTracker.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JobbTracker.Controllers;

public class JobApplicationsController : Controller
{
    private readonly IJobApplicationService _service;

    // ASP.NET sender inn servicen automatisk (dependency injection)
    public JobApplicationsController(IJobApplicationService service)
    {
        _service = service;
    }

    // GET /JobApplications
    public IActionResult Index()
    {
        var applications = _service.GetAll();
        return View(applications);
    }

    // GET /JobApplications/Create  → viser tomt skjema
    [HttpGet]
    public IActionResult Create()
    {
        return View(new JobApplicationCreateViewModel());
    }

    // POST /JobApplications/Create  → tar imot utfylt skjema
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(JobApplicationCreateViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            return View(vm); // vis skjemaet igjen med feilmeldinger
        }

        var application = new JobApplication
        {
            Company = vm.Company,
            Position = vm.Position,
            AppliedDate = vm.AppliedDate,
            Status = vm.Status,
            Notes = vm.Notes,
            Url = vm.Url
        };

        _service.Add(application);

        return RedirectToAction(nameof(Index));
    }
}