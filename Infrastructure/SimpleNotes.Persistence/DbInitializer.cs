namespace SimpleNotes.Persistence;

public sealed class DbInitializer
{
    public static void Initialize(NotesDbContext context)
    {
        context.Database.EnsureCreated();
    }
}