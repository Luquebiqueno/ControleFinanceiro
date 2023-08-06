import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from 'src/app/material/material.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AutenticacaoComponent } from './autenticacao/autenticacao.component';
import { LoginComponent } from './login/login.component';
import { CadastroComponent } from './cadastro/cadastro.component';
import { EsqueciMinhaSenhaComponent } from './esqueci-minha-senha/esqueci-minha-senha.component';



@NgModule({
    declarations: [
        AutenticacaoComponent,
        LoginComponent,
        CadastroComponent,
        EsqueciMinhaSenhaComponent
    ],
    imports: [
        CommonModule,
        MaterialModule,
        ReactiveFormsModule,
        FormsModule,
        HttpClientModule
    ],
    exports: [
        AutenticacaoComponent,
        LoginComponent,
        CadastroComponent,
        EsqueciMinhaSenhaComponent
    ]
})
export class AutenticacaoModule { }
