import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class DashboardService {

    url = environment.host + 'Dashboard';

    constructor(private http: HttpClient) { }

    getDashboard(dataInicial: any, dataFinal: any): Observable<any> {
        return this.http.get(this.url + `?dataInicial=${dataInicial}&dataFinal=${dataFinal}`);
    }
}
