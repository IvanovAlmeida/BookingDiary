import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { FormGroup, FormBuilder } from '@angular/forms';

import { Item, ItemSearch } from 'src/app/core/models/item';
import { ItemService } from 'src/app/core/services/item.service';
import { Router } from '@angular/router';
import { QueryStringUtils } from 'src/app/core/utils/query-string-utils';
import { ToastrService } from 'ngx-toastr';

import { BaseComponent } from 'src/app/core/base-components/base.component';

import { utilsBr } from 'js-brasil';
import { CurrencyUtils } from 'src/app/core/utils/currency-utils';

const MASKS = utilsBr.MASKS;

@Component({
  selector: 'app-item-list',
  templateUrl: './list.component.html'
})
export class ListComponent extends BaseComponent implements OnInit {

  public MASKS = MASKS;

  showSearchForm : boolean = false;
  items : Item[] = [];
  public searchForm: FormGroup;
  private item: Item;
  private itemSearch: ItemSearch;

  private queryString = new QueryStringUtils();

  constructor(private router: Router, 
              private itemService: ItemService, 
              private fb: FormBuilder, 
              private spinner: NgxSpinnerService,
              private toastr: ToastrService) { 
    super();
  }

  ngOnInit(): void {    
    let url : any = this.queryString.parseUrl(this.router.url);

    this.searchForm = this.fb.group({
      name: [url.query.name ?? ''],
      minPrice: [url.query.minPrice ?? ''],
      maxPrice: [url.query.maxPrice ?? ''],
      minQuantity: [url.query.minQuantity ?? ''],
      maxQuantity: [url.query.maxQuantity ?? ''],
      enabled: [url.query.enabled ?? 'true']
    });

    this.search();
  }

  toggleFormSearch() {
    this.showSearchForm = !this.showSearchForm;
  }

  async search() {
    this.spinner.show();
    
    this.itemSearch = Object.assign({}, this.itemSearch, this.searchForm.value);   

    this.itemSearch.minPrice = CurrencyUtils.StringParaDecimal(this.itemSearch.minPrice);
    this.itemSearch.maxPrice = CurrencyUtils.StringParaDecimal(this.itemSearch.maxPrice);
    this.itemService.listItems(this.itemSearch).subscribe(
      r => {
        this.items = r;
        this.spinner.hide();
      },
      err => {
        console.log(err);
        this.spinner.hide();
      }
    );    
  }

  async disableItem(id: number) {

    let confirm = await this.showConfirmBox('Atenção', 'Realmente deseja desativar este Item?');

    if(!confirm.isConfirmed) return;

    this.spinner.show();
    this.itemService.disableItem(id).subscribe(
      success => {
        this.search();
        this.toastr.success('Item desativado com sucesso!', 'Sucesso');
      },
      error => {
        this.toastr.error('Ocorreu um erro ao desativar o item!', 'Ops! :(');
        this.spinner.hide();
      }
    );
  }

  async enableItem(id: number) {
    let confirm = await this.showConfirmBox('Atenção', 'Realmente deseja reativar este Item?');

    if(!confirm.isConfirmed)
      return;

    this.spinner.show();
    this.itemService.enableItem(id).subscribe(
      success => {
        this.search();
        this.toastr.success('Item reativado com sucesso!', 'Sucesso');
      },
      error => {
        this.toastr.error('Ocorreu um erro ao reativar o item!', 'Ops! :(');
        this.spinner.hide();
      }
    );
  }
}