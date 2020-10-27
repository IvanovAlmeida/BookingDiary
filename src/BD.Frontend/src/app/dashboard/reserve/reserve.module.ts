import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FaIconLibrary, FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faTrash, faEdit, faPlug } from '@fortawesome/free-solid-svg-icons';
import { CustomFormsModule } from 'ngx-custom-validators';
import { NgSelectModule } from '@ng-select/ng-select';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ReserveService } from 'src/app/core/services/reserve.service';

import { ReserveRoutingModule } from './reserve.routing';
import { ReserveComponent } from './reserve.component';
import { ListComponent } from './list/list.component';
import { AddComponent } from './add/add.component';
import { EditComponent } from './edit/edit.component';
import { RouterGuard } from 'src/app/core/guards/router.guard';
import { TextMaskModule } from 'angular2-text-mask';
import { NgBrazil } from 'ng-brazil';
import { PipesModule } from 'src/app/core/modules/pipes/pipes.module';
import { ReserveResolve } from 'src/app/core/resolvers/reserve.resolve';

@NgModule({
  declarations: [ReserveComponent, ListComponent, AddComponent, EditComponent],
  imports: [
    CommonModule,
    ReserveRoutingModule,
    FontAwesomeModule,
    CustomFormsModule,
    FormsModule,
    NgSelectModule,
    ReactiveFormsModule,
    TextMaskModule,
    NgBrazil,
    PipesModule
  ],
  providers: [
    ReserveService,
    RouterGuard,
    ReserveResolve
  ]
})
export class ReserveModule { 
  constructor(library: FaIconLibrary) {
    library.addIcons(faTrash, faEdit, faPlug);
  }
}
