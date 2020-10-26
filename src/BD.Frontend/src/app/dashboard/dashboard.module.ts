import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboard.component';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxSpinnerModule } from "ngx-spinner";
import { FontAwesomeModule, FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { fas } from '@fortawesome/free-solid-svg-icons';
import { far } from '@fortawesome/free-regular-svg-icons';

import { DashboardRoutingModule } from './dashboard.routing';
import { NavigationModule } from './navigation/navigation.module';

import { HomeComponent } from './home/home.component';
import { DashboardGuard } from '../core/guards/dashboard.guard';


@NgModule({
  declarations: [DashboardComponent, HomeComponent],
  imports: [
    CommonModule,
    NgbModule,
    NgxSpinnerModule,
    NavigationModule,
    DashboardRoutingModule,
    FontAwesomeModule
  ],
  providers: [
    DashboardGuard
  ]
})
export class DashboardModule { 
  constructor(library: FaIconLibrary) {
    library.addIconPacks(fas, far);
  }
}
