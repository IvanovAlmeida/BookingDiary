import { Component, OnInit } from '@angular/core';
import { Reserve, ReserveSearch } from 'src/app/core/models/reserve';
import { ReserveService } from 'src/app/core/services/reserve.service';

import { FormGroup, FormBuilder } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { Router } from '@angular/router';
import { QueryStringUtils } from 'src/app/core/utils/query-string-utils';

@Component({
  selector: 'app-reserve-list',
  templateUrl: './list.component.html'
})
export class ListComponent implements OnInit {
  showSearchForm : boolean = true;
  reserves : Reserve[] = [];
  
  status = [
    { value: true, label: 'Ativo', selected: true},
    { value: false, label: 'Desativado' },
    { value: '', label: 'Ativo & Desativado' }
  ];

  public searchForm: FormGroup;
  private reserve: Reserve;
  private reserveSearch: ReserveSearch;
  private queryString: QueryStringUtils = new QueryStringUtils();


  constructor( private router: Router, private reserveService: ReserveService, private fb: FormBuilder, private spinner: NgxSpinnerService) { }

  ngOnInit(): void {
    
    let url : any = this.queryString.parseUrl(this.router.url);

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

}
