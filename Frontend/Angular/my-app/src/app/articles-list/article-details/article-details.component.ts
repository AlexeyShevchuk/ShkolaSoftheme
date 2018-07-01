import { Component, Input, OnInit, Output } from '@angular/core';

import { ArticleDetailsModel } from './article-details.model';

@Component({
    selector: 'app-article-details',
    templateUrl: './article-details.component.html',
    styleUrls: ['./article-details.component.css']
})

export class ArticleDetailsComponent implements OnInit {
    color: string;
    @Input()
    heading: string;
    @Input()
    article: ArticleDetailsModel;
    ngOnInit() {
        this.color = 'black';
    }
    @Output()
        changeColor() {
            this.color = 'grey';
    }
}
