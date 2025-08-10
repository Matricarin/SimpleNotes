using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleNotes.Application.Interfaces;
using SimpleNotes.Application.Notes.Commands.UpdateCommand;
using SimpleNotes.Domain;

namespace SimpleNotes.Application.Notes.Queries.GetNoteDetails;

public class GetNoteDetailsQueryHandler : IRequestHandler<GetNoteDetailsQuery, NoteDetailsVm>
{
    private readonly INotesDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetNoteDetailsQueryHandler(INotesDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<NoteDetailsVm> Handle(GetNoteDetailsQuery request, CancellationToken cancellationToken)
    {
        var note = await _dbContext.Notes.FirstOrDefaultAsync(n => n.Id == request.Id, cancellationToken);

        if (note == null || note.UserId != request.UserId)
        {
            throw new NoteNotFoundException(nameof(Note), request.Id);
        }

        return _mapper.Map<NoteDetailsVm>(note);
    }
}