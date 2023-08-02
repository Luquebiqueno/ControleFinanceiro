import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '../material/material.module';

import { NavComponent } from './nav/nav.component';
import { HeaderComponent } from './header/header.component';
import { SidebarComponent } from './sidebar/sidebar.component';



@NgModule({
    declarations: [
        NavComponent,
        HeaderComponent,
        SidebarComponent
    ],
    imports: [
        CommonModule,
        RouterModule,
        MaterialModule
    ],
    exports: [
        NavComponent,
        HeaderComponent,
        SidebarComponent
    ]
})
export class NavModule { }
