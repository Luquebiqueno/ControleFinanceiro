import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MaterialModule } from 'src/app/material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { GastoListComponent } from './list/gasto-list.component';
import { GastoEditComponent } from './edit/gasto-edit.component';


@NgModule({
    declarations: [
        GastoListComponent,
        GastoEditComponent
    ],
    imports: [
        CommonModule,
        RouterModule,
        MaterialModule,
        FormsModule,
        ReactiveFormsModule
    ]
})
export class GastoModule { }
