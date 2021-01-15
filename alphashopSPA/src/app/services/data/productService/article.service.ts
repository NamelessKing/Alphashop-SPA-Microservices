import { Article, ApiMessage } from './../../../articoli/articoli.component';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {

  private static readonly BASE_URL = 'http://localhost:5000/api/article';
  private static readonly SERVER = 'localhost';
  private static readonly PORT = '5000';


  constructor(private httpClient: HttpClient) { }

  public async getArticlesByDescription(description: string): Promise<Observable<Article[]>> {
    return this.httpClient.get<Article[]>(`${ArticleService.BASE_URL}/description/${description}`)
      .pipe(catchError(this.handleError));
  }

  public async getAllArticles(): Promise<Observable<Article[]>> {
    return this.httpClient.get<Article[]>(`${ArticleService.BASE_URL}`)
      .pipe(catchError(this.handleError));
  }

  public async getArticleByArticleId(articleId: string): Promise<Observable<Article>> {
    return this.httpClient.get<Article>(`${ArticleService.BASE_URL}/articleid/${articleId}`)
      .pipe(catchError(this.handleError));
  }

  public async getArticleByArticleIdWithAllProperties(articleId: string): Promise<Observable<Article>> {
    return this.httpClient.get<Article>(`${ArticleService.BASE_URL}/articleid/${articleId}/WithAllProperties`)
      .pipe(catchError(this.handleError));
  }

  public async getArticleByBarcodeId(barcodeId: string) {
    return this.httpClient.get<Article>(`${ArticleService.BASE_URL}/barcodeId/${barcodeId }`)
      .pipe(catchError(this.handleError));
  }

  public async deleteArticleByArticleId(articleId: string) {
    return this.httpClient.delete<ApiMessage>(`${ArticleService.BASE_URL}/delete/${articleId}`)
      .pipe(catchError(this.handleError));
  }

  handleError(error: any) {
    return throwError(error.message || 'Server Error');
  }
}
