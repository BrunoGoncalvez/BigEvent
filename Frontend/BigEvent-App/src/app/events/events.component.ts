import { Event } from '../models/Event';

import { Component, OnInit, AfterContentChecked, TemplateRef } from '@angular/core';
import { EventService } from '../services/event.service';

import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';

declare function initStyle() : any;


@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss']
})

export class EventsComponent implements OnInit, AfterContentChecked {

  // Constants Modal
  public modalRef?: BsModalRef;


  private _searchEvent : string = "";
  public events : Event[] = [];
  public filteredEvents : Event[] = [];
  public showImage: boolean = false;

  // Constructor
  constructor(private eventService : EventService, private modalService: BsModalService,private toastr: ToastrService) { }

  //#region Search Methods

  public get searchEvent() : string{
    return this._searchEvent;
  }

  public set searchEvent(value : string){
    this._searchEvent = value;
    this.filteredEvents = this._searchEvent ? this.filterEvents(this._searchEvent) : this.events;
  }

  //#endregion


  //#region Cyrcle Life Methods
  public ngOnInit(): void {
    this.getEvents();
  }

  public ngAfterContentChecked(): void {
    initStyle();
  }
  //#endregion


  public getEvents() : void{

    this.eventService.getEvents().subscribe(
      (evs : Event[]) => {
        this.events = evs;
        this.filteredEvents = evs;
      },
      error => { console.log("Error: " + error) }
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


  //#region Modal Functions

  openModal(template: TemplateRef<any>) : void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('Hello world!', 'Toastr fun!');
  }

  decline(): void {
    this.modalRef?.hide();
  }

  //#endregion

}
