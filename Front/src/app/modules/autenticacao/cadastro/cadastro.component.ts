import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CustomErrorStateMatcher } from 'src/app/_utils/custom-error-state-matcher';
import { Usuario } from 'src/app/models/usuario';
import { NotifierService } from 'src/app/services/notifier.service';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
    selector: 'app-cadastro',
    templateUrl: './cadastro.component.html',
    styleUrls: ['./cadastro.component.scss']
})
export class CadastroComponent implements OnInit {

    hide = true;
    matcher = new CustomErrorStateMatcher();
    form: FormGroup;
    usuario: Usuario;

    @Output() exibirPainel: EventEmitter<string> = new EventEmitter<string>();

    constructor(private usuarioService: UsuarioService,
                private notifierService: NotifierService,
                private fb: FormBuilder) { }

    ngOnInit(): void {
        this.getForm();
    }

    getForm(): void {
        this.form = this.fb.group({
            nome: ['', [Validators.required]],
            email: ['', [Validators.required, Validators.email]],
            senha: ['', [Validators.required, Validators.minLength(8)]],
            telefone: [''],
            confirmarSenha: ['']
        }, { validator: this.checkPasswords });
    }

    checkPasswords(group: FormGroup) {
        let pass = group.controls.senha.value;
        let confirmPass = group.controls.confirmarSenha.value;

        return pass === confirmPass ? null : { notSame: true }
    }

    createUsuario(): void {
        if (this.form.invalid) {
            this.notifierService.showNotification('Dados inválidos', 'Erro', 'error');
            return;
        }

        this.usuario = this.form.value;
        this.usuarioService.createUsuario(this.usuario).subscribe((response: any) => {
            this.notifierService.showNotification('Usuário cadastrado com sucesso','Sucesso', 'success');
            this.exibirPainelLogin();
        },
        error => {
            this.notifierService.showNotification('Aconteceu um erro', 'Erro', 'error');
            return;
        });
    }

    exibirPainelLogin(): void {
        this.exibirPainel.emit('login');
    }

}
