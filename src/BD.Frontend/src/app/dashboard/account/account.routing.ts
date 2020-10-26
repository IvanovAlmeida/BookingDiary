import { Routes, RouterModule } from "@angular/router";
import { NgModule } from "@angular/core";
import { AccountComponent } from './account.component';

const dashboardAccountRouting: Routes = [
    {
        path: '',
        component: AccountComponent,
        children: [ ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(dashboardAccountRouting)],
    exports: [RouterModule]
})
export class AccountRoutingModule { }