import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NotifierComponent } from './notifier/notifier.component';
import { MaterialModule } from 'src/app/material/material.module';



@NgModule({
    declarations: [
        NotifierComponent
    ],
    imports: [
        CommonModule,
        MaterialModule
    ]
})
export class NotifierModule { }
