import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MoneyPipe } from '../../pipes/money.pipe';

@NgModule({
  declarations: [
    MoneyPipe
  ],
  imports: [
    CommonModule
  ],
  exports: [
    MoneyPipe
  ]
})
export class PipesModule { }
