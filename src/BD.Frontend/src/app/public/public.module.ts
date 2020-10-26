import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PublicComponent } from './public.component';
import { FormsModule } from '@angular/forms';
import { NgxSpinnerModule } from 'ngx-spinner';

@NgModule({
  declarations: [PublicComponent],
  imports: [
    CommonModule,
    NgModule,
    NgxSpinnerModule,
    FormsModule
  ]
})
export class PublicModule { }
