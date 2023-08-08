import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CustomErrorStateMatcher } from 'src/app/_utils/custom-error-state-matcher';
import { AlterarSenha } from 'src/app/models/alterar-senha';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
    selector: 'app-alterar-senha',
    templateUrl: './alterar-senha.component.html',
    styleUrls: ['./alterar-senha.component.scss']
})
export class AlterarSenhaComponent implements OnInit {

    formAlterarSenha: FormGroup;
    matcher = new CustomErrorStateMatcher();
    hide = true;
    _alterarSenha: AlterarSenha;

    constructor(private formBuilder: FormBuilder,
        private usuarioService: UsuarioService,
        private router: Router) { }

    ngOnInit(): void {
        this.formAlterarSenha = this.formBuilder.group({
            senha: ['', [Validators.required, Validators.minLength]],
            confirmarSenha: ['']
        }, { validator: this.checkPasswords });
    }

    checkPasswords(group: FormGroup) {
        let pass = group.controls.senha.value;
        let confirmPass = group.controls.confirmarSenha.value;

        return pass === confirmPass ? null : { notSame: true }
    }

    alterarSenha() {
        this._alterarSenha = this.formAlterarSenha.value;    
        this.usuarioService.alterarSenha(this._alterarSenha).subscribe((response: any) => {
          alert('Senha atualizada com sucesso');
          this.router.navigate(['autenticacao']);
        },
        error => {
          alert('Aconteceu um erro');
        });
      }

}
