import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NoteService } from '../services/note.service';
import { Note } from '../classes/note';

@Component({
    templateUrl: './note-create.component.html',
    styleUrls: ['../app.component.scss']
})
export class NoteCreateComponent {
    note: Note = new Note();
    constructor(private noteService: NoteService, private router: Router) { }
    save(): void {
      if (typeof this.note.description != 'undefined' && this.note.description){
        this.noteService.createNote(this.note).subscribe(data => this.router.navigateByUrl('/'));
      }
      else {
        alert('Please, fill description field!');
      }
    }
}
