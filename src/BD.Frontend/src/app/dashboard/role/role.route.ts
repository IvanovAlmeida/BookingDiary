import { NgModule } from '@angular/core';
import { RouterModule, Routes } from "@angular/router";
import { RouterGuard } from 'src/app/core/guards/router.guard';
import { PermissionResolve } from 'src/app/core/resolvers/permission.resolve';
import { RoleResolve } from 'src/app/core/resolvers/role.resolve';
import { AddComponent } from './add/add.component';
import { EditComponent } from './edit/edit.component';
import { ListComponent } from './list/list.component';
import { PermissionsComponent } from './permissions/permissions.component';
import { RoleComponent } from './role.component';

const dashboardRoleRouting: Routes = [
    {
        path: '',
        component: RoleComponent,
        children: [
            {
                path: '', component: ListComponent,
                canActivate: [RouterGuard],
                data: [{ claim: {type: 'Role', value: 'All'}}]
            },
            {
                path: 'cadastrar', component: AddComponent,
                canActivate: [RouterGuard],
                data: [{ claim: {type: 'Role', value: 'Add'}}]
            },
            {
                path: 'editar/:id', component: EditComponent,
                resolve: {
                    role: RoleResolve
                },
                canActivate: [RouterGuard],
                data: [{ claim: {type: 'Role', value: 'Edit'}}]
            },
            {
                path: 'permissoes/:id', component: PermissionsComponent,
                resolve: {
                    role: RoleResolve,
                    permissions: PermissionResolve
                },
                canActivate: [RouterGuard],
                data: [{ claim: {type: 'Role', value: 'AddClaim|DeleteClaim'}}]
            }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(dashboardRoleRouting)],
    exports: [RouterModule]
})

export class RoleRoutingModule { }