import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

    form: FormGroup;
    hide: boolean = true;
    
    @Output() exibirPainel: EventEmitter<string> = new EventEmitter<string>();
    
    constructor() {}

    ngOnInit(): void {
    }

    login(): void {
        alert('login');
    }

    exibirPainelCadastro() : void {
        this.exibirPainel.emit('cadastro');
    }
}
