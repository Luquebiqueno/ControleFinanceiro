import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IMenu } from '../interfaces/imenu';

@Injectable({
    providedIn: 'root'
})
export class MenuService {

    url = environment.host + 'SistemaMenu';
    
    constructor(private http: HttpClient) { }

    getMenu(): Observable<any> {
        return this.http.get(this.url);
    }
}
