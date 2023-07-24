import { Allotment } from "./Allotment";
import { SocialMedia } from "./SocialMedia";
import { Speaker } from "./Speaker";

export interface Event {

  id : number ;

  local : string ;

  eventDate? : Date ;

  theme : string ;

  maximumGuests : number ;

  imageUrl : string ;

  phone : string ;

  email : string ;

  allotments : Allotment[];

  socialMedias : SocialMedia[];

  speakers : Speaker[];

  speakerEvents : Speaker[];

}
