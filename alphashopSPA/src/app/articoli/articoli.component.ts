import { async } from '@angular/core/testing';
import { ArticleService } from './../services/data/productService/article.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-articoli',
  templateUrl: './articoli.component.html',
  styleUrls: ['./articoli.component.css']
})
export class ArticoliComponent implements OnInit {

  // items = [
  //   new Articolo('014600301', 'BARILLA FARINA 1 KG', 'PZ', 24, 1, 1.09, true, new Date(Date.now())),
  //   new Articolo( '014600301', 'BARILLA FARINA 1 KG', 'PZ', 24, 1, 1.09, true, new Date(Date.now())),
  //   new Articolo( '013500121', 'BARILLA PASTA GR.500 N.70 1/2 PENNE', 'PZ', 30, 0.5, 1.3 , true, new Date(Date.now()) ),
  //   new Articolo( '007686402', 'FINDUS FIOR DI NASELLO 300 GR', 'PZ', 8, 0.3, 6.46 , true, new Date(Date.now())),
  //   new Articolo('057549001', 'FINDUS CROCCOLE 400 GR',  'PZ', 12, 0.4, 5.97, true, new Date(Date.now()))
  // ];

  articles: Article[];

  numberOfArticles = 0;
  page = 1;
  articlesPerPage = 1;
  // message: any;

  filter = '';

  articleId = '';

  apiMessage: ApiMessage;

  constructor(
    private route: ActivatedRoute,
    private articleService: ArticleService) { }

  ngOnInit() {
    this.getArticles();
  }

  public async getArticles(filter?: string | undefined): Promise<void> {

    let articlesObservable: Observable<Article[]>;
    if (this.isEmpty(filter)) {
      articlesObservable = await this.articleService.getAllArticles();
    } else {
      articlesObservable = await this.articleService.getArticlesByDescription(filter);
    }

    articlesObservable.subscribe(
      (articles) => {
        console.log(articles);
        this.articles = articles;
        this.numberOfArticles = this.articles.length;
      },
      (err) => { console.log(err); this.articles = []; }
    );
  }

  public async getArticleByArticleId(articleId: string) {
    const regexpArticleId: RegExp = /([0-9])\w{5,8}/;

    this.articles = [];
    if (regexpArticleId.test(articleId)) {
      const articleObservable: Observable<Article> = await this.articleService.getArticleByArticleId(articleId);

      articleObservable.subscribe(
        (article) => {
          console.log(article);
          this.articles.push(article);
          this.numberOfArticles = this.articles.length;
        },
        (err) => { console.log(err); this.articles = []; }
      );
    } else {
      console.log('ID non valido'); this.articles = [];
    }
  }

  public async deleteArticlebyArticleID(articleId: string) {
    console.log(`Eliminazione articolo ${articleId}`);

    (await this.articleService.deleteArticleByArticleId(articleId)).subscribe(
      (response) => {
        console.log(response);
        this.apiMessage = response;
        this.getArticles();
      },
      (err) => { console.log(err);}
    );
  }

  public async updateArticle(articleId: string) {
    console.log(`Modifica articolo ${articleId}`);
  }



  private isEmpty(str: string): boolean {
    return (!str || 0 === str.length);
  }

}

export class ApiMessage{
  constructor(public code: string, public message: string) {

  }
}

export class Article {
  constructor(
    public articleId: string,
    public descrizione: string,
    public um: string,
    public codeStat: string,
    public pzCart: number,
    public pesoNetto: number,
    public prezzo: number,
    public isActive: boolean,
    public dataCreazione: Date
  ) { }
}
