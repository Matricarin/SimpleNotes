using AutoMapper;
using SimpleNotes.Application.Common.Mappings;
using SimpleNotes.Domain;

namespace SimpleNotes.Application.Notes.Queries.GetNoteDetails;

public class NoteDetailsVm : IMapWith<Note>
{
    public string Content { get; set; }
    public DateTime Created { get; set; }
    public Guid Id { get; set; }
    public DateTime? Modified { get; set; }
    public string Title { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Note, NoteDetailsVm>()
            .ForMember(noteVm => noteVm.Id,
                opt => opt.MapFrom(note => note.Id))
            .ForMember(noteVm => noteVm.Title,
                opt => opt.MapFrom(note => note.Title))
            .ForMember(noteVm => noteVm.Content,
                opt => opt.MapFrom(note => note.Content))
            .ForMember(noteVm => noteVm.Created,
                opt => opt.MapFrom(note => note.Created))
            .ForMember(noteVm => noteVm.Modified,
                opt => opt.MapFrom(note => note.Modified));
    }
}