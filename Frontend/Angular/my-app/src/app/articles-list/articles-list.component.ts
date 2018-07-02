import { Component, OnInit } from '@angular/core';

import { ArticleDetailsModel } from './article-details/article-details.model';
import { ArticlesListService } from './articles-list.service';

@Component({
    selector: 'app-articles-list',
    templateUrl: './articles-list.component.html',
    styleUrls: ['./articles-list.component.css']
})

export class ArticlesListComponent implements OnInit {
articles: ArticleDetailsModel[];

constructor(private service: ArticlesListService) { }

ngOnInit() {
this.service.getArticles()
.subscribe(response => this.articles = response);
}
}
