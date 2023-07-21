import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})

export class EventService {

  constructor(private http: HttpClient) { }

  private apiURL: string = environment.apiURL;

  getEvents(){
    return this.http.get(this.apiURL + "/events");
  }

}
