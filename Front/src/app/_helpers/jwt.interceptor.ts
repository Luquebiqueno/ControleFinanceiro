import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root',
})
export class JwtInterceptor implements HttpInterceptor {
    constructor() { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        let usuarioAutenticado = JSON.parse(localStorage.getItem('usuarioAutenticado'))

        if (usuarioAutenticado && usuarioAutenticado.accessToken) {
            request = request.clone({
                setHeaders: { Authorization: `Bearer ${usuarioAutenticado.accessToken}` }
            });
        }

        return next.handle(request);
    }
}