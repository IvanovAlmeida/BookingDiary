import { Routes, RouterModule } from "@angular/router";
import { NgModule } from "@angular/core";

import { ItemComponent } from './item.component';
import { ListComponent } from './list/list.component';
import { EditComponent } from './edit/edit.component';
import { AddComponent } from './add/add.component';

import { ItemResolve } from 'src/app/core/resolvers/item.resolve';
import { RouterGuard } from 'src/app/core/guards/router.guard';

const dashboardItemRouting: Routes = [
    {
        path: '',
        component: ItemComponent,
        children: [
            { 
                path: '', component: ListComponent,
                canActivate: [RouterGuard],
                data: [{ claim: {type: 'Item', value: 'All'}}]
            },
            { 
                path: 'cadastrar', component: AddComponent,
                canActivate: [RouterGuard],
                data: [{claim: {type: 'Item', value: 'Add'}}]
            },
            {
                path: 'editar/:id', 
                component: EditComponent,
                canActivate: [RouterGuard],
                data: [{ claim: {type: 'Item', value: 'Edit'}}],
                resolve: {
                    item: ItemResolve
                }
            }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(dashboardItemRouting)],
    exports: [RouterModule]
})
export class ItemRoutingModule { }