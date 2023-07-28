// Libs Angular
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// Routes
import { AppRoutingModule } from './app-routing.module';

// NGX
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { ModalModule } from 'ngx-bootstrap/modal';
import { NgxSpinnerModule } from 'ngx-spinner';
import { ToastrModule } from 'ngx-toastr';
import { TooltipModule } from 'ngx-bootstrap/tooltip';

// Components
import { AppComponent } from './app.component';
import { ContactsComponent } from './components/contacts/contacts.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { DetailEventComponent } from './components/events/detail-event/detail-event.component';
import { EventsComponent } from './components/events/events.component';
import { HomeComponent } from './components/home/home.component';
import { ProfileComponent } from './components/profile/profile.component';
import { NavbarComponent } from './shared/components/navbar/navbar.component';
import { NotFoundPageComponent } from './components/not-found-page/not-found-page.component';
import { SpeakersComponent } from './components/speakers/speakers.component';
import { TitlePageComponent } from './shared/components/titlePage/titlePage.component';

// Services and Pipes
import { DateTimeFormatPipe } from './helpers/pipes/DateTimeFormat.pipe';
import { EventService } from './services/event.service';
import { ListEventsComponent } from './components/events/list-events/list-events.component';

@NgModule({
  declarations: [
    AppComponent,
    ContactsComponent,
    DashboardComponent,
    DetailEventComponent,
    DateTimeFormatPipe,
    EventsComponent,
    HomeComponent,
    NavbarComponent,
    NotFoundPageComponent,
    ProfileComponent,
    SpeakersComponent,
    TitlePageComponent,
    ListEventsComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    CollapseModule.forRoot(),
    BsDropdownModule.forRoot(),
    TooltipModule.forRoot(),
    ToastrModule.forRoot({
      timeOut: 5000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar: true
    }),
    ModalModule.forRoot(),
    NgxSpinnerModule
  ],
  providers: [
    EventService
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
