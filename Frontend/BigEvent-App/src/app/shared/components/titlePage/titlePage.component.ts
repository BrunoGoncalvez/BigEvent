import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

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

  constructor(private router: Router) { }

  ngOnInit() {
  }

  listEvents(){
    this.router.navigate([`/${this.title.toLocaleLowerCase()}/list`]);
  }

}
