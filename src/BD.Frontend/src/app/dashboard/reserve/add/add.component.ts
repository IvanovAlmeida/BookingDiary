import { AfterViewInit } from '@angular/core';
import { Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { FormControl } from '@angular/forms';
import { FormBuilder, FormControlName, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CustomValidators } from 'ngx-custom-validators';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { ItemService } from 'src/app/core/services/item.service';
import { ReserveService } from 'src/app/core/services/reserve.service';
import { ReserveBaseComponent } from '../reserve-base.component';
import { utilsBr } from 'js-brasil';

import * as moment from 'moment';
import 'moment/locale/pt-br';

const MASKS = utilsBr.MASKS;

@Component({
  selector: 'app-reserve-add',
  templateUrl: './add.component.html'
})
export class AddComponent extends ReserveBaseComponent implements OnInit, AfterViewInit {
  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  public MASKS = MASKS;

  constructor(private fb: FormBuilder, 
              private itemService: ItemService, 
              private reserveService: ReserveService,
              private spinner: NgxSpinnerService, 
              private toastr: ToastrService,
              private router: Router) {
    super();
   }

  ngOnInit(): void {
    let date = moment().add(3, 'day').set({'hour': 0, 'minute': 0, 'second': 0});
    
    let dateStart = new FormControl('', [
      Validators.required, CustomValidators.date, CustomValidators.minDate(date)
    ]);

    let dateEnd = new FormControl('', [
      Validators.required, CustomValidators.date, CustomValidators.minDate(dateStart)
    ]);

    let price = new FormControl('', [
      Validators.required, Validators.min(10)
    ]);

    let entry = new FormControl('', [
      Validators.required, Validators.min(100), Validators.max(price.value)
    ]);

    this.reserveForm = this.fb.group({
      dateStart: dateStart,
      dateEnd: dateEnd,
      price: price,
      entry: entry,
      description: ['']
    });
  }

  saveReserve() {
    if(this.reserveForm.dirty && this.reserveForm.valid) {
      this.reserve = Object.assign({}, this.reserve, this.reserveForm.value);

      console.log(this.reserve);

      this.reserve.price = parseFloat(this.reserve.price.toString().replace('R$', '').replace(',', '.'));
      this.reserve.entry = parseFloat(this.reserve.entry.toString().replace('R$', '').replace(',', '.'));

      console.log(this.reserve);
      
      this.spinner.show();
      this.reserveService.addReserve(this.reserve).subscribe(
        success => { this.processSuccess(success); },
        err => { this.processFail(err); }
      );
    }
  }

  processSuccess(response: any) {
    this.reserveForm.reset();
    this.errors = [];

    this.spinner.hide();

    let toast = this.toastr.success('Reserva cadastrado com sucesso!', 'Sucesso!', { timeOut: 1500 });
    if(toast) {
      toast.onHidden.subscribe(() => {
        this.router.navigate(['/dashboard/reservas']);
      });
    }
  }

  processFail(fail: any) { 
    this.spinner.hide();
    this.errors = fail.error.errors;
    this.toastr.error('Ocorreu um erro!', 'Opa :(');
  }

  ngAfterViewInit(): void {
    super.configurarValidacaoFormularioBase(this.formInputElements, this.reserveForm);
  }
}
