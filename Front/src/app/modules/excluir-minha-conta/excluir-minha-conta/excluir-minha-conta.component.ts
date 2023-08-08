import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
    selector: 'app-excluir-minha-conta',
    templateUrl: './excluir-minha-conta.component.html',
    styleUrls: ['./excluir-minha-conta.component.scss']
})
export class ExcluirMinhaContaComponent {

    constructor(private usuarioService: UsuarioService,
        private router: Router,
        private dialog: MatDialog) { }

    public excluirConta() {
        this.usuarioService.deleteUsuario().subscribe((response: any) => {
            this.dialog.closeAll();
            alert('A sua conta foi excluída');
            this.router.navigate(['autenticacao']);
        },
        error => {
            alert('Aconteceu um erro');
        });
    }
}
