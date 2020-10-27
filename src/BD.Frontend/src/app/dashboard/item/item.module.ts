import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ItemComponent } from './item.component';

import { CustomFormsModule } from 'ngx-custom-validators';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ItemRoutingModule } from './item.routing';
import { ListComponent } from './list/list.component';
import { EditComponent } from './edit/edit.component';
import { AddComponent } from './add/add.component';
import { FaIconLibrary, FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faTrash, faEdit, faPlug } from '@fortawesome/free-solid-svg-icons';
import { ItemService } from 'src/app/core/services/item.service';
import { ItemResolve } from 'src/app/core/resolvers/item.resolve';
import { RouterGuard } from 'src/app/core/guards/router.guard';
import { NgBrazil } from 'ng-brazil';
import { TextMaskModule } from 'angular2-text-mask';
import { PipesModule } from 'src/app/core/modules/pipes/pipes.module';

@NgModule({
  declarations: [ItemComponent, ListComponent, EditComponent, AddComponent],
  imports: [
    CommonModule,
    ItemRoutingModule,
    FontAwesomeModule,
    CustomFormsModule,
    FormsModule,
    ReactiveFormsModule,
    NgBrazil,
    TextMaskModule,
    PipesModule
  ],
  providers: [
    ItemService,
    ItemResolve,
    RouterGuard
  ]
})
export class ItemModule { 
  constructor(library: FaIconLibrary) {
    library.addIcons(faTrash, faEdit, faPlug);
  }
}
