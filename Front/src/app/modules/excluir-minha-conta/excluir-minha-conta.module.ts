import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from 'src/app/material/material.module';

import { ExcluirMinhaContaComponent } from './excluir-minha-conta/excluir-minha-conta.component';



@NgModule({
  declarations: [
    ExcluirMinhaContaComponent
  ],
  imports: [
    CommonModule,
    MaterialModule
  ]
})
export class ExcluirMinhaContaModule { }
