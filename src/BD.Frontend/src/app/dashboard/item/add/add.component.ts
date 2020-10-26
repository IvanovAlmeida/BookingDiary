import { Component, OnInit, ViewChildren, ElementRef, AfterViewInit } from '@angular/core';

import { ItemBaseComponent } from 'src/app/dashboard/item/item-base.component';
import { FormControlName, FormBuilder, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { ItemService } from 'src/app/core/services/item.service';
import { CustomValidators } from 'ngx-custom-validators';

import { CurrencyUtils } from 'src/app/core/utils/currency-utils';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-item-add',
  templateUrl: './add.component.html'
})
export class AddComponent extends ItemBaseComponent implements OnInit, AfterViewInit {
  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  constructor(private fb: FormBuilder, 
              private itemService: ItemService, 
              private spinner: NgxSpinnerService, 
              private toastr: ToastrService,
              private router: Router) { 
    super();
  }

  ngOnInit(): void {
    this.itemForm = this.fb.group({
      name: ['', [ Validators.required, Validators.minLength(2), Validators.maxLength(180) ]],
      price: ['', [ Validators.required, Validators.min(0.01), CustomValidators.number ]],
      quantity: ['', [ Validators.required, Validators.min(0.01), CustomValidators.number ]],
      description: ['',[ Validators.minLength(2), Validators.maxLength(1000) ]]
    });
  }

  ngAfterViewInit() : void {
    super.configurarValidacaoFormulario(this.formInputElements);
  }

  saveItem() : void {
    if(this.itemForm.dirty && this.itemForm.valid) {
      this.item = Object.assign({}, this.item, this.itemForm.value);

      //this.item.price = CurrencyUtils.StringParaDecimal(this.item.price);
      this.spinner.show();
      this.itemService.saveItem(this.item).subscribe(
        success => { this.processSuccess(success); },
        fail => { this.processFail(fail); }
      );
    }
  }

  processSuccess(response: any) {
    this.itemForm.reset();
    this.errors = [];

    this.spinner.hide();

    let toast = this.toastr.success('Item cadastrado com sucesso!', 'Sucesso!', { timeOut: 1500 });
    if(toast) {
      toast.onHidden.subscribe(() => {
        this.router.navigate(['/dashboard/itens']);
      });
    }
  }

  processFail(fail: any) { 
    this.spinner.hide();
    this.errors = fail.error.errors;
    this.toastr.error('Ocorreu um erro!', 'Opa :(');
  }
}
