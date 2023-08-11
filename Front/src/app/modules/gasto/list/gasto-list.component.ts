import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Gasto } from 'src/app/models/gasto';
import { GastoService } from 'src/app/services/gasto.service';

@Component({
    selector: 'app-gasto-list',
    templateUrl: './gasto-list.component.html',
    styleUrls: ['./gasto-list.component.scss']
})
export class GastoListComponent implements OnInit {

    gastos: Gasto[];
    listar: boolean = false;
    pagina = 0;
    displayedColumns: string[] = ['item', 'valor', 'dataCompra', 'gastoTipo', 'acoes'];
    pesquisa: any = {
        item: '',
        valor: 0,
        dataCompra: '',
        gastoTipoId: 0
    }

    constructor(private gastoService: GastoService,
                private dialog: MatDialog) { }

    ngOnInit(): void {
        this.getGasto();
    }

    getGasto() {
        this.gastoService.getGasto(this.pesquisa.item, this.pesquisa.valor, this.pesquisa.gastoTipoId, this.pesquisa.dataCompra, this.pagina).subscribe((response: any) => {
            this.gastos = response.data
            if (this.gastos.length > 0) {
                this.listar = true;
            }
        });
    }
}
