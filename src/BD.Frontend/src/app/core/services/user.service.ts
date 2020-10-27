import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

import { BaseService } from './base.service';
import { User } from '../models/user';
import { Role } from '../models/role';

@Injectable({
  providedIn: 'root'
})
export class UserService extends BaseService {

  constructor(private http: HttpClient) { 
    super();
  }

  public searchUsers(user: User) : Observable<User[]> {
    let params = new HttpParams({
      fromString: this.QueryString.stringfy(user)
    });

    return this.http
      .get<User[]>(this.UrlServiceV1 + 'users', {
        params: params,
        headers: super.ObterAuthHeaderJson().headers
      })
      .pipe(catchError(super.serviceError));
  }

  public getUser(id: number) : Observable<User> {
    return this.http
      .get<User>(this.UrlServiceV1 + `users/${id}`, super.ObterAuthHeaderJson())
      .pipe(map(super.extractData), catchError(super.serviceError));
  }

  public saveUser(user: User) : Observable<User> {
    return this.http.post<User>(this.UrlServiceV1 + 'users', user, super.ObterAuthHeaderJson());
  }

  public updateUser(user: User) : Observable<User> {
    return this.http
      .put(this.UrlServiceV1 + `users/${user.id}`, user, super.ObterAuthHeaderJson())
      .pipe(map(super.extractData), catchError(super.serviceError));
  }

  public updateRoles(id: number, roles: Role[]) {
    return this.http
        .put(this.UrlServiceV1 + `users/update-roles/${id}`, roles, super.ObterAuthHeaderJson())          
        .pipe(map(super.extractData), catchError(super.serviceError));
  }

  public disableUser(id: number) : Observable<User> {
    return this.http
      .delete(this.UrlServiceV1 + `users/${id}`, super.ObterAuthHeaderJson())
      .pipe(map(super.extractData), catchError(super.serviceError));
  }

  public enableUser(id: number) : Observable<User> {
    return this.http
      .patch(this.UrlServiceV1 + `users/${id}`, {}, super.ObterAuthHeaderJson())
      .pipe(map(super.extractData), catchError(super.serviceError));
  }

  public changeUserPassword(id: number, password: string) : Observable<any> {
    return this.http
      .put(this.UrlServiceV1 + `users/change-user-password/${id}`, {password: password}, super.ObterAuthHeaderJson())
      .pipe(map(super.extractData), catchError(super.serviceError));
  }
}
