import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Usuario } from '../models/usuario';
import { AlterarSenha } from '../models/alterar-senha';

@Injectable({
    providedIn: 'root'
})
export class UsuarioService {

    url = environment.host + 'Usuario';

    constructor(private http: HttpClient) { }

    getUsuario(): Observable<Usuario[]> {
        return this.http.get<Usuario[]>(this.url);
    }

    getUsuarioLogado(): Observable<Usuario> {
        return this.http.get<Usuario>(this.url + '/UsuarioLogado');
    }

    getUsuarioById(id: number): Observable<Usuario> {
        return this.http.get<Usuario>(this.url + '/' + id);
    }

    createUsuario(model: any) {
        return this.http.post(this.url, model);
    }

    updateUsuario(id: number, model: Usuario): Observable<Usuario> {
        return this.http.put<Usuario>(this.url + '/' + id, model);
    }

    deleteUsuario(): Observable<any> {
        return this.http.put<Usuario>(this.url + '/DeleteUsuario', null);
    }

    alterarSenha(model: AlterarSenha): Observable<any> {
        return this.http.put<AlterarSenha>(this.url + '/AlterarSenha', model);
    }
}
