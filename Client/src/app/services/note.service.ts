import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Note } from '../classes/note';
import { Observable } from 'rxjs';


@Injectable()
export class NoteService {

  private url = 'https://localhost:5001/api/notes';

  constructor(private http: HttpClient) { }
  getNoteById(id: number): Observable<Note> {
    return this.http.get<Note>(this.url + '/' + id);
  }
  getNotes(): Observable<Note[]> {
    return this.http.get<Note[]>(this.url);
  }
  createNote(note: Note): Observable<Note> {
    return this.http.post(this.url, note);
  }
  updateNote(note: Note): Observable<Note> {
    return this.http.put(this.url, note);
  }
  deleteNote(id: number): Observable<Note> {
    return this.http.delete(this.url + '/' + id);
  }
}
