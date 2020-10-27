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

  public getReserve(id: number) : Observable<Reserve> {
    return this.http
                .get<Reserve>(this.UrlServiceV1 + `reserves/${id}`, super.ObterAuthHeaderJson())
                .pipe(map(super.extractData), catchError(super.serviceError));
  }

  public addReserve(reserve: Reserve) : Observable<Reserve> {
    return this.http.post(this.UrlServiceV1 + 'reserves', reserve, super.ObterAuthHeaderJson())
                    .pipe(map(super.extractData), catchError(super.serviceError));
  }

  public updateReserve(reserve: Reserve) : Observable<Reserve> {
    return this.http
              .put(this.UrlServiceV1 + `reserves/${reserve.id}`, reserve, super.ObterAuthHeaderJson())
              .pipe(map(super.extractData), catchError(super.serviceError));
  }

  public disableReserve(id: number) : Observable<Reserve> {
    return this.http
            .delete(this.UrlServiceV1 + `reserves/${id}`, super.ObterAuthHeaderJson())
            .pipe(map(super.extractData), catchError(super.serviceError));
  }

  public enableReserve(id: number) : Observable<Reserve> {
    return this.http
            .patch(this.UrlServiceV1 + `reserves/${id}`, {}, super.ObterAuthHeaderJson())
            .pipe(map(super.extractData), catchError(super.serviceError));
  }
}
