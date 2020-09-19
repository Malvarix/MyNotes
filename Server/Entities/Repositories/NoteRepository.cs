using Entities.Interfaces;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace Entities.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly IRepositoryContext _repositoryContext;
        public NoteRepository(IRepositoryContext repositoryContext) => _repositoryContext = repositoryContext;
        public List<Note> GetNotes()
        {
            return _repositoryContext.Notes;
        }
        public Note GetNoteById(int id)
        {
            return _repositoryContext.Notes.Where(m => m.Id == id).FirstOrDefault();
        }
        public Note CreateNote(Note note)
        {
            _repositoryContext.Notes.Add(note);
            return note;
        }
        public Note UpdateNote(Note note)
        {
            return _repositoryContext.Notes.Where(m => m.Id == note.Id)
                .Select(m => { m.Description = note.Description; m.Priority = note.Priority; return m; }).FirstOrDefault();
        }
        public void DeleteNote(int id)
        {
            var note = _repositoryContext.Notes.Where(m => m.Id == id).FirstOrDefault();
            if(note != null)
            {
                _repositoryContext.Notes.Remove(note);
            }
        }
    }
}