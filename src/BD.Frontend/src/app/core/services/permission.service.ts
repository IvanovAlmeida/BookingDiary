import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Permission } from '../models/permission';
import { BaseService } from './base.service';

@Injectable({
    providedIn: 'root'
})
export class PermissionService extends BaseService {
    constructor(private http: HttpClient) {
        super();
    }

    public listPermissions() : Observable<Permission> {
        return this.http.get<Permission>(
                this.UrlServiceV1 + `permissions/`,  
                super.ObterAuthHeaderJson()
            ).pipe(catchError(super.serviceError));
    }
}