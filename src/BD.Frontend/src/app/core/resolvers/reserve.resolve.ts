import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Reserve } from '../models/reserve';
import { ReserveService } from '../services/reserve.service';

@Injectable()
export class ReserveResolve implements Resolve<Reserve> {
    constructor(private reserveService: ReserveService, private spinner: NgxSpinnerService) {
    }

    resolve(route: ActivatedRouteSnapshot) {
        this.spinner.show();
        return this.reserveService.getReserve(route.params['id']);
    }
}