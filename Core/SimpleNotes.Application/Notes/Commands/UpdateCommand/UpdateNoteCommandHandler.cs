
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleNotes.Application.Interfaces;
using SimpleNotes.Domain;

namespace SimpleNotes.Application.Notes.Commands.UpdateCommand;

public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand>
{
    private INotesDbContext _dbContext;

    public UpdateNoteCommandHandler(INotesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
    {
        var note = await _dbContext.Notes.FirstOrDefaultAsync(n => n.Id == request.Id, cancellationToken);

        if (note == null || note.UserId != request.UserId)
        {
            throw new NoteNotFoundException(nameof(Note), note.Id);
        }

        note.Content = request.Content;
        note.Title = request.Title;
        note.Modified = DateTime.Now;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}

public class NoteNotFoundException : Exception
{
    public NoteNotFoundException(string noteName, object key)
    :base ($"Note [{noteName}] - [{key}] not found.")
    {

    }
}