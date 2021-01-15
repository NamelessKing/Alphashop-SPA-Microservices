import { ArticleService } from './../services/data/productService/article.service';
import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { Article } from '../articoli/articoli.component';

@Component({
  selector: 'app-new-article',
  templateUrl: './new-article.component.html',
  styleUrls: ['./new-article.component.css']
})
export class NewArticleComponent implements OnInit {

  articleId: string;

  article: Article;

  constructor(
    private route: ActivatedRoute,
    private articleService: ArticleService
  ) { }

  async ngOnInit() {
    this.articleId = this.route.snapshot.paramMap.get('articleId');
    console.log(this.articleId);
    (await this.articleService.getArticleByArticleIdWithAllProperties(this.articleId)).subscribe(
      (response) => {
        this.article = response;
        console.log(this.article);
      },
      (err) => { console.log(err); }
    );
  }

}
