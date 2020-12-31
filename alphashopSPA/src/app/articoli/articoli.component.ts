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
  //message: any;

  filter = '';


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
      (data) => {
        console.log(data);
        this.articles = data;
        this.numberOfArticles = this.articles.length;
      },
      (err) => { console.log(err); this.articles = null; }
    );
  }

  public async getArticleByArticleId(articleId: string) {
    
  }



  private isEmpty(str: string): boolean {
    return (!str || 0 === str.length);
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
