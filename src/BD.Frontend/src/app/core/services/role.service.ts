import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

import { BaseService } from './base.service';
import { Role } from '../models/role';
import { Permission } from '../models/permission';
import { AuthClaim } from '../models/auth';

@Injectable({
    providedIn: 'root'
})
export class RoleService extends BaseService {
    constructor(private http: HttpClient) {
        super();
    }

    public getRole(id: number) : Observable<Role> {
        return this.http.get<Role>(
                this.UrlServiceV1 + `roles/${id}`,  
                super.ObterAuthHeaderJson()
            ).pipe(map(super.extractData), catchError(super.serviceError));
    }

    public searchRoles(role: Role): Observable<Role[]> {
        let params = new HttpParams({
            fromString: this.QueryString.stringfy(role)
        });

        return this.http.get<Role[]>(this.UrlServiceV1 + 'roles', {
            params: params,
            headers: super.ObterAuthHeaderJson().headers
        })
            .pipe(catchError(super.serviceError));
    }

    public addRole(role: Role): Observable<Role> {
        return this.http.post<Role>(this.UrlServiceV1 + 'roles', role, super.ObterAuthHeaderJson());
    }

    public updateRole(role: Role): Observable<Role> {
        return this.http
            .put(this.UrlServiceV1 + `roles/${role.id}`, role, super.ObterAuthHeaderJson())
            .pipe(map(super.extractData), catchError(super.serviceError));
    }

    public disableRole(id: number): Observable<Role> {
        return this.http
            .delete(this.UrlServiceV1 + `roles/${id}`, super.ObterAuthHeaderJson())
            .pipe(map(super.extractData), catchError(super.serviceError));
    }

    public enableRole(id: number): Observable<Role> {
        return this.http
            .patch(this.UrlServiceV1 + `roles/${id}`, {}, super.ObterAuthHeaderJson())
            .pipe(map(super.extractData), catchError(super.serviceError));
    }

    public searchPermissions(permission: Permission): Observable<Permission[]> {
        let params = new HttpParams({
            fromString: this.QueryString.stringfy(permission)
        });

        return this.http.get<Permission[]>(this.UrlServiceV1 + 'permissions', {
            params: params,
            headers: super.ObterAuthHeaderJson().headers
        })
            .pipe(catchError(super.serviceError));
    }

    public addClaimToRole(id: number, claim: AuthClaim) : Observable<AuthClaim> {        
        return this.http.post<AuthClaim>(this.UrlServiceV1 + `roles/add-claim/${id}`, claim, super.ObterAuthHeaderJson());
    }

    public removeClaimToRole(id: number, claim: AuthClaim) : Observable<AuthClaim> {    
        let options = {
            headers: super.ObterAuthHeaderJson().headers,
            body: claim
        };
        
        return this.http.delete<AuthClaim>(this.UrlServiceV1 + `roles/remove-claim/${id}`, options);
    }
}