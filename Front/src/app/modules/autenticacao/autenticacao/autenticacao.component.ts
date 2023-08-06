import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-autenticacao',
    templateUrl: './autenticacao.component.html',
    styleUrls: ['./autenticacao.component.scss']
})
export class AutenticacaoComponent implements OnInit {

    cadastro: boolean = false;

    constructor() { }

    ngOnInit(): void {
    }

    exibirPainel(event: string): void {
        this.cadastro = event === 'cadastro' ? true : false;
    }

}
