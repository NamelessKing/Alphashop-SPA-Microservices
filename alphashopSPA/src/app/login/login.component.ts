import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  userId = '';
  password = '';
  autenticato: boolean;
  errorMessage = 'La userid o la password non sono corretti';

  constructor(private route: Router, private basicAuth: AuthService) { }

  ngOnInit() {
  }

  gestioneAutenticazione() {
    this.autenticato = this.basicAuth.autentica(this.userId, this.password);
    if (this.autenticato) {
      this.route.navigate(['welcome', this.userId]);
    }
  }

}
