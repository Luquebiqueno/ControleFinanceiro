import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { NavModule } from './nav/nav.module';
import { AutenticacaoModule } from './modules/autenticacao/autenticacao.module';

import { AppComponent } from './app.component';

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        NavModule,
        AutenticacaoModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
