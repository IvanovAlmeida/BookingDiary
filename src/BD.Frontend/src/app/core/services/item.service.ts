import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Item, ItemSearch } from '../models/item';
import { catchError, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ItemService extends BaseService {

  constructor(private http: HttpClient) {
    super();
  }

  public listItems(item: ItemSearch) : Observable<Item[]> {
    let params = new HttpParams({ 
      fromString: this.QueryString.stringfy(item)
    });
    return this.http
        .get<Item[]>(this.UrlServiceV1 + 'items', {
          params: params,
          headers: super.ObterAuthHeaderJson().headers
        })
        .pipe(catchError(super.serviceError));
  }

  public getItem(id : number) : Observable<Item> {
    return this.http
        .get<Item>(this.UrlServiceV1 + `items/${id}`, super.ObterAuthHeaderJson())
        .pipe(catchError(super.serviceError));
  }

  public saveItem(item: Item) : Observable<Item> {
    return this.http.post<Item>(this.UrlServiceV1 + 'items', item, super.ObterAuthHeaderJson());
  }

  public updateItem(item: Item) : Observable<Item> {
    return this.http
            .put(this.UrlServiceV1 + `items/${item.id}`, item, super.ObterAuthHeaderJson())
            .pipe(map(super.extractData), catchError(super.serviceError));
  }

  public disableItem(id: number) : Observable<Item> {
    return this.http
            .delete(this.UrlServiceV1 + `items/${id}`, super.ObterAuthHeaderJson())
            .pipe(map(super.extractData), catchError(super.serviceError));
  }

  public enableItem(id: number) : Observable<Item> {
    return this.http
            .patch(this.UrlServiceV1 + `items/${id}`, {}, super.ObterAuthHeaderJson())
            .pipe(map(super.extractData), catchError(super.serviceError));
  }
}
