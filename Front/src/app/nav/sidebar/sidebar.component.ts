import { Component, OnInit } from '@angular/core';
import { IMenu } from 'src/app/interfaces/imenu';

@Component({
    selector: 'app-sidebar',
    templateUrl: './sidebar.component.html',
    styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
    menuList: IMenu[] = [
    {
        "descricao": "Dashboard",
        "icone": "dashboard",
        "routerLink": "dashboard"
    },
    {
        "descricao": "Meu Perfil",
        "icone": "person",
        "routerLink": "meu-perfil"
    },
    {
        "descricao": "Finanças",
        "icone": "insert_chart",
        "children": [{
            "descricao": "Gastos",
            "icone": "credit_card",
            "routerLink": "gasto"
        }]
    }];

    constructor() { }

    ngOnInit(): void {
    }
}
