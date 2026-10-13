using System.ComponentModel.DataAnnotations;
using JobbTracker.Models;

namespace JobbTracker.ViewModels;

public class JobApplicationCreateViewModel
{
    [Required(ErrorMessage = "Firma må fylles ut")]
    [StringLength(100)]
    [Display(Name = "Firma")]
    public string Company { get; set; } = string.Empty;

    [Required(ErrorMessage = "Stilling må fylles ut")]
    [StringLength(100)]
    [Display(Name = "Stilling")]
    public string Position { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    [Display(Name = "Søkt dato")]
    public DateTime AppliedDate { get; set; } = DateTime.Today;

    public ApplicationStatus Status { get; set; } = ApplicationStatus.Applied;

    [Display(Name = "Notater")]
    public string? Notes { get; set; }

    [Url(ErrorMessage = "Må være en gyldig lenke, f.eks. https://...")]
    [Display(Name = "Lenke til annonsen")]
    public string? Url { get; set; }
}