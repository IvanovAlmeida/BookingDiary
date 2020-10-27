import { Component, OnInit } from '@angular/core';
import { Reserve, ReserveSearch } from 'src/app/core/models/reserve';
import { ReserveService } from 'src/app/core/services/reserve.service';

import { FormGroup, FormBuilder } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { Router } from '@angular/router';
import { QueryStringUtils } from 'src/app/core/utils/query-string-utils';

import { utilsBr } from 'js-brasil';
import { CurrencyUtils } from 'src/app/core/utils/currency-utils';
import { BaseComponent } from 'src/app/core/base-components/base.component';
import { ToastrService } from 'ngx-toastr';
const MASKS = utilsBr.MASKS;

@Component({
  selector: 'app-reserve-list',
  templateUrl: './list.component.html'
})
export class ListComponent extends BaseComponent implements OnInit {

  public MASKS = MASKS;

  showSearchForm: boolean = true;
  reserves: Reserve[] = [];

  status = [
    { value: true, label: 'Ativo', selected: true },
    { value: false, label: 'Desativado' },
    { value: '', label: 'Ativo & Desativado' }
  ];

  public searchForm: FormGroup;
  private reserve: Reserve;
  private reserveSearch: ReserveSearch;
  private queryString: QueryStringUtils = new QueryStringUtils();

  constructor(private router: Router, private reserveService: ReserveService, private fb: FormBuilder, private spinner: NgxSpinnerService,
    private toastr: ToastrService) {
    super();
  }

  ngOnInit(): void {

    let url: any = this.queryString.parseUrl(this.router.url);

    this.searchForm = this.fb.group({
      minPrice: [url.query.minPrice ?? ''],
      maxPrice: [url.query.maxPrice ?? ''],
      minEntry: [url.query.minEntry ?? ''],
      maxEntry: [url.query.maxEntry ?? ''],
      minDateStart: [url.query.minDateStart ?? ''],
      maxDateStart: [url.query.maxDateStart ?? ''],
      enabled: [url.query.enabled ?? true]
    });

    this.search();
  }

  toggleFormSearch() {
    this.showSearchForm = !this.showSearchForm;
  }

  async search() {
    this.spinner.show();

    this.reserveSearch = Object.assign({}, this.reserveSearch, this.searchForm.value);
    
    this.reserveSearch.minPrice = CurrencyUtils.StringParaDecimal(this.reserveSearch.minPrice);
    this.reserveSearch.maxPrice = CurrencyUtils.StringParaDecimal(this.reserveSearch.maxPrice);
    this.reserveSearch.minEntry = CurrencyUtils.StringParaDecimal(this.reserveSearch.minEntry);
    this.reserveSearch.maxEntry = CurrencyUtils.StringParaDecimal(this.reserveSearch.maxEntry);

    this.reserveService.listReserves(this.reserveSearch).subscribe(
      r => {
        this.reserves = r;
        this.spinner.hide();
      },
      err => {
        console.log(err);
        this.spinner.hide();
      }
    );

  }

  async disableReserve(id: number) {
    let confirm = await this.showConfirmBox('Atenção', 'Realmente deseja desativar essa Reserva?');

    if (!confirm.isConfirmed) return;

    this.spinner.show();
    this.reserveService.disableReserve(id).subscribe(
      s => {
        this.search();
        this.toastr.success('Reserva desativada com sucesso!', 'Sucesso');
      },
      e => {
        this.toastr.error('Ocorreu um erro ao desativar a Reserva!', 'Ops! :(');
        this.spinner.hide();
      }
    );
  }

  async enableReserve(id: number) {
    let confirm = await this.showConfirmBox('Atenção', 'Realmente deseja reativar essa Reserva?');

    if(!confirm.isConfirmed)
      return;

    this.spinner.show();
    this.reserveService.enableReserve(id).subscribe(
      s => {
        this.search();
        this.toastr.success('Reserva reativada com sucesso!', 'Sucesso');
      },
      e => {
        this.toastr.error('Ocorreu um erro ao reativar a Reserva!', 'Ops! :(');
        this.spinner.hide();
      }
    );
  }

}
