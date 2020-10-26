import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './list/list.component';
import { RoleComponent } from './role.component';
import { AddComponent } from './add/add.component';
import { EditComponent } from './edit/edit.component';
import { RoleRoutingModule } from './role.route';
import { FaIconLibrary, FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faEdit, faPlug, faTrash } from '@fortawesome/free-solid-svg-icons';
import { RoleService } from 'src/app/core/services/role.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CustomFormsModule } from 'ngx-custom-validators';
import { RoleResolve } from 'src/app/core/resolvers/role.resolve';
import { PermissionsComponent } from './permissions/permissions.component';
import { PermissionService } from 'src/app/core/services/permission.service';
import { PermissionResolve } from 'src/app/core/resolvers/permission.resolve';
import { RouterGuard } from 'src/app/core/guards/router.guard';



@NgModule({
  declarations: [ListComponent, RoleComponent, AddComponent, EditComponent, PermissionsComponent],
  imports: [
    CommonModule,
    RoleRoutingModule,
    FontAwesomeModule,
    CustomFormsModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    RoleService,
    RoleResolve,
    PermissionService,
    PermissionResolve,
    RouterGuard
  ]
})
export class RoleModule { 
  constructor(library: FaIconLibrary) {
    library.addIcons(faTrash, faEdit, faPlug);
  }
}
