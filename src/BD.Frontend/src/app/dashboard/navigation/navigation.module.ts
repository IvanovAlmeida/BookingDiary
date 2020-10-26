import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { NavbarComponent } from './navbar/navbar.component';
import { SidenavComponent } from './sidenav/sidenav.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { AccessDeniedComponent } from './access-denied/access-denied.component';

@NgModule({
  declarations: [NavbarComponent, SidenavComponent, AccessDeniedComponent],
  imports: [
    CommonModule,
    RouterModule,
    NgbModule,
    FontAwesomeModule
  ],
  exports: [
    NavbarComponent, SidenavComponent
  ]
})
export class NavigationModule { }
