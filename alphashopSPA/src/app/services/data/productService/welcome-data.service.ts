import { HttpClient} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WelcomeDataService {

  private static readonly BASE_URL = 'http://localhost:5000/welcome';

  constructor(private httpClient: HttpClient) { }

  // public welcomeRequest() {
  //   return this.httpClient.get(`${WelcomeDataService.BASE_URL}`);
  // }

  // public welcomeRequest();
  // public welcomeRequest(name: string);
  public welcomeRequest(name?: string) {
    if (typeof name === 'string') {
      return this.httpClient.get(`${WelcomeDataService.BASE_URL}/${name}`);
    } else {
      return this.httpClient.get(`${WelcomeDataService.BASE_URL}`);
    }
  }
}
