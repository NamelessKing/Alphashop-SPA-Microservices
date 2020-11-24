import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() { }

  authenticate(userId: string, password: string): boolean {
    if (userId === 'tan' && password === 'pass') {
      sessionStorage.setItem('userId', userId);
      return true;
    } else {
      return false;
    }
  }

  getloggedUser(): string {
    const utente = sessionStorage.getItem('userId');
    return (utente) ? utente : '';
  }

  isLogged(): boolean {
    return (sessionStorage.getItem('userId') != null) ? true : false;
  }

  clearUserIdSessionStorage() {
    sessionStorage.removeItem('userId');
  }
}
