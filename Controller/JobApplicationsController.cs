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

    //GET: /JobApplications/Details/5
    [HttpGet]
    public IActionResult Details(int id)
    {
        var application = _service.GetById(id);
        if (application == null)
        {
            return NotFound();
        }
        return View(application);
    }

    //GET: /JobApplication/Edit/5
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var application = _service.GetById(id);
        if (application == null)
        {
            return NotFound();
        }

        var vm = new JobApplicationEditViewModel
        {
            Id = application.Id,
            Company = application.Company,
            Position = application.Position,
            AppliedDate = application.AppliedDate,
            Status = application.Status,
            Notes = application.Notes,
            Url = application.Url
        };
        return View(vm);
    }

    //POST: /JobApplication/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, JobApplicationEditViewModel vm)
    {
        if (id != vm.Id)
        {
            return BadRequest();
        }
        if (ModelState.IsValid)
        {
            return View(vm);
        }

        var application = new JobApplication
        {
            Id = vm.Id,
            Company = vm.Company,
            Position = vm.Position,
            AppliedDate = vm.AppliedDate,
            Status = vm.Status,
            Notes = vm.Notes,
            Url = vm.Url
        };

        if (!_service.Update(application))
        {
            return NotFound();
        }

        return RedirectToAction(nameof(Details), new { id = vm.Id });
    }


    //GET: /JobApplication/Delete/5 -> bekreftelsesside
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var application = _service.GetById(id);
        if (application == null)
        {
            return NotFound();
        }
        return View(application);
    }

    // POST /JobApplications/Delete/5  → selve slettingen
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        if (!_service.Delete(id))
        {
            return NotFound();
        }
        return RedirectToAction(nameof(Index));
    }
}