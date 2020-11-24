import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-jumbotron',
  templateUrl: './jumbotron.component.html',
  styleUrls: ['./jumbotron.component.css']
})
export class JumbotronComponent implements OnInit {

  @Input() Title: string;
  @Input() SubTitle: string;
  @Input() Show = false;

  constructor() { }

  ngOnInit() {
  }

}
