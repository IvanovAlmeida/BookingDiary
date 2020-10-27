import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FaIconLibrary, FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faTrash, faEdit, faPlug, faPlus } from '@fortawesome/free-solid-svg-icons';

import { UserComponent } from './user.component';
import { ListComponent } from './list/list.component';
import { AddComponent } from './add/add.component';
import { EditComponent } from './edit/edit.component';
import { UserRoutingModule } from './user.routing';
import { UserService } from 'src/app/core/services/user.service';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CustomFormsModule } from 'ngx-custom-validators';
import { UserResolve } from 'src/app/core/resolvers/user.resolve';
import { NgSelectModule } from '@ng-select/ng-select';
import { RolesResolve } from 'src/app/core/resolvers/roles.resolve';
import { RouterGuard } from 'src/app/core/guards/router.guard';
import { ChangePasswordComponent } from './change-password/change-password.component';

@NgModule({
  declarations: [UserComponent, ListComponent, AddComponent, EditComponent, ChangePasswordComponent],
  imports: [
    CommonModule, 
    UserRoutingModule,
    FontAwesomeModule,
    FormsModule,
    CustomFormsModule,
    ReactiveFormsModule,
    NgSelectModule
  ],
  providers: [
    UserService,
    UserResolve,
    RolesResolve,
    RouterGuard
  ]
})
export class UserModule { 
  constructor(library: FaIconLibrary) {
    library.addIcons(faTrash, faEdit, faPlug, faPlus);
  }
}
