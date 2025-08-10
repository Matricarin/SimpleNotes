using MediatR;

namespace SimpleNotes.Application.Notes.Commands.CreateCommand;

public class CreateNoteCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}