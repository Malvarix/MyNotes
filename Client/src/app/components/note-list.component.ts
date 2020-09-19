import { Component, OnInit } from '@angular/core';
import { NoteService } from '../services/note.service';
import { Note } from '../classes/note';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { stringify } from 'querystring';

@Component({
    templateUrl: './note-list.component.html',
    styleUrls: ['../app.component.scss'],
})

export class NotesListComponent implements OnInit {

    lang: string;

    notes: Note[];
    constructor(private noteService: NoteService) {}

    ngOnInit(): void {
      this.lang = localStorage.getItem('lang') || 'en';
      this.loadNotes();
    }
    loadNotes(): void {
      this.noteService.getNotes().subscribe((data: Note[]) => this.notes = data);
    }
    delete(id: number): void {
        this.noteService.deleteNote(id).subscribe(data => this.loadNotes());
    }
    truncateChar(text: string): string {
      const charlimit = 80;
      if (!text || text.length <= charlimit )
      {
          return text;
      }
      const withoutHtml = text.replace(/<(?:.|\n)*?>/gm, '');
      const shortened = withoutHtml.substring(0, charlimit) + '...';
      return shortened;
    }
    changeLang(lang: string): void{
      localStorage.setItem('lang', lang);
      window.location.reload();
    }
    defineLang(str: string): string{
      if (str === 'Low'){
        return 'HOME.PRIORITY.LOW';
      }
      else if (str === 'Intermediate'){
        return 'HOME.PRIORITY.INTERMEDIATE';
      }
      else {
        return 'HOME.PRIORITY.HIGH';
      }
    }
}
