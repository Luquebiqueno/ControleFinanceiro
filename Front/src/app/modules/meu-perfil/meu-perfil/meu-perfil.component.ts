import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Usuario } from 'src/app/models/usuario';
import { NotifierService } from 'src/app/services/notifier.service';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
    selector: 'app-meu-perfil',
    templateUrl: './meu-perfil.component.html',
    styleUrls: ['./meu-perfil.component.scss']
})
export class MeuPerfilComponent implements OnInit {

    meuPerfilForm: FormGroup;
    usuario: Usuario;

    constructor(private usuarioService: UsuarioService,
                private fb: FormBuilder,
                private notifierService: NotifierService,
                private router: Router) { }

    ngOnInit(): void {
        this.validaForm();
        this.getUsuarioLogado();
    }

    validaForm(): void {
        this.meuPerfilForm = this.fb.group({
            nome: ['', [Validators.required]],
            email: ['', [Validators.required, Validators.email]],
            telefone: ['']
        });
    }

    getUsuarioLogado() {
        this.usuarioService.getUsuarioLogado().subscribe((response: Usuario) => {
            if (response != null) {
                this.meuPerfilForm = this.fb.group({
                    id: response.id,
                    nome: response.nome,
                    email: response.email,
                    telefone: response.telefone
                });
            }
        });
    }

    updateUsuario() {
        this.usuario = this.meuPerfilForm.value;
        this.usuarioService.updateUsuario(this.usuario.id, this.usuario).subscribe((response: Usuario) => {
            this.notifierService.showNotification('Usuário atualizado com sucesso','Sucesso', 'success');
            this.router.navigate(['../../dashboard']);
        },
        error => {
            this.notifierService.showNotification('Aconteceu um erro', 'Erro', 'error');
        });
    }
}
