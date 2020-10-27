import { Routes, RouterModule } from "@angular/router";
import { NgModule } from "@angular/core";

import { ReserveComponent } from './reserve.component';
import { ListComponent } from './list/list.component';
import { EditComponent } from './edit/edit.component';
import { AddComponent } from './add/add.component';
import { RouterGuard } from 'src/app/core/guards/router.guard';
import { ReserveResolve } from 'src/app/core/resolvers/reserve.resolve';

const dashboardReserveRouting: Routes = [
    {
        path: '',
        component: ReserveComponent,
        children: [
            {
                path: '',  component: ListComponent,
                canActivate: [RouterGuard],
                data: [{ claim: {type: 'Reserve', value: 'All'}}]
            },
            {
                path: 'cadastrar',  component: AddComponent,
                canActivate: [RouterGuard],
                data: [{ claim: {type: 'Reserve', value: 'Add'}}]
            },
            {
                path: 'editar/:id',  component: EditComponent,
                canActivate: [RouterGuard],
                data: [{ claim: {type: 'Reserve', value: 'Edit'}}],
                resolve: {
                    reserve: ReserveResolve
                }
            },
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(dashboardReserveRouting)],
    exports: [RouterModule]
})
export class ReserveRoutingModule { }