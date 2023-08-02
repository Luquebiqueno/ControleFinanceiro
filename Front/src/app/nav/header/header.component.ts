import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

    ngOnInit(): void {
    }

    public sair(): void {
        alert('sair');
    }

    public alterarSenha(): void {
        alert('alterar senha');
    }

    public excluirConta(): void {
        alert('excluir conta');
    }

}
