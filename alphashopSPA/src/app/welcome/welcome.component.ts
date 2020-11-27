import { WelcomeDataService } from './../services/data/productService/welcome-data.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.css']
})
export class WelcomeComponent implements OnInit {

  welcome = 'Benvenuti su AlphashopSPA';
  title = 'Seleziona articoli da acquistare';

  user = '';

  constructor(
    private route: ActivatedRoute,
    private welcomeDataService: WelcomeDataService
  ) { }

  ngOnInit() {
    this.user = this.route.snapshot.params.userid;
  }

  welcomeRequest() {
    this.welcomeDataService.welcomeRequest();
  }

}
