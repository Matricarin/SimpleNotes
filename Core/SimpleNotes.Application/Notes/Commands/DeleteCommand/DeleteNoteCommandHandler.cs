using MediatR;
using SimpleNotes.Application.Interfaces;
using SimpleNotes.Application.Notes.Commands.UpdateCommand;
using SimpleNotes.Domain;

namespace SimpleNotes.Application.Notes.Commands.DeleteCommand;

public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand>
{
    private readonly INotesDbContext _dbContext;

    public DeleteNoteCommandHandler(INotesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
    {
        var note = await _dbContext.Notes.FindAsync(request.Id, cancellationToken);

        if (note == null || note.UserId != request.UserId)
        {
            throw new NoteNotFoundException(nameof(Note), request.Id);
        }

        _dbContext.Notes.Remove(note);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}