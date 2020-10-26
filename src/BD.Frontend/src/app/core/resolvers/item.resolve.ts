import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Injectable } from "@angular/core";
import { NgxSpinnerService } from 'ngx-spinner';
import { Observable } from 'rxjs';

import { Item } from "../models/item";
import { ItemService } from "../services/item.service";

@Injectable()
export class ItemResolve implements Resolve<Item> {

    constructor(private itemService: ItemService, private spinner: NgxSpinnerService) {
    }

    resolve(route: ActivatedRouteSnapshot) {
        this.spinner.show();
        return this.itemService.getItem(route.params['id']);
    }
}