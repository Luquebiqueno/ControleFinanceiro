import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UsuarioAutenticado } from 'src/app/models/usuario-autenticado';
import { UsuarioLogin } from 'src/app/models/usuario-login';
import { AutenticacaoService } from 'src/app/services/autenticacao.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

    usuarioLogin: UsuarioLogin;
    form: FormGroup;
    hide: boolean = true;

    @Output() exibirPainel: EventEmitter<string> = new EventEmitter<string>();

    constructor(private autenticacaoService: AutenticacaoService,
        private fb: FormBuilder,
        private router: Router,) { }

    ngOnInit(): void {
        this.validarFormulario();
    }

    public validarFormulario(): void {
        this.form = this.fb.group({
            email: ['', [Validators.required]],
            senha: ['', [Validators.required, Validators.minLength(8)]]
        });
    }

    login(): void {
        if (this.form.invalid) {
            alert('Dados inválidos');
            return null;
        }

        this.usuarioLogin = this.form.value;
        this.autenticacaoService.getAutenticacao(this.usuarioLogin).subscribe((usuarioAutenticado: UsuarioAutenticado) => {
            if (usuarioAutenticado && usuarioAutenticado.accessToken) {
                localStorage['usuarioAutenticado'] = JSON.stringify(usuarioAutenticado);
                alert(usuarioAutenticado.message);

                this.router.navigate(['dashboard']);
            } else {
                alert('Ocorreu um erro ao autenticar.');
            }
        });
    }

    exibirPainelCadastro(): void {
        this.exibirPainel.emit('cadastro');
    }
}
