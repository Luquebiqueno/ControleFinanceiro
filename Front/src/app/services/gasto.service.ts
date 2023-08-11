import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Gasto } from '../models/gasto';

@Injectable({
    providedIn: 'root'
})
export class GastoService {

    url = environment.host + 'Gasto';

    constructor(private http: HttpClient) { }

    getGasto(item: any, valor: any, gastoTipoId: any, dataCompra: any, pagina: any): Observable<Gasto[]> {
        return this.http.get<Gasto[]>(this.url + `?item=${item}&valor=${valor}&gastoTipoId=${gastoTipoId}&dataCompra=${dataCompra}&pagina=${pagina}`);
    }

    getGastoById(id: string): Observable<Gasto> {
        return this.http.get<Gasto>(this.url + '/' + id);
    }

    createGasto(model: any) {
        return this.http.post(this.url, model);
    }

    updateGasto(id: string, model: Gasto): Observable<Gasto> {
        return this.http.put<Gasto>(this.url + '/' + id, model);
    }

    deleteGasto(id: string): Observable<any> {
        return this.http.put<Gasto>(this.url + '/DeleteGasto/' + id, null);
    }
}
