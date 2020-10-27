import { AfterViewInit, Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { FormBuilder, FormControl, FormControlName, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { utilsBr } from 'js-brasil';
import * as moment from 'moment';
import 'moment/locale/pt-br';
import { CustomValidators } from 'ngx-custom-validators';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Reserve } from 'src/app/core/models/reserve';
import { ItemService } from 'src/app/core/services/item.service';
import { ReserveService } from 'src/app/core/services/reserve.service';
import { CurrencyUtils } from 'src/app/core/utils/currency-utils';
import { ReserveBaseComponent } from '../reserve-base.component';

const MASKS = utilsBr.MASKS;

@Component({
  selector: 'app-reserve-edit',
  templateUrl: './edit.component.html'
})
export class EditComponent extends ReserveBaseComponent implements OnInit, AfterViewInit {
  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  public MASKS = MASKS;
  public reserve: Reserve;
  
  constructor(
              private fb: FormBuilder, 
              private itemService: ItemService, 
              private reserveService: ReserveService,
              private spinner: NgxSpinnerService, 
              private toastr: ToastrService,
              private route: ActivatedRoute, 
              private router: Router
  ) { 
    super();
    this.reserve = this.route.snapshot.data['reserve'];
  }

  ngOnInit(): void {

    let date = moment().add(3, 'day').set({'hour': 0, 'minute': 0, 'second': 0});   
    let dateReserve = moment(this.reserve.dateStart);

    if(date.isAfter(dateReserve))
      date = dateReserve;

    let dateStart = new FormControl('', [ Validators.required, CustomValidators.date, CustomValidators.minDate(date) ]);
    let dateEnd = new FormControl('', [ Validators.required, CustomValidators.date, CustomValidators.minDate(dateStart) ]);
    let price = new FormControl('', [ Validators.required, Validators.min(10) ]);
    let entry = new FormControl('', [ Validators.required, Validators.min(100), Validators.max(price.value) ]);

    this.reserveForm = this.fb.group({
      dateStart: dateStart,
      dateEnd: dateEnd,
      price: price,
      entry: entry,
      description: ['']
    });

    this.reserveForm.patchValue({
      dateStart: this.reserve.dateStart,
      dateEnd: this.reserve.dateEnd,
      price: CurrencyUtils.DecimalParaString(this.reserve.price),
      entry: CurrencyUtils.DecimalParaString(this.reserve.entry),
      description: this.reserve.description,
    });
    
    this.spinner.hide();
  }

  ngAfterViewInit(): void {
    super.configurarValidacaoFormularioBase(this.formInputElements, this.reserveForm);
  }

  editReserve() {
    if(this.reserveForm.dirty && this.reserveForm.valid) {
      this.reserve = Object.assign({}, this.reserve, this.reserveForm.value);
      
      this.reserve.price = CurrencyUtils.StringParaDecimal(this.reserve.price);
      this.reserve.entry = CurrencyUtils.StringParaDecimal(this.reserve.entry);

      this.spinner.show();
      this.reserveService.updateReserve(this.reserve).subscribe(
        success => { this.proccessSuccess(success); },
        error => { this.proccessError(error); }
      );
    }
  }

  proccessSuccess(response: any) {
    this.reserveForm.reset();
    this.errors = [];

    this.spinner.hide();

    let toast = this.toastr.success('Reserva alterada com sucesso!', 'Sucesso!', { timeOut: 1500 });
    if(toast) {
      toast.onHidden.subscribe(() => {
        this.router.navigate(['/dashboard/reservas']);
      });
    }
  }

  proccessError(fail: any) {
    this.spinner.hide();

    this.errors = fail.error.errors;
    this.toastr.error('Ocorreu um erro!', 'Opa :(');
  }
}
