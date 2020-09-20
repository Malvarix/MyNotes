using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Entities.Interfaces;
using Entities.Models;
using WebAPI.Interfaces;

namespace WebAPI.Services
{
    public class NoteService : INoteService // In the future this class and interface can be edited for add DTO, but right now we need all data in client side
    {
        private readonly IRepositoryContext _repositoryContext;
        public NoteService(IRepositoryContext repositoryContext) => _repositoryContext = repositoryContext;
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
            note.Id = _repositoryContext.Notes.Count > 0 ? _repositoryContext.Notes.Max(m => m.Id) + 1 : 0;
            //Debug.WriteLine("{0},{1},{2}", note.Id, note.Description, note.Priority);
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
            Debug.WriteLine(id);
            var note = _repositoryContext.Notes.Where(m => m.Id == id).FirstOrDefault();
            if (note != null)
            {
                try
                {
                    _repositoryContext.Notes.Remove(note);
                }
                catch(ArgumentOutOfRangeException)
                {
                    Debug.WriteLine("System.ArgumentOutOfRangeException");
                }
            }
        }
    }
}