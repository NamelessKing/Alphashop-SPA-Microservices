import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.css']
})
export class WelcomeComponent implements OnInit {

  saluti = 'Benvenuti su AlphashopSPA';
  titolo = 'Seleziona articoli da acquistare';

  utente = '';

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.utente = this.route.snapshot.params.userid;
  }

}
