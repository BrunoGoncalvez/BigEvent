import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-title-page',
  templateUrl: './titlePage.component.html',
  styleUrls: ['./titlePage.component.scss']
})
export class TitlePageComponent implements OnInit {

  @Input() title: string = "";
  @Input() icon: string = "fa fa-user";
  @Input() subtitle: string = "Since 2023";
  @Input() enableButton: Boolean = false;

  constructor() { }

  ngOnInit() {
  }

}
