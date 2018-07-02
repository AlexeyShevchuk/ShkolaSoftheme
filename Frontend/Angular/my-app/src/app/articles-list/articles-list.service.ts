import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { ArticleDetailsModel } from './article-details/article-details.model';

const requestUrl = 'http://localhost:3000';

@Injectable()
export class ArticlesListService {
    constructor(private http: HttpClient) { }

    getArticles(): Observable<ArticleDetailsModel[]> {
        return this.http.get<ArticleDetailsModel[]>(`${requestUrl}/articles`);
    }

    getArticle(id: string): Observable<ArticleDetailsModel> {
        return this.http.get<ArticleDetailsModel>(`${requestUrl}/articles/${id}`);
    }
}
