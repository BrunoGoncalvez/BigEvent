import { Component, OnInit, AfterContentChecked } from '@angular/core';
import { EventService } from '../services/event.service';
import { Event } from '../models/Event';

declare function initStyle() : any;


@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss']
})

export class EventsComponent implements OnInit, AfterContentChecked {

  private _searchEvent : string = "";

  public events : Event[] = [];
  public filteredEvents : Event[] = [];
  public showImage: boolean = false;

  public get searchEvent() : string{
    return this._searchEvent;
  }

  public set searchEvent(value : string){
    this._searchEvent = value;
    this.filteredEvents = this._searchEvent ? this.filterEvents(this._searchEvent) : this.events;
  }

  constructor(private eventService : EventService) { }

  public ngOnInit(): void {
    this.getEvents();
  }

  public ngAfterContentChecked(): void {
    initStyle();
  }

  public getEvents() : void{

    this.eventService.getEvents().subscribe(
      (evs : Event[]) => {
        this.events = evs;
        this.filteredEvents = evs;
      }, error => { console.log("Error: " + error) }
      // {
      //   next: (evs : Event[]) => {
      //     this.events = evs;
      //     this.filteredEvents = evs;
      //   },
      //   error: (error) => {
      //     console.log( error )
      //   }
      // }
    );
  }

  public filterEvents(textFilter : string) : Event[]{
    textFilter = textFilter.toLocaleLowerCase();
    return this.events.filter(
      (event : Event) => event.theme.toLocaleLowerCase().indexOf(textFilter) !== -1
      || event.local.toLocaleLowerCase().indexOf(textFilter) !== -1
    )
  }

  public showImage_Click() : void {
    this.showImage = !this.showImage;
  }
}
