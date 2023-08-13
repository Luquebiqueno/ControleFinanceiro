import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MaterialModule } from 'src/app/material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { GastoListComponent } from './list/gasto-list.component';
import { GastoEditComponent } from './edit/gasto-edit.component';
import { DialogComponent } from './dialog/dialog.component';


@NgModule({
    declarations: [
        GastoListComponent,
        GastoEditComponent,
        DialogComponent
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
