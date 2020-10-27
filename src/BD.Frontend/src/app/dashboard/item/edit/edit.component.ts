import { Component, OnInit, ElementRef, ViewChildren, AfterViewInit } from '@angular/core';
import { FormControlName, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';

import { Item } from 'src/app/core/models/item';
import { ItemBaseComponent } from '../item-base.component';
import { ToastrService } from 'ngx-toastr';
import { ItemService } from 'src/app/core/services/item.service';
import { CustomValidators } from 'ngx-custom-validators';

import { utilsBr } from 'js-brasil';
import { CurrencyUtils } from 'src/app/core/utils/currency-utils';

const MASKS = utilsBr.MASKS;

@Component({
  selector: 'app-item-edit',
  templateUrl: './edit.component.html'
})
export class EditComponent extends ItemBaseComponent implements OnInit, AfterViewInit {
  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  public MASKS = MASKS;
  public item: Item;

  constructor(private fb: FormBuilder, 
              private route: ActivatedRoute, 
              private router: Router,
              private itemService: ItemService,
              private spinner: NgxSpinnerService,
              private toastr: ToastrService) { 
    super();

    this.item = this.route.snapshot.data['item'].data;
  }

  ngOnInit(): void {
    this.itemForm = this.fb.group({
      name: ['', [ Validators.required, Validators.minLength(2), Validators.maxLength(180) ]],
      price: ['', [ Validators.required, Validators.min(0.01) ]],
      quantity: ['', [ Validators.required, Validators.min(0.01), CustomValidators.number ]],
      description: ['',[ Validators.minLength(2), Validators.maxLength(1000) ]]
    });

    this.itemForm.patchValue({
      id: this.item.id,
      name: this.item.name,
      price: CurrencyUtils.DecimalParaString(this.item.price),
      quantity: this.item.quantity,
      description: this.item.description
    });

    this.spinner.hide();
  }

  ngAfterViewInit(): void {
    super.configurarValidacaoFormulario(this.formInputElements);
  }

  saveItem() {
    if(this.itemForm.dirty && this.itemForm.valid) {
      this.item = Object.assign({}, this.item, this.itemForm.value);
      this.item.price = CurrencyUtils.StringParaDecimal(this.item.price);

      this.spinner.show();
      this.itemService.updateItem(this.item).subscribe(
        success => { this.proccessSuccess(success); },
        error => { this.proccessError(error); }
      );
    }
  }

  proccessSuccess(response: any) {
    this.itemForm.reset();
    this.errors = [];

    this.spinner.hide();

    let toast = this.toastr.success('Item editado com sucesso!', 'Sucesso!', { timeOut: 1500 });
    if(toast) {
      toast.onHidden.subscribe(() => {
        this.router.navigate(['/dashboard/itens']);
      });
    }
  }

  proccessError(fail: any) {
    this.spinner.hide();

    this.errors = fail.error.errors;
    this.toastr.error('Ocorreu um erro!', 'Opa :(');
  }
}
