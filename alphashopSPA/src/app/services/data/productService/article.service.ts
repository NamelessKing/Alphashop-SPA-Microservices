import { Article } from './../../../articoli/articoli.component';
import { HttpClient} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {

  private static readonly BASE_URL = 'http://localhost:5000/api/article';

  constructor(private httpClient: HttpClient) { }

  public GetArticlesByDescription(description: string): Observable<Article[]> {

      return this.httpClient.get<Article[]>(`${ArticleService.BASE_URL}/description/${description}`)
        .pipe(catchError(this.handleError));
  }

  public async GetAllArticles(): Promise<Observable<Article[]>> {

      return await this.httpClient.get<Article[]>(`${ArticleService.BASE_URL}`)
        .pipe(catchError(this.handleError));
  }

  handleError(error: any) {
    return throwError(error.message || 'Server Error');
  }
}
