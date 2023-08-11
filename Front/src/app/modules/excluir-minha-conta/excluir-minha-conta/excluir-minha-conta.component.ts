import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { NotifierService } from 'src/app/services/notifier.service';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
    selector: 'app-excluir-minha-conta',
    templateUrl: './excluir-minha-conta.component.html',
    styleUrls: ['./excluir-minha-conta.component.scss']
})
export class ExcluirMinhaContaComponent {

    constructor(private usuarioService: UsuarioService,
        private router: Router,
        private notifierService: NotifierService,
        private dialog: MatDialog) { }

    excluirConta() {
        this.usuarioService.deleteUsuario().subscribe((response: any) => {
            this.dialog.closeAll();
            this.notifierService.showNotification('A sua conta foi excluída','Sucesso', 'success');
            this.router.navigate(['autenticacao']);
        },
        error => {
            this.notifierService.showNotification('Aconteceu um erro','Erro', 'error');
        });
    }
}
