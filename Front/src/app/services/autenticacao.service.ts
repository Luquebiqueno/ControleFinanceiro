import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { UsuarioLogin } from '../models/usuario-login';

@Injectable({
    providedIn: 'root'
})
export class AutenticacaoService {

    url = environment.host + 'Autenticacao';

    constructor(private http: HttpClient) { }

    getAutenticacao(usuarioLogin: UsuarioLogin): Observable<any> {
        return this.http.post(this.url, usuarioLogin);
    }
}
