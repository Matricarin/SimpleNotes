using MediatR;

namespace SimpleNotes.Application.Notes.Commands.UpdateCommand;

public class UpdateNoteCommand : IRequest
{
    public string Content { get; set; }
    public Guid Id { get; set; }
    public string Title { get; set; }
    public Guid UserId { get; set; }
}