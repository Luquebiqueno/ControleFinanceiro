import { Component, OnInit } from '@angular/core';
import { IMenu } from 'src/app/interfaces/imenu';
import { MenuService } from 'src/app/services/menu.service';

@Component({
    selector: 'app-sidebar',
    templateUrl: './sidebar.component.html',
    styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

    menuList: IMenu[];

    constructor(private menuService: MenuService) { }

    ngOnInit(): void {
        this.menuService.getMenu().subscribe((response: any) => {
            this.menuList = response;
        });
    }
}
