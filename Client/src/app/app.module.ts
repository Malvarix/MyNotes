import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NotesListComponent } from './components/note-list.component';
import { NoteFormComponent } from './components/note-form.component';
import { NoteCreateComponent } from './components/note-create.component';
import { NoteEditComponent } from './components/note-edit.component';

import { NoteService } from './services/note.service';

import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { HttpClient } from '@angular/common/http';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';


const appRoutes: Routes = [
  { path: '', component: NotesListComponent },
  { path: 'create', component: NoteCreateComponent },
  { path: 'edit/:id', component: NoteEditComponent }
];

export function HttpLoaderFactory(http: HttpClient): TranslateHttpLoader {
  return new TranslateHttpLoader(http);
}

@NgModule({
    imports: [
      BrowserModule,
      FormsModule,
      HttpClientModule,
      RouterModule.forRoot(appRoutes),
      HttpClientModule,
      TranslateModule.forRoot({
          loader: {
              provide: TranslateLoader,
              useFactory: HttpLoaderFactory,
              deps: [HttpClient]
          },
          defaultLanguage: localStorage.getItem('lang') || 'en'
      })
    ],
    declarations: [AppComponent, NotesListComponent, NoteFormComponent, NoteCreateComponent, NoteEditComponent],
    providers: [NoteService],
    bootstrap: [AppComponent]
})
export class AppModule {}
