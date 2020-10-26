import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Role } from '../models/role';
import { RoleService } from '../services/role.service';

@Injectable()
export class RolesResolve implements Resolve<Role[]> {
    constructor(private roleService: RoleService, private spinner: NgxSpinnerService) {}

    resolve(route: ActivatedRouteSnapshot) {
        this.spinner.show();
        let role = new Role();
        role.enabled = false;
        return this.roleService.searchRoles(role);
    }
}