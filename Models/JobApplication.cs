namespace JobbTracker.Models;

public enum ApplicationStatus
{
    Applied,
    Interview,
    Offer,
    Rejected
}

public class JobApplication
{
    public int Id { get; set; }
    public string Company { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public DateTime AppliedDate { get; set; }
    public ApplicationStatus Status { get; set; }
    public string? Notes { get; set; }
    public string? Url { get; set; }
}