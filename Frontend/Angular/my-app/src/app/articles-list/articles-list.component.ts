import { Component } from '@angular/core';

import { ArticleDetailsModel } from './article-details/article-details.model';
import { ArticlesListService } from './articles-list.service';

@Component({
    selector: 'app-articles-list',
    templateUrl: './articles-list.component.html',
    styleUrls: ['./articles-list.component.css']
})

export class ArticlesListComponent {
	articles: ArticleDetailsModel[];

	constructor(private service: ArticlesListService) {
		this.articles = this.service.getArticles();
	}
}
