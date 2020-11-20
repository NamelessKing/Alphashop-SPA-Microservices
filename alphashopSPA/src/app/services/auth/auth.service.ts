import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() { }

  autentica(userId: string, password: string): boolean {
    if (userId === 'tan' && password === 'pass') {
      return true;
    } else {
      return false;
    }
  }
}
