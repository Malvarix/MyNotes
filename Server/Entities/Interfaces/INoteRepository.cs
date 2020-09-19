using Entities.Models;
using System.Collections.Generic;

namespace Entities.Interfaces
{
    public interface INoteRepository
    {
        List<Note> GetNotes();
        Note GetNoteById(int id);
        Note CreateNote(Note note);
        void DeleteNote(int id);
        Note UpdateNote(Note note);
    }
}