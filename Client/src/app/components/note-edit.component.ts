import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { NoteService } from '../services/note.service';
import { Note } from '../classes/note';

@Component({
    templateUrl: './note-edit.component.html',
    styleUrls: ['../app.component.scss']
})
export class NoteEditComponent implements OnInit {

    id: number;
    note: Note;
    loaded = false;

    constructor(private noteService: NoteService, private router: Router, activeRoute: ActivatedRoute) {
        this.id = Number.parseInt(activeRoute.snapshot.params['id'], 10);
    }

    ngOnInit(): void {
        if (this.id) {
            this.noteService.getNoteById(this.id)
                .subscribe((data: Note) => {
                    this.note = data;
                    if (this.note != null) { this.loaded = true; }
                });
        }
    }

    save(): void {
        this.noteService.updateNote(this.note).subscribe(data => this.router.navigateByUrl('/'));
    }
}
