import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  username = '';
  password = '';
  authenticated: boolean;
  errorMessage = 'La userid o la password non sono corretti';

  constructor(private route: Router, private auth: AuthService) { }

  ngOnInit() {
  }

  gestioneAutenticazione() {
    this.authenticated = this.auth.authenticate(this.username, this.password);
    if (this.authenticated) {
      this.route.navigate(['welcome', this.username]);
      // console.log(this.username);
    }
  }

}
