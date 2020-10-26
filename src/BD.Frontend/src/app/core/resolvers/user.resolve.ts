import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from "@angular/core";
import { NgxSpinnerService } from 'ngx-spinner';

import { User } from '../models/user';
import { UserService } from '../services/user.service';

@Injectable({
    providedIn: 'root'
})
export class UserResolve implements Resolve<User> {
    constructor(private userService: UserService, private spinner: NgxSpinnerService) { }

    resolve(route: ActivatedRouteSnapshot) {
        this.spinner.show();
        return this.userService.getUser(route.params['id']);
    }
}   