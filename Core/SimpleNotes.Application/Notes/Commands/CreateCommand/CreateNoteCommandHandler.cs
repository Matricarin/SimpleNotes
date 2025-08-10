using MediatR;
using SimpleNotes.Application.Interfaces;
using SimpleNotes.Domain;

namespace SimpleNotes.Application.Notes.Commands.CreateCommand;

public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, Guid>
{
    private readonly INotesDbContext _dbContext;

    public CreateNoteCommandHandler(INotesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        var note = new Note
        {
            UserId = request.UserId,
            Id = Guid.NewGuid(),
            Title = request.Title,
            Content = request.Content,
            Created = DateTime.Now,
            Modified = null
        };

        await _dbContext.Notes.AddAsync(note, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return note.Id;
    }
}