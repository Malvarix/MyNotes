using System.Collections.Generic;
using Entities.Models;

namespace WebAPI.Interfaces
{
    public interface INoteService
    {
        List<Note> GetNotes();
        Note GetNoteById(int id);
        Note CreateNote(Note note);
        void DeleteNote(int id);
        Note UpdateNote(Note note);
    }
}