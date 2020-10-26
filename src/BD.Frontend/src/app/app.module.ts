import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CustomFormsModule } from 'ngx-custom-validators';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule }    from '@angular/common/http';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from "ngx-spinner";
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { SidenavStore } from './dashboard/navigation/sidenav/sidenav.store';
import { ErrorInterceptor } from 'src/app/core/services/error-interceptor.service';
import { LoginComponent } from './login/login.component';

export const httpInterceptors = [
  { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
];

@NgModule({
  declarations: [
    AppComponent, LoginComponent
  ],
  imports: [
    CommonModule,
    AppRoutingModule,
    BrowserModule,
    NgbModule,
    NgxSpinnerModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ToastrModule.forRoot(), // ToastrModule added
    FontAwesomeModule,
    CustomFormsModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    SidenavStore,
    httpInterceptors
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
