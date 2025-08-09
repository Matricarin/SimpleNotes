namespace SimpleNotes.Domain;

public class Note
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Content { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Modified { get; set; }
}