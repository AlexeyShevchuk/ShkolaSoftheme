import { Component, Input, OnInit, Output } from '@angular/core';

import { ArticleDetailsModel } from './article-details.model';

@Component({
    selector: 'app-article-details',
    templateUrl: './article-details.component.html',
    styleUrls: ['./article-details.component.css']
})

export class ArticleDetailsComponent implements OnInit{
    article: ArticleDetailsModel
    color: string
    ngOnInit(){
    this.article =
    {
      id: "Стаття з рубрики: НОВИНИ",
      title: "Як знімали рекламу Apple в Ураїні",
      shortDescription: "Зазначте рубрику"
    }; 
    this.color = "green";
    }

    @Output()
	changeColor() {
		this.color = "red";
	}
}

// export class ArticleDetailsComponent {

// 	article: {
// 		id: string,
// 		title: string,
// 		shortDescription: string
//     };

//     start()
//     {
//         this.article.id = "1",
//         this.article.title = "2"
//         this.article.shortDescription = "2"
//     }

// 	changeColor() {
		
// 	}
// }
