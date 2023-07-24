import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { Event } from '../models/Event';
import { environment } from 'src/environments/environment';

@Injectable(
  // { providedIn: 'root' }
)

export class EventService {

  constructor(private http: HttpClient) { }

  private API_URL: string = environment.BASE_URL_API;

  getEvents(): Observable<Event[]>{
    return this.http.get<Event[]>(this.API_URL + "/events");
  }

  getEventById(id : number): Observable<Event>{
    return this.http.get<Event>(`${this.API_URL}/events/${id}`);
  }

  getEventsByTheme(theme : string): Observable<Event[]>{
    return this.http.get<Event[]>(`${this.API_URL}/events/${theme}`);
  }

}
