using Entities.Interfaces;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace Entities.Repositories
{
    public class RepositoryContext : IRepositoryContext
    {
        public List<Note> Notes { get; set; } = new List<Note>();
        public RepositoryContext()
        {
            Notes.Add(new Note { Id = Notes.Count > 0 ? Notes.Max(m => m.Id) + 1 : 1, Description = "Default description", Priority = Models.Enums.Priority.Low });
            Notes.Add(new Note { Id = Notes.Count > 0 ? Notes.Max(m => m.Id) + 1 : 1, Description = "Default description. Lorem ipsum dolor sit amet, consectetur adipiscing.", Priority = Models.Enums.Priority.Intermediate });
            Notes.Add(new Note { Id = Notes.Count > 0 ? Notes.Max(m => m.Id) + 1 : 1, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", Priority = Models.Enums.Priority.Intermediate });
            Notes.Add(new Note { Id = Notes.Count > 0 ? Notes.Max(m => m.Id) + 1 : 1, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", Priority = Models.Enums.Priority.Intermediate });
            Notes.Add(new Note { Id = Notes.Count > 0 ? Notes.Max(m => m.Id) + 1 : 1, Description = "Default description", Priority = Models.Enums.Priority.Intermediate });
            Notes.Add(new Note { Id = Notes.Count > 0 ? Notes.Max(m => m.Id) + 1 : 1, Description = "Not default description. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.", Priority = Models.Enums.Priority.Intermediate });
        }
    }
}