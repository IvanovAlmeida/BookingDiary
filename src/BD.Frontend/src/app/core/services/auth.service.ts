import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Auth } from '../models/auth';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends BaseService {

  constructor(private http: HttpClient) {
    super();
  }

  login(auth: Auth): Observable<Auth> {
    return this.http.post(this.UrlServiceV1 + 'auth/login', auth)
      .pipe(map(super.extractData), catchError(super.serviceError));
  }
}
