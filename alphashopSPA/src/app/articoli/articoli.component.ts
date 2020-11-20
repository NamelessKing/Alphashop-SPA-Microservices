import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-articoli',
  templateUrl: './articoli.component.html',
  styleUrls: ['./articoli.component.css']
})
export class ArticoliComponent implements OnInit {

  articoli = [
    new Articolo('014600301', 'BARILLA FARINA 1 KG', 'PZ', 24, 1, 1.09, true, new Date(Date.now())),
    new Articolo( '014600301', 'BARILLA FARINA 1 KG', 'PZ', 24, 1, 1.09, true, new Date(Date.now())),
    new Articolo( '013500121','BARILLA PASTA GR.500 N.70 1/2 PENNE', 'PZ', 30, 0.5, 1.3 , true, new Date(Date.now()) ),
    new Articolo( '007686402', 'FINDUS FIOR DI NASELLO 300 GR', 'PZ', 8, 0.3, 6.46 , true, new Date(Date.now())),
    new Articolo('057549001', 'FINDUS CROCCOLE 400 GR',  'PZ', 12, 0.4, 5.97, true, new Date(Date.now()))
  ];


  constructor() { }

  ngOnInit() {
  }

}

export class Articolo {
  constructor(
    public codart: string,
    public descrizione: string,
    public um: string,
    public pzcart: number,
    public peso: number,
    public prezzo: number,
    public isActive: boolean,
    public date: Date
  ) {}
}
