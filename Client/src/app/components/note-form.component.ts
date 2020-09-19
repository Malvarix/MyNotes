import { Component, Input } from '@angular/core';
import { Note } from '../classes/note';
@Component({
    // tslint:disable-next-line: component-selector
    selector: 'note-form',
    templateUrl: './note-form.component.html',
    styleUrls: ['../app.component.scss']
})
export class NoteFormComponent {
    @Input() note: Note;
}
