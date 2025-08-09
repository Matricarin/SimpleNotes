using Microsoft.EntityFrameworkCore;
using SimpleNotes.Application.Interfaces;
using SimpleNotes.Domain;
using SimpleNotes.Persistence.EntityTypeConfiguration;

namespace SimpleNotes.Persistence;

public sealed class NotesDbContext : DbContext, INotesDbContext
{
    public DbSet<Note> Notes { get; set; }

    public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new NoteConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}