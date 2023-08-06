import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GastoEditComponent } from './edit/gasto-edit.component';
import { GastoListComponent } from './list/gasto-list.component';



@NgModule({
  declarations: [
    GastoEditComponent,
    GastoListComponent
  ],
  imports: [
    CommonModule
  ]
})
export class GastoModule { }
