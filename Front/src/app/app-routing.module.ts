import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AutenticacaoComponent } from './modules/autenticacao/autenticacao/autenticacao.component';
import { NavComponent } from './nav/nav/nav.component';
import { DashboardComponent } from './modules/dashboard/dashboard/dashboard.component';
import { authGuard } from './_helpers/auth.guard';

const routes: Routes = [
    {
        path: '',
        redirectTo: 'autenticacao',
        pathMatch: 'full',
    },
    {
        path: 'autenticacao', component: AutenticacaoComponent,
    },
    {
        path: '', component: NavComponent,
        canActivate: [authGuard],
        children: [
            {
                path: 'dashboard',
                pathMatch: 'full',
                component: DashboardComponent,
                canActivate: [authGuard]
            }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
