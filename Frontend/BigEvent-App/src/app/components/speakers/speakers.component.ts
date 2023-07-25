import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-speakers',
  templateUrl: './speakers.component.html',
  styleUrls: ['./speakers.component.scss']
})
export class SpeakersComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  public speakers = [
    {name:"Steve Jobs", age: 20},
    {name: "Bill Gates", age: 23},
    {name: "Jeff Bezos", age: 30},
    {name: "Elon Musk", age: 50},
    {name: "Mark Zuckerberg", age: 35}
  ]

}
