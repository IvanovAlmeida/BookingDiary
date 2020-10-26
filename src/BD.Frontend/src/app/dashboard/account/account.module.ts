import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomFormsModule } from 'ngx-custom-validators';
import { ReactiveFormsModule } from '@angular/forms';

import { faEdit, faPlug, faTrash } from '@fortawesome/free-solid-svg-icons';
import { FaIconLibrary, FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { AccountComponent } from './account.component';
import { AccountRoutingModule } from './account.routing';

@NgModule({
  declarations: [AccountComponent],
  imports: [
    CommonModule,
    AccountRoutingModule,
    FontAwesomeModule,
    CustomFormsModule,
    ReactiveFormsModule
  ]
})

export class AccountModule {
  constructor(library: FaIconLibrary) {
    library.addIcons(faTrash, faEdit, faPlug, faPlug);
  }
 }