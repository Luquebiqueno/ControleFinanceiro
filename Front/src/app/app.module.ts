import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { NavModule } from './nav/nav.module';
import { NotifierModule } from './modules/notifier/notifier.module';
import { AutenticacaoModule } from './modules/autenticacao/autenticacao.module';
import { MeuPerfilModule } from './modules/meu-perfil/meu-perfil.module';
import { ExcluirMinhaContaModule } from './modules/excluir-minha-conta/excluir-minha-conta.module';
import { AlterarSenhaModule } from './modules/alterar-senha/alterar-senha.module';
import { DashboardModule } from './modules/dashboard/dashboard.module';
import { GastoModule } from './modules/gasto/gasto.module';

import { AppComponent } from './app.component';
import { JwtInterceptor } from './_helpers/jwt.interceptor';

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        HttpClientModule,
        NavModule,
        NotifierModule,
        AutenticacaoModule,
        MeuPerfilModule,
        ExcluirMinhaContaModule,
        AlterarSenhaModule,
        DashboardModule,
        GastoModule
    ],
    providers: [
        {
            provide: HTTP_INTERCEPTORS,
            useClass: JwtInterceptor,
            multi: true
        }
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
