import { Component, Inject, LOCALE_ID, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Gasto } from 'src/app/models/gasto';
import { GastoService } from 'src/app/services/gasto.service';
import { DialogComponent } from '../dialog/dialog.component';
import { PageEvent } from '@angular/material/paginator';
import { formatDate } from '@angular/common';
import { NotifierService } from 'src/app/services/notifier.service';

@Component({
    selector: 'app-gasto-list',
    templateUrl: './gasto-list.component.html',
    styleUrls: ['./gasto-list.component.scss']
})
export class GastoListComponent implements OnInit {

    gastos: Gasto[];
    listar: boolean = false;
    pagina = 0;
    qtdItens = 0;
    displayedColumns: string[] = ['item', 'valor', 'dataCompra', 'gastoTipo', 'acoes'];
    pesquisa: any = {
        item: '',
        valor: 0,
        dataCompra: '',
        gastoTipoId: 0
    }

    constructor(private gastoService: GastoService,
                private dialog: MatDialog,
                private notifierService: NotifierService,
                @Inject(LOCALE_ID) public locale: string) { }

    ngOnInit(): void {
        this.getGasto();
    }

    getGasto() {
        //let dataCompra = formatDate(this.pesquisa.dataCompra, 'dd-MM-yyyy' ,this.locale);
        this.gastoService.getGasto(this.pesquisa.item, this.pesquisa.valor, this.pesquisa.gastoTipoId, this.pesquisa.dataCompra, this.pagina).subscribe((response: any) => {
            this.gastos = response.data
            this.qtdItens = response.qtdItens;
            if (this.gastos.length > 0) {
                this.listar = true;
            }
        });
    }

    exportar() {
        this.gastoService.exportarArquivo(this.pesquisa.item, this.pesquisa.valor, this.pesquisa.gastoTipoId, this.pesquisa.dataCompra).subscribe((response: any) => {
            const blob = new Blob([response]);
            const fileName = 'relatorio_gastos.csv';
            const url = window.URL.createObjectURL(blob);
            const a = document.createElement('a');
            document.body.appendChild(a);
            a.href = url;
            a.download = fileName;
            a.click();
            document.body.removeChild(a);
            window.URL.revokeObjectURL(url);
            this.notifierService.showNotification('Arquivo exportado com sucesso', 'Sucesso', 'success');
        },
        error => {
            this.notifierService.showNotification('Aconteceu um erro', 'Erro', 'error');
            return;
        });
    }

    openDialogDeleteGasto(id:number) {
        this.dialog.open(DialogComponent, {data: {id: id}});
    }

    limpar() {
        this.gastos = [];
        this.listar = false;
        this.pagina = 0;
        this.qtdItens = 0;
        this.pesquisa = {
            item: '',
            valor: 0,
            dataCompra: '',
            gastoTipoId: 0
        };
    }

    handlePageEvent(pageEvent: PageEvent) {
        this.pagina = pageEvent.pageIndex;
        this.getGasto();
    }
}
