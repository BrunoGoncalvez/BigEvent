import { HttpClient } from '@angular/common/http';
import { Component, OnInit, AfterContentChecked } from '@angular/core';

declare function initStyle() : any;


@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss']
})

export class EventsComponent implements OnInit, AfterContentChecked {

  public events : any = [];
  public filteredEvents : any = [];

  public showImage: boolean = false;
  private _searchEvent : string = "";

  public get searchEvent() : string{
    return this._searchEvent;
  }

  public set searchEvent(value : string){
    this._searchEvent = value;
    this.filteredEvents = this._searchEvent ? this.filterEvents(this._searchEvent) : this.events;
  }

  constructor(public http: HttpClient) { }

  ngOnInit(): void {
    this.getEvents();
  }

  ngAfterContentChecked(): void {
    initStyle();
  }

  public getEvents() : void{
    this.http.get('https://localhost:5001/api/events').subscribe(
      response => {
        this.events = response;
        this.filteredEvents = response
      },
      error => console.log( error )
    );
  }

  public filterEvents(textFilter : string) : any{
    textFilter = textFilter.toLocaleLowerCase();
    return this.events.filter(
      (event : any) => event.theme.toLocaleLowerCase().indexOf(textFilter) !== -1
      || event.local.toLocaleLowerCase().indexOf(textFilter) !== -1
    )
  }

  public showImage_Click() : void {
    this.showImage = !this.showImage;
  }
}