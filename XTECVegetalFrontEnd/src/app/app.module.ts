
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';

import { MDBBootstrapModule } from 'angular-bootstrap-md';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { OrganizerComponent } from './organizer/organizer.component';
import { LobbyComponent } from './lobby/lobby.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SignupComponent,
    OrganizerComponent,
    LobbyComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MDBBootstrapModule.forRoot(),
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
   

    RouterModule.forRoot([
      { path: '', component: LoginComponent, pathMatch: 'full' },
      { path: 'signup', component: SignupComponent},
      { path: 'organizer', component: OrganizerComponent},
      { path: 'lobby', component: LobbyComponent}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
