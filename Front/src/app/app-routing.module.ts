import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { authGuard } from './_helpers/auth.guard';
import { AutenticacaoComponent } from './modules/autenticacao/autenticacao/autenticacao.component';
import { NavComponent } from './nav/nav/nav.component';
import { DashboardComponent } from './modules/dashboard/dashboard/dashboard.component';
import { GastoListComponent } from './modules/gasto/list/gasto-list.component';
import { GastoEditComponent } from './modules/gasto/edit/gasto-edit.component';
import { MeuPerfilComponent } from './modules/meu-perfil/meu-perfil/meu-perfil.component';
import { AlterarSenhaComponent } from './modules/alterar-senha/alterar-senha/alterar-senha.component';
import { EsqueciMinhaSenhaComponent } from './modules/autenticacao/esqueci-minha-senha/esqueci-minha-senha.component';

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
        path: 'esqueci-minha-senha', component: EsqueciMinhaSenhaComponent,
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
            },
            {
                path: 'alterar-senha',
                component: AlterarSenhaComponent,
                canActivate: [authGuard]
            },
            {
                path: 'meu-perfil',
                component: MeuPerfilComponent,
                canActivate: [authGuard]
            },
            {
                path: 'gasto',
                component: GastoListComponent,
                canActivate: [authGuard]
            },
            {
                path: 'gasto/create',
                component: GastoEditComponent,
                canActivate: [authGuard]
            },
            {
                path: 'gasto/edit/:id',
                component: GastoEditComponent,
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
