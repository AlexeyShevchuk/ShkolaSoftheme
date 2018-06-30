import { Component, Input, OnInit, Output } from '@angular/core';

import { ArticleDetailsModel } from './article-details.model';

@Component({
    selector: 'app-article-details',
    templateUrl: './article-details.component.html',
    styleUrls: ['./article-details.component.css']
})

export class ArticleDetailsComponent implements OnInit {
    article: ArticleDetailsModel;
    color: string;
    @Input()
    heading: string;
    ngOnInit() {
    this.article = {
      id: 'НОВИНИ',
      title: 'Як знімали рекламу Apple в Ураїні',
      shortDescription: 'Режисер кліпу Rolling in the Deep, скейтер з Іспанії та оператор на роликах з Південної Африки.'
    };
    this.color = 'black';
    }
    @Output()
        changeColor() {
            this.color = 'grey';
        }
}
