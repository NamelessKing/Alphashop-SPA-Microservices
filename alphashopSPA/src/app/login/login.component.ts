import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  userId = '';
  password = '';
  autenticato = false;
  errorMessage = 'La userid o la password non sono corretti';

  constructor(private route: Router) { }

  ngOnInit() {
  }

  gestioneAutenticazione() {
    if (this.userId === 'tan' && this.password === 'pass') {
      this.route.navigate(['welcome', this.userId]);
      this.autenticato = true;
    } else {
      this.autenticato = false;
    }
  }

}
