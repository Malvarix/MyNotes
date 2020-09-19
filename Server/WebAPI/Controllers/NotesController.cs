using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Interfaces;

namespace WebAPI.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService) => _noteService = noteService; 

        [HttpGet("{id}")]
        public IActionResult GetNoteById(int id = 0)
        {
            if (id != 0)
                return Ok(_noteService.GetNoteById(id));
            else
                return BadRequest();
        }

        [HttpGet]
        public IActionResult GetNotes()
        {
            return Ok(_noteService.GetNotes());
        }

        [HttpPost]
        public IActionResult CreateNote(Note note)
        {
            if (ModelState.IsValid)
            {
                //Debug.WriteLine("{0},{1},{2}", note.Id, note.Description, note.Priority);
                return Ok(_noteService.CreateNote(note));
            }
            else
                return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateNote(Note note)
        {
            if (ModelState.IsValid)
            {
                //Debug.WriteLine("{0},{1},{2}", note.Id, note.Description, note.Priority);
                return Ok(_noteService.UpdateNote(note));
            }
            else
                return BadRequest();
        }

        
        [HttpDelete("{id}")]
        public IActionResult DeleteNote(int id = 0)
        {
            if (id != 0)
            {
                //Debug.WriteLine(id);
                _noteService.DeleteNote(id);
                return Ok();
            }
            else
                return BadRequest();
        }
    }
}
