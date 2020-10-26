import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { ReserveSearch, Reserve } from '../models/reserve';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ReserveService extends BaseService {

  constructor(private http: HttpClient) {
    super();
  }
  public listReserves(reserve: ReserveSearch) : Observable<Reserve[]> {
    let params = new HttpParams({
      fromString: this.QueryString.stringfy(reserve)
    });
    
    return this.http.get<Reserve[]>(this.UrlServiceV1 + 'reserves', {
      params: params,
      headers: super.ObterAuthHeaderJson().headers
    });
  }

  public addReserve(reserve: Reserve) : Observable<Reserve> {
    return this.http.post(this.UrlServiceV1 + 'reserves', reserve, super.ObterAuthHeaderJson())
                    .pipe(map(super.extractData), catchError(super.serviceError));
  }
}
