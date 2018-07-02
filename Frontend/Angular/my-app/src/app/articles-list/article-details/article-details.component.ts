import { Component, Input, OnInit, Output, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { switchMap } from 'rxjs/operators';

import { ArticleDetailsModel } from './article-details.model';
import { ArticlesListService } from '../articles-list.service';


@Component({
    selector: 'app-article-details',
    templateUrl: './article-details.component.html',
    styleUrls: ['./article-details.component.css']
})

export class ArticleDetailsComponent implements OnInit, OnDestroy {
    color: string;
    id: string;
    article: ArticleDetailsModel;
    private subscription: Subscription;

    constructor(private route: ActivatedRoute, private articlesService: ArticlesListService) { }

    @Input()
    heading: string;

    ngOnInit() {
        this.color = 'black';
        this.heading = 'НОВИНИ';
        this.subscription = this.route.params.pipe(
            switchMap(params => {
                this.id = params['id'];
                return this.articlesService.getArticle(this.id);
            }))
            .subscribe(res => this.article = res);
    }

    @Output()
        changeColor() {
            this.color = 'grey';
    }

    ngOnDestroy() {
        this.subscription.unsubscribe();
    }
}
