using Entities.Models;
using System.Collections.Generic;

namespace Entities.Interfaces
{
    public interface IRepositoryContext
    {
        List<Note> Notes { get; set; }
    }
}