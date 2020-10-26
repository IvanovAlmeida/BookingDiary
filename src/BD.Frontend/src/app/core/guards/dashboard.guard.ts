import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router } from '@angular/router';
import { BaseGuard } from './base.guard';

@Injectable()
export class DashboardGuard extends BaseGuard implements CanActivate {

    constructor(protected router: Router) {
        super(router);
    }

    canActivate(route: ActivatedRouteSnapshot) {
        return super.validateIsLogged();
    }
    
}