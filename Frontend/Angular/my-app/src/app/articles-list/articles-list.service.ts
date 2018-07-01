import { ArticleDetailsModel } from './article-details/article-details.model';

export class ArticlesListService {
    articles: ArticleDetailsModel[] = [{
        id: 'НОВИНИ',
        title: 'Як знімали рекламу Apple в Ураїні',
        shortDescription: 'Режисер кліпу Rolling in the Deep, скейтер з Іспанії та оператор на роликах з Південної Африки.'
    },
    {
        id: 'НОВИНИ',
        title: 'Як знімали рекламу Apple в Ураїні',
        shortDescription: 'Режисер кліпу Rolling in the Deep, скейтер з Іспанії та оператор на роликах з Південної Африки.'
    },
    {
        id: 'НОВИНИ',
        title: 'Як знімали рекламу Apple в Ураїні',
        shortDescription: 'Режисер кліпу Rolling in the Deep, скейтер з Іспанії та оператор на роликах з Південної Африки.'
    },
    {
        id: 'НОВИНИ',
        title: 'Як знімали рекламу Apple в Ураїні',
        shortDescription: 'Режисер кліпу Rolling in the Deep, скейтер з Іспанії та оператор на роликах з Південної Африки.'
    }
    ];

    getArticles(): ArticleDetailsModel[] {
        return this.articles;
    }
}
