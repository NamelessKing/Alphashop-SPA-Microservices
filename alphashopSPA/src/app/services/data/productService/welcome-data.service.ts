import { HttpClient} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class WelcomeDataService {

  private static readonly BASE_URL = 'http://localhost:5000/api/welcome';

  constructor(private httpClient: HttpClient) { }

  // public welcomeRequest() {
  //   return this.httpClient.get(`${WelcomeDataService.BASE_URL}`);
  // }

  // public welcomeRequest();
  // public welcomeRequest(name: string);
  public welcomeRequest(name?: string): Observable<string> {
    if (typeof name === 'string') {
      return this.httpClient.get<string>(`${WelcomeDataService.BASE_URL}/${name}`)
        .pipe(catchError(this.handleError));
    } else {
      return this.httpClient.get<string>(`${WelcomeDataService.BASE_URL}`)
        .pipe(catchError(this.handleError));
    }
  }

  handleError(error: any) {
    return throwError(error.message || 'Server Error');
  }



}
