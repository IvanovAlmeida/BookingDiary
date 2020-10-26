import { Routes, RouterModule } from "@angular/router";

import { NgModule } from '@angular/core';
import { DashboardComponent } from './dashboard.component';

import { AccessDeniedComponent } from './navigation/access-denied/access-denied.component';
import { DashboardGuard } from '../core/guards/dashboard.guard';

const dashboardRoutes: Routes = [
    {
        path: '',
        component: DashboardComponent,
        canActivate: [DashboardGuard],
        children: [            
            {
                path: 'reservas',
                loadChildren: () => import('./reserve/reserve.module').then(m => m.ReserveModule)
            },
            {
                path: 'itens',
                loadChildren: () => import('./item/item.module').then(m => m.ItemModule)
            },
            {
                path: 'usuarios',
                loadChildren: () => import('./user/user.module').then(m => m.UserModule)
            },
            {
                path: 'conta',
                loadChildren: () => import('./account/account.module').then(m => m.AccountModule)
            },
            {
                path: 'grupos-de-usuario',
                loadChildren: () => import('./role/role.module').then(m => m.RoleModule)
            },
            {
                path: 'acesso-negado',
                component: AccessDeniedComponent
            }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(dashboardRoutes)],
    exports: [RouterModule]
})
export class DashboardRoutingModule {}