import { Routes, RouterModule } from "@angular/router";
import { NgModule } from "@angular/core";

import { UserComponent } from './user.component';
import { ListComponent } from './list/list.component';
import { AddComponent } from './add/add.component';
import { EditComponent } from './edit/edit.component';
import { UserResolve } from 'src/app/core/resolvers/user.resolve';
import { RolesResolve } from 'src/app/core/resolvers/roles.resolve';
import { RouterGuard } from 'src/app/core/guards/router.guard';

const dashboardUserRouting: Routes = [
    {
        path: '',
        component: UserComponent,
        children: [
            {
                path: '', component: ListComponent,
                canActivate: [RouterGuard],
                data: [{ claim: { type: 'User', value: 'All' } }],
            },
            {
                path: 'cadastrar', component: AddComponent,
                canActivate: [RouterGuard],
                data: [{ claim: { type: 'User', value: 'Add' } }],
            },
            {
                path: 'editar/:id', component: EditComponent,
                canActivate: [RouterGuard],
                data: [{ claim: { type: 'User', value: 'Edit' } }],
                resolve: {
                    user: UserResolve,
                    roles: RolesResolve
                }
            }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(dashboardUserRouting)],
    exports: [RouterModule]
})
export class UserRoutingModule { }