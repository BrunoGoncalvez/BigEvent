import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

// Components
import { ContactsComponent } from './components/contacts/contacts.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { DetailEventComponent } from './components/events/detail-event/detail-event.component';
import { EventsComponent } from './components/events/events.component';
import { HomeComponent } from './components/home/home.component';
import { ListEventsComponent } from './components/events/list-events/list-events.component';
import { LoginComponent } from './components/user/login/login.component';
import { NotFoundPageComponent } from './components/not-found-page/not-found-page.component';
import { ProfileComponent } from './components/user/profile/profile.component';
import { RegistrationComponent } from './components/user/registration/registration.component';
import { SpeakersComponent } from './components/speakers/speakers.component';
import { UserComponent } from './components/user/user.component';


const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },

  { path: 'user', component: UserComponent, children: [
    { path: 'login', component: LoginComponent },
    { path: 'registration', component: RegistrationComponent }
  ]},

  { path: 'user/profile', component: ProfileComponent },
  { path: 'events', component: EventsComponent, children: [
    { path: 'list', component: ListEventsComponent },
    { path: 'details', component: DetailEventComponent },
    { path: 'details/:id', component: DetailEventComponent }
  ]},

  { path: 'events', redirectTo: '/events/list'},
  { path: 'home', component: HomeComponent },
  { path: 'speakers', component: SpeakersComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'contacts', component: ContactsComponent },
  { path: '**', component: NotFoundPageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
