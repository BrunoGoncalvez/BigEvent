import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-title-page',
  templateUrl: './titlePage.component.html',
  styleUrls: ['./titlePage.component.scss']
})
export class TitlePageComponent implements OnInit {

  @Input() title: string = "";

  constructor() { }

  ngOnInit() {
  }

}
