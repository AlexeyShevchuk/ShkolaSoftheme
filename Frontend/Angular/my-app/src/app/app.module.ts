import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { ArticlesListComponent } from './articles-list/articles-list.component';
import { ArticleDetailsComponent } from './articles-list/article-details/article-details.component';
import { ArticlesListService } from './articles-list/articles-list.service';

@NgModule({
  declarations: [
    AppComponent,
    ArticlesListComponent,
    ArticleDetailsComponent
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  providers: [ArticlesListService],
  bootstrap: [AppComponent]
})

export class AppModule { }
