import { Component, OnInit, AfterContentChecked, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { EventService } from 'src/app/services/event.service';

import { Event } from '../../../models/Event';

declare function initStyle() : any;

@Component({
  selector: 'app-list-events',
  templateUrl: './list-events.component.html',
  styleUrls: ['./list-events.component.scss']
})
export class ListEventsComponent implements OnInit, AfterContentChecked {

  // Constants Modal
  public modalRef?: BsModalRef;


  private _searchEvent : string = "";
  public events : Event[] = [];
  public filteredEvents : Event[] = [];
  public showImage: boolean = false;

  // Constructor
  constructor(
    private eventService : EventService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService) { }

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
    this.spinner.show();
    this.getEvents();
  }

  public ngAfterContentChecked(): void {
    initStyle();
  }
  //#endregion


  public getEvents() : void{

    this.eventService.getEvents().subscribe({
      next: (evs: Event[]) => {
        this.events = evs;
        this.filteredEvents = this.events;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Error load Events', 'Error!');
        console.log(error)
      },
      complete: () => { this.spinner.hide(); }
    });
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
