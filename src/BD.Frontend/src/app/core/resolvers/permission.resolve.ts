import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Permission } from '../models/permission';
import { PermissionService } from '../services/permission.service';

@Injectable()
export class PermissionResolve implements Resolve<Permission> {
    constructor(private permissionService: PermissionService, private spinner: NgxSpinnerService) {}

    resolve(route: ActivatedRouteSnapshot) {
        this.spinner.show();

        return this.permissionService.listPermissions();
    }
}