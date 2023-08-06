import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MeuPerfilComponent } from './meu-perfil/meu-perfil.component';
import { MaterialModule } from 'src/app/material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';



@NgModule({
    declarations: [
        MeuPerfilComponent
    ],
    imports: [
        CommonModule,
        RouterModule,
        MaterialModule,
        ReactiveFormsModule,
        FormsModule
    ]
})
export class MeuPerfilModule { }
