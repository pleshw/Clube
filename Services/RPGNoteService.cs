using AngleSharp.Dom;
using Clube.Models.RPG;

namespace Clube.Services
{
    public class RPGNoteService
    {
        public static Guid AddNote( Note note )
        {
            using RPGContext dbNotes = new();

            Guid updatedId = dbNotes.Add( note ).Entity.Id;
            dbNotes.SaveChanges();

            return updatedId;
        }

        public static bool TryRemoveNoteById( string noteId )
        {
            return TryRemoveNoteById( new Guid( noteId ) );
        }
        
        public static bool TryRemoveNoteById( Guid noteId )
        {
            using RPGContext dbNotes = new();

            Note? note = dbNotes.Notes.Where( n => n.Id == noteId ).FirstOrDefault();
            if ( note == null )
            {
                return false;
            }

            dbNotes.Remove( note );
            dbNotes.SaveChanges();

            return true;
        }

        public static Guid RemoveNote( Note note )
        {
            using RPGContext dbNotes = new();

            Guid updatedId = dbNotes.Remove( note ).Entity.Id;
            dbNotes.SaveChanges();

            return updatedId;
        }

        public static Note? GetNoteById( Guid noteId )
        {
            using RPGContext dbNotes = new();

            return (from note in dbNotes.Notes
                    where note.Id == noteId
                    select note).FirstOrDefault();
        }

        public static List<Note> GetNotes()
        {
            using RPGContext dbNotes = new();

            return dbNotes.Notes.OrderByDescending( p => p.Created ).ToList();
        }

        public static Guid UpdateNote( Note note )
        {
            using RPGContext dbNotes = new();
            Guid updatedId = dbNotes.Notes.Update( note ).Entity.Id;
            dbNotes.SaveChanges();
            return updatedId;
        }
    }
}
