import { Event } from "./Event";

export interface Allotment {

  id : number

  name : string

  price : number

  limitGuests : number

  initialDate? : Date

  finishDate? : Date

  // Foreign Key
  eventId : number
  event : Event

}
