import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AlterarSenhaComponent } from 'src/app/modules/alterar-senha/alterar-senha/alterar-senha.component';
import { ExcluirMinhaContaComponent } from 'src/app/modules/excluir-minha-conta/excluir-minha-conta/excluir-minha-conta.component';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

    constructor(private router: Router,
                private dialog: MatDialog) { }

    ngOnInit(): void {
    }

    sair(): void {
        localStorage.removeItem('usuarioAutenticado');
        this.router.navigate(['autenticacao']);
    }

    alterarSenha(): void {
        this.router.navigate(['alterar-senha']);
    }

    excluirConta(): void {
        this.dialog.open(ExcluirMinhaContaComponent);
    }

}
